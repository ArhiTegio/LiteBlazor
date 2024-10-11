using System;
using LiteDB;
using System.Collections.Generic;
using BlazorApp1.Models;
using System.Xml.Linq;

namespace BlazorApp1.Sheduler
{
    public class Scheduler
    {
        public LiteDatabase DB { get; set; }
        public ILiteCollection<Element> Elements { get; set; }
        public CustomTaskScheduler TaskScheduler { get; set; } = new CustomTaskScheduler();
        Timer timer;
        public Scheduler()
        {
            DB = new LiteDatabase(@"Data.db");
            
            Elements = DB.GetCollection<Element>("tree");
            CreateExample();
            GetData();
            int num = 0;
            
            // создаем таймер
            timer = new Timer(ChangerData, num, 0, 10000);
        }

        private void ChangerData(object state)
        {
            var last = Values.Tree.LastOrDefault();
            var num = Convert.ToInt32(last.Name.Split('.').First());
            Elements.InsertBulk(new List<Element>(){
                new Element { ID=last.ID+1, Name= (num+1).ToString(), ParentID = null},
                new Element { ID=last.ID+2, Name=$"{num+1}.1", ParentID = last.ID+1},
            });
            GetData();
            Values.Invoke();
        }

        private void GetData()
        {
            var val = DB.GetCollection<Element>("tree").FindAll().ToList();
            Values.Tree.Clear();
            Values.Tree.AddRange(val);
        }

        public void CreateExample()
        {
            List<Element> list = new List<Element>(){
                new Element { ID=1, Name="1", ParentID = null},
                new Element { ID = 2, Name = "1.1", ParentID = 1 },
                new Element { ID = 3, Name = "1.2", ParentID = 1 },
                new Element { ID = 4, Name = "1.2.1", ParentID = 3 },
                new Element { ID = 5, Name = "2", ParentID = null },
                new Element { ID = 6, Name = "2.1", ParentID = 5 },
                new Element { ID = 7, Name = "2.2", ParentID = 5 },
                new Element { ID = 8, Name = "3", ParentID = null },
                new Element { ID = 9, Name = "3.1", ParentID = 8 },
                new Element { ID = 10, Name = "3.2", ParentID = 8 }
            };
            try
            {
                Elements.DeleteAll();

                Elements.InsertBulk(list);
            }
            catch (LiteDB.LiteException ex)
            {

            }
        }
    }
}
