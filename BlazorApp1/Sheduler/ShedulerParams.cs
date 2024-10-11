using BlazorApp1.Models;
using System.Net.Mail;
using System.Net;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace BlazorApp1.Sheduler
{
    static public class Values
    {
        public static List<Element> Tree { get; set; } = new List<Element>
        {
            //new Element { ID=1, Name="Animals", ParentID = null},
            //new Element { ID=2, Name="Mammals", ParentID = 1},
            //new Element { ID=3, Name="Birds", ParentID = 1},
            //new Element { ID=4, Name="Bears", ParentID = 2},
            //new Element { ID=5, Name="Beavers", ParentID = 2},
            //new Element { ID=6, Name="Eagles", ParentID = 3},
            //new Element { ID=7, Name="Parakeets", ParentID = 3},
            //new Element { ID=8, Name="Things", ParentID = null},
            //new Element { ID=9, Name="Yo-yos", ParentID = 8},
            //new Element { ID=10, Name="Computers", ParentID = 8}
        };

        public static event EventHandler ChangeStates;

        public static void Invoke()
        {
            ChangeStates?.Invoke(null, EventArgs.Empty );
        }

    }

    public class ShedulerParams
    {

    }
}
