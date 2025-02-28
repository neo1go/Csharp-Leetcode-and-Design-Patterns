using System;

namespace FascadePattern {


    public class HomeTheatreFascade {

       public Amplifier amp;
       public Empfänger tuner;
       public StreamingPlayer player;
       public Projector projector;
       public TheatreLights lights;
       public Screen screen;
       public PopcornPopper popper;

        public HomeTheatreFascade(Amplifier amp, Empfänger tuner, StreamingPlayer player, Projector projector, TheatreLights lights, Screen screen, PopcornPopper popper)
        {
            this.amp = amp;
            this.tuner = tuner;
            this.player = player;
            this.projector = projector;
            this.lights = lights;
            this.screen = screen;
            this.popper = popper;
        }

        public void WatchMovie(String movie) {
            Console.WriteLine("Beginne die Vorführung ...");
            popper.On();
            popper.Pop();
            tuner.StreamChannel();
            lights.Dim(10);
            screen.Down();
            projector.On();
            projector.WideScreenModeOn();
            amp.On();
            amp.SetStreamingPlayer(player);
            amp.SetSurroundSound();
            amp.SetVolume(5);
            player.On();
            player.Play(movie);
        }

        public void endMovie() {
            Console.WriteLine("Beende die Vorführung ...");
            popper.Off();
            lights.On();
            screen.Up();
            projector.Off();
            amp.Off();
            player.Stop();
            player.Off();
        }
    }



}