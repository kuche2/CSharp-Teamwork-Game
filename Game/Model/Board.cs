using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    struct Board
    {
        private int height { get; set; }
        private int width { get; set; }
        private int leftPosition { get; set; }
        private int rightPosition { get; set; }
        private int topPosition { get; set; }
        private int bottomPosition { get; set; }
    }
}
