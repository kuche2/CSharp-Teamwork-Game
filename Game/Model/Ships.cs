using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    struct Ships
    {
        private char Character { get; set; }
        private int height { get; set; }
        private int x { get; set; }
        private int y { get; set; }
        private bool direction { get; set; }
        private ConsoleColor color { get; set; }
    }
}
