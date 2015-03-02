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
        public static void shot()
        {
            SoundPlayer sp = new SoundPlayer("../../Audio/Laser.wav");
            sp.Play();
        }
        public static void enemyshot()
        {
            SoundPlayer sp = new SoundPlayer("../../Audio/Laser.wav");
            sp.Play();
        }
        public static void destroy()
        {
            SoundPlayer sp = new SoundPlayer("../../Audio/Laser.wav");
            sp.Play();
        }
    }
}
