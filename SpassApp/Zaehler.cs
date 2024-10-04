using System.Runtime.CompilerServices;

namespace SpassApp
{
    public class Zaehler
    {
        
        public static int loopCounter()
        {
            int result = 0;
            for(int i=0;i < 10;i++)
            {
                Console.WriteLine("Zählerstelle: " + i + 1);
                result = i;
            }
            
            return result;
        }
    }
}
