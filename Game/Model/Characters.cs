using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    struct Characters
    {
        public static char topLeftCorner = '\x250C';
        public static char bottomLeftCorner = '\x2514';
        public static char topRightCorner = '\x2510';
        public static char bottomRightCorner = '\x2518';
        public static char verticalLine = '\x2500';
        public static char horizontalLine = '\x2502';
        public static char shipExplode = '\x0489';
        public static char shipSymbol = '@';
        public static char cursorMarker = '\x25CC';
    }
}
