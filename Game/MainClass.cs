using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
namespace Game
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine('\x0489'+"Asdhajksd");
            char? first = getValueByPosition.ReadCharacterAt(0, 0);
            Console.WriteLine(first);
        }
    }
}
