using System.Media;


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
            SoundPlayer sp = new SoundPlayer("../../Audio/AlienLasser.wav");
            sp.Play();
        }
        public static void destroy()
        {
            SoundPlayer sp = new SoundPlayer("../../Audio/Explode.wav");
            sp.Play();
        }
    }
}
