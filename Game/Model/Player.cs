using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Model
{
    struct Player
    {
        private string name {get; set;}
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }
        private DateTime playTime { get; set; }
        private int result { get; set; }
    }
}
