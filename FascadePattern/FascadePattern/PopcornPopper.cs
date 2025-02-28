
namespace FascadePattern
{
    public class PopcornPopper
    {
        public void Off()
        {
            Console.WriteLine("Popcornmaschine ausgeschaltet.");
        }

        public void On()
        {
            Console.WriteLine("Popcornmaschine eingeschaltet zum Aufwärmen.");
        }

        public void Pop()
        {
            Console.WriteLine("Popcorn poppen.");
        }
    }
}