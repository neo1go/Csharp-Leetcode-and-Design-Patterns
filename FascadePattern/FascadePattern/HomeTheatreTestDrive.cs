using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FascadePattern
{
    public class HomeTheatreTestDrive
    {
        public static void Main(String[] args)
        {
            Amplifier amp = new Amplifier();
            Empfänger tuner = new Empfänger();
            StreamingPlayer player = new StreamingPlayer();
            Projector projector = new Projector();
            Screen screen = new Screen();
            TheatreLights lights = new TheatreLights();
            PopcornPopper popper = new PopcornPopper();

            HomeTheatreFascade hometheatre = new HomeTheatreFascade(amp, tuner, player, projector,lights,screen,popper);

            hometheatre.WatchMovie("Der Pate");
            hometheatre.endMovie();
        }
    }
}
