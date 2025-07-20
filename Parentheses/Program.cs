public class Program
{

    //leetcode Lösung (nicht ganz so sauber)
    public static bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' || s[i] == '[' || s[i] == '{') stack.Push(s[i]);//nur offene Klammern werden gepusht.

            else if (s[i] == ')' || s[i] == ']' || s[i] == '}')//bei schließenden Klammern wird dann sofort mit dem obersten Eintrag im Stack verglichen. 
            {
                if (stack.Count > 0) 
                {
                    //Nachschauen im Stack und bei korrekter Paarbildung der Klammern wird gepoppt. WICHTIG
                    char t = stack.Peek();
                    if (t == '(' && s[i] == ')' || t == '[' && s[i] == ']' || t == '{' && s[i] == '}') stack.Pop();
                    else return false;  
                }
                else return false;
            }
            else continue;
        }
        //Wenn der Stack komplett geleert wurde, sind die Klammern richtig gesetzt worden. 
        if (stack.Count == 0) return true;
        else return false;
    }
    public static bool Answer(string s){
        bool isValid = IsValid(s);
        if (isValid)
        {
            Console.WriteLine("Der String ist richtig");
            return true;           
        }
        else
        {
            Console.WriteLine("Der String ist nicht zulässig");
            return false;
        }
    }

    public static void Main(string[] args)
    {
        string s = "({([[]{}])})";
        //es werden nur die offenen Klammern gepusht in den Stack und bei Finden eines Gegenstückes des obersten Elementes wieder entfernt.
        //Wenn die nächste geschlossene Klammer nicht mit dem obersten Element übereinstimmt, dann sind die Klammern nicht richtig gesetzt.

        Answer(s);
    }
}
