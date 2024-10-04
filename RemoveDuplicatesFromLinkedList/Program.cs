public class Program
{
    //Entfernen von Duplikaten in einer sortierten LinkedList
    // dies ist nicht die optimalste Version

    static LinkedList<int> RemoveDuplicates(LinkedList<int> list)
    {
        LinkedList<int> uniqueList = new LinkedList<int>();
        HashSet<int> seen = new HashSet<int>();   //Es werden nur Unikate gespeichert

        foreach (int num in list)
        {
            if (!seen.Contains(num))// wenn kein Duplikat im HashSet vorhanden ist, wird der Wert hinzugefügt
            {
                //die Bedingung bezieht sich raffinierterweise auf das HashSet welches nicht returned wird
                //die LinkeList ist dadurch aber mit einbezogen beim Adden der Werte
                uniqueList.AddLast(num);  //es wird LinkedList genutzt, um die Reihenfolge beizubehalten 
                seen.Add(num);  //im HashSet wird die Reihenfolge nicht zwangsläufig beibehalten
                               
            }
        }

        return uniqueList;
    }

    public static void Main(string[] args)
    {
        LinkedList<int> nums = new LinkedList<int>();
        nums.AddLast(1);
        nums.AddLast(1);
        nums.AddLast(2);
        nums.AddLast(2);
        nums.AddLast(2);
        nums.AddLast(2);
        nums.AddLast(3);
        nums.AddLast(4);
        nums.AddLast(4);


        LinkedList<int> solution = RemoveDuplicates(nums);

        foreach (int num in solution)
        {
            Console.WriteLine(num);
        }
    }
}

