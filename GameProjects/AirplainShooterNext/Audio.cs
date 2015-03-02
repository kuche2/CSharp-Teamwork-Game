using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace AirplainShooterNext
{
    public class Audio
    {
        public void shot()
        {
            SoundPlayer sp = new SoundPlayer("../../Audio/Laser.wav");
            sp.Play();
        }
        public void enemyshot()
        {
            SoundPlayer sp = new SoundPlayer("../../Audio/Laser.wav");
            sp.Play();
        }
        public void destroy()
        {
            SoundPlayer sp = new SoundPlayer("../../Audio/Laser.wav");
            sp.Play();
        }
    }
}
