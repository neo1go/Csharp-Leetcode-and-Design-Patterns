using System.Text;
//das ganze Segment bis zum ersten Erscheinen des chars im String
//soll rumgedreht werden
//bei nur einem Buchstaben als String  wird dieser zurückgegeben
//ist der gesuchte  Buchstabe der erste im String, wird der originale String zurückgegeben
public class Program
{



    public static string reversePrefix(string word, char ch)
    {

        int firstOccurence = word.IndexOf(ch);
        if (firstOccurence == -1)
        {
            return "nicht vorhanden";
        }
        Stack<char> charStack = new Stack<char>();


        for (int i = 0; i <= firstOccurence; i++)
        {
            charStack.Push(word[i]);
        }


        StringBuilder result = new StringBuilder();

        while (charStack.Count > 0)
        {
            result.Append(charStack.Pop());
        }


        for (int i = (firstOccurence + 1); i < word.Length; i++)
        {
            result.Append(word[i]);
        }
        return result.ToString();
    }




    public static void Main(string[] args)
    {


        string word = "abcefd";
        char ch = 'd';

        string solution = reversePrefix(word, ch);

        Console.WriteLine($"Der Original String: {word} und der Buchstabe: {ch}");
        Console.WriteLine("Der neue String:" + solution);
    }
}
