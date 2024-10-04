namespace LemonadeChange
{


    public class Program
    {

        public static bool LemonadeChange(int[] bills)
        {

            int change5 = 0;
            int change10 = 0;

            foreach (int bill in bills)
            {
                if (bill == 5)   //wenn Schein ein 5er ist
                {
                    change5 += 1;
                }
                else if (bill == 10)  //exklusive Prüfung wenn Schein kein 5, dann prüfen ob Schein 10 ist
                {
                    if (change5 >= 1)
                    {
                        change10 += 1;
                        change5 -= 1;
                    }
                    else
                    {
                        return false; 
                    }
                }
                else if (bill == 20) //exklusive Prüfung wenn Schein kein 5 und kein 10, dann ob der Schein ein 20er ist 
                {
                    if (change10 >= 1 && change5 >= 1) // Bevorzugt: ein 10er und ein 5er zurückgeben
                    {
                        change10 -= 1;
                        change5 -= 1;
                    }
                    else if (change5 >= 3) // Alternative: drei 5er zurückgeben
                    {
                        change5 -= 3;
                    }
                    else
                    {
                        return false; 
                    }
                }
            }

            return true; // Wenn die Schleife erfolgreich durchlaufen wurde
        }


        public static void Main(String[] args)
        {

            int[] bills = { 5, 5, 10, 20 }; //true
            //int[] bills = { 5, 5, 10, 10, 20 }; //false
            bool result = LemonadeChange(bills);

            Console.WriteLine("Ist genug Wechselgeld vorhanden: " + result);
        }

    }




}
