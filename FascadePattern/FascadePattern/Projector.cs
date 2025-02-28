
namespace FascadePattern
{
    public class Projector
    {
        public void Off()
        {
            Console.WriteLine("Projektor ausgeschaltet.");
        }

        public void On()
        {
            Console.WriteLine("Projektor eingeschaltet.");
        }

        public void WideScreenModeOn()
        {
            Console.WriteLine("Projektor Widescreen eingeschaltet.");
        }

        public void WideScreenModeOff() 
        {
            Console.WriteLine("Widescreen ausgeschaltet.");
        }
    }
}