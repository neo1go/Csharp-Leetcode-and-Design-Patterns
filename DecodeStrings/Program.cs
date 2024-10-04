public class Program
{

    public static string decodeString(string str)
    {
        Stack<int> numberStack = new Stack<int>();
        Stack<string> stringStack = new Stack<string>();

        string tempString = "";
        int num = 0;

        foreach (char c in str)
        {
            if (Char.IsDigit(c))  // wenn der char eine Zahl ist
            {
                num = num * 10 + (c - '0'); //hiermit wird aus  dem ASCII Char-Wert eine Zahl
            }                               //c-'0' bedeutet, dass von dem ASCII Wert z.B. für eine 1 (49)
                                            // die 0(48) abgezogen wird, um den Integer 1 zu erhalten.
                                            // die 10 dient als Multiplikator für das Dezimalsystem.
                                            // die 2 ist die 50, die 3 ist die 51
                                            //die chars 123 ergeben: 0*10 + (49-48) = 1  - diese Zahl wird dann übergeben zur Multiplikation
                                            //                       1*10 + (50-48) = 12 - diese Zahl wird dann übergeben zur Multiplikation
                                            //                      12*10 + (51-48) = 123
            else if (c == '[')
            {
                numberStack.Push(num);
                stringStack.Push(tempString);
                num = 0;
                tempString = "";
            }
            else if (c == ']')
            {
                int repeatTimes = numberStack.Pop();  //hier wird der Zähler gesetzt
                string repeatedString = "";
                for (int i = 0; i < repeatTimes; i++)
                {
                    repeatedString += tempString;   //Concatenieren entsprechend der Schleifendurchläufe
                }
                tempString = stringStack.Pop() + repeatedString;
            }
            else
            {
                tempString += c;  //sonst wird einfach der einzelne Char angefügt an den String
            }
        }

        return tempString;
    }


    public static void Main(string[] args)
    {
        string str = "2[a3[c2[x]]y]";         // ergibt  =     acxxcxxcxxyacxxcxxcxxy

        string result = decodeString(str);
        Console.WriteLine($"Aus der Zeile {str} wird:");
        Console.WriteLine(result);
    }
}
