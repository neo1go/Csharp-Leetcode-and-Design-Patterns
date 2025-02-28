
namespace FascadePattern
{
    public class TheatreLights
    {
        public void Dim(int v)
        {
            Console.WriteLine($"Licht Dimmung auf {v} Prozent gesetzt.");
        }

        public void On()
        {
            Console.WriteLine("Licht eingeschaltet.");
        }

        public void Off()
        {
            Console.WriteLine("Licht ausgeschaltet.");
        }
    }
}