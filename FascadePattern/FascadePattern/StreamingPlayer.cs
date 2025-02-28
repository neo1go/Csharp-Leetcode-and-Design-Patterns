

namespace FascadePattern
{
    public class StreamingPlayer
    {


        public StreamingPlayer() 
        {
           //falls ich hier noch etwas übergeben möchte
        }
        public void Off()
        {
            Console.WriteLine("App wird im Laptop beendet.");
        }

        public void On()
        {
            Console.WriteLine("Stream auf Laptop wird gestartet");
        }

        public void Stop()
        {
            Console.WriteLine("Streaming Player wird pausiert/gestoppt.");
        }

        internal void Play(string movie)
        {
            Console.WriteLine($"Spielt den Film \"{movie}\" ab.");
        }
    }
}