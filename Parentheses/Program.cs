public class Program
{

    //leetcode Lösung (nicht ganz so sauber)
    public static bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' || s[i] == '[' || s[i] == '{') stack.Push(s[i]);//nur offene Klammern werden gepusht
            else if (s[i] == ')' || s[i] == ']' || s[i] == '}')//nun wird verglichen mit dem Stack 
            {
                if (stack.Count > 0) 
                {
                    //Nachschauen im Stack und bei korrekter Paarbildung wird gepoppt
                    char t = stack.Peek();
                    if (t == '(' && s[i] == ')' || t == '[' && s[i] == ']' || t == '{' && s[i] == '}') stack.Pop();
                    else return false;
                }
                else return false;
            }
            else continue;
        }
        //Wenn der Stack komplett geleert wurde, sind die Klammern richtig gesetzt worden 
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
        string s = "({([]{})})";
        // push(,push{,push(,push[,peek u pop],push{,peek u pop},peek u pop),peek u pop},peek u pop)
        //es werden nur die offenen Klammern gepusht in den Stack
        Answer(s);
        

    }
}
