
namespace FascadePattern
{
    public class Amplifier
    {
        public void Off()
        {
            Console.WriteLine("Sound Verstärker ausgeschaltet.");
        }

        public void On()
        {
            Console.WriteLine("Sound Verstärker eingeschaltet.");
        }

        public  void SetStreamingPlayer(StreamingPlayer player)
        {
            Console.WriteLine("Streaming-Player wurde gestartet.");
        }

        public void SetSurroundSound()
        {
            Console.WriteLine("Surroundsound eingeschaltet.");
        }

        public void SetVolume(int v)
        {
            Console.WriteLine($"Lautstärke gesetzt auf {v}");
        }
    }
}