namespace LemonadeChange
{

    //Diese Aufgabe erfordert die korrekte Rückgabe von Wechselgeld wenn ein Getränk 5 kostet.
    //Es werden nur 5er, 10er und 20er Scheine genutzt.
    //Das Startkonto ist null, also sind 5er Scheine wichtig, um überhaupt wechseln zu können falls mit
    //einem 10er oder 20er bezahlt wird.

    public class Program
    {
        public static (bool, int) LemonadeChange(int[] bills)
        {       
            int sum = 0;
            int change5 = 0;
            int change10 = 0;

            foreach (int bill in bills)
            {
                if (bill == 5)   //wenn Schein ein 5er ist
                {
                    sum = sum + change5 * 1; //die Sum ist von mir zur Berechnung überall eingefügt worden.
                    change5 += 1;
                }
                else if (bill == 10)  //exklusive Prüfung wenn Schein kein 5, dann prüfen ob Schein 10 ist
                {
                    if (change5 >= 1)
                    {
                        sum = sum + (change10 * 10) - (change5 * 5);  //der 10er erfolgt immer einen 5er als Herausgabe,deswegen -
                        change10 += 1;
                        change5 -= 1;
                    }
                    else
                    {
                        sum = (change10 * 10) + (change5 * 5);   
                        return (false,sum);
                    }
                }
                else if (bill == 20) //exklusive Prüfung wenn Schein kein 5 und kein 10, dann ob der Schein ein 20er ist 
                {
                    if (change10 >= 1 && change5 >= 1) // Bevorzugt: ein 10er und ein 5er zurückgeben
                    {
                        sum = sum - (change10 * 10) - (change5 * 5);  
                        change10 -= 1;
                        change5 -= 1;
                    }
                    else if (change5 >= 3) // Alternative: drei 5er zurückgeben
                    {
                        sum = sum - (change5 * 5 * 3);    //15 abziehen von Summe
                        change5 -= 3;
                    }
                    else
                    {
                        sum = change10 * 10 + change5 * 5;   
                        return (false, sum);
                    }
                }
            }
            sum = change10 * 10 + change5 * 5;


            return (true, sum); // Wenn die Schleife erfolgreich durchlaufen wurde
        }


        public static void Main(String[] args)
        {

            //int[] bills = { 5, 5, 10, 20 }; //true kein Wechselgeld mehr übrig
            //int[] bills = { 5, 5, 10, 10, 20 }; //false
            //int[] bills = { 5,5,5,10,20 }; //true
            int[] bills = { 5, 10, 5, 5, 5, 5, 20 };//true
            (bool result, int sum) = LemonadeChange(bills);  //Zwei getrennte Variablen als Ergebnis

            if (result == true)
            {
                Console.WriteLine("Es ist genug Wechselgeld vorhanden.");
                Console.WriteLine("Der Rest des Wechselgeldes beträgt: " + sum);
            }
            else
            {
                Console.WriteLine("Es ist nicht genug Wechselgeld vorhanden");
            }
        }

    }




}
