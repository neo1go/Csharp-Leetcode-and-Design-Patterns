// Diese App macht nur Sinn, wenn man keine Stack-Funktion besitzt.
// Es wird mit zwei Queue's gearbeitet. Die Werte werde normal enqueued (z.B. queue1=[1,2,3]) aber sobald ein
// Push erfolgen soll(dies wäre die 3), werden einfach die älteren Werte bis auf den letzten Wert enqueued(queue2=[1,2]) in die 2te Queue und
// auch von der ersten Queue dequeuet womit nur noch der letzte Wert in queue1 steht.
// die erste Queue kann ausgelesen(queue1=[3]) und gelöscht(dequeued) werden. Dann tauschen beide ihre Plätze und die
// Werte werden wieder in die erste Queue übertragen,nicht enqueued (eingefügt, queue1 = [1,2]).
// Wenn jetzt nochmal gepoppt wird, wird die 1 übertragen in queue2 und die Zahl 2 gelöscht und die Zahl 1 wieder in queue1 kopiert.
namespace StacksimulationWithQueue
{
    //Stack is LIFO      
    //     3 <-- last  
    //     2
    //     1

    //Queue is FIFO
    //     1 <-- first
    //     2
    //     3


    public class Program
    {
        Queue<int> queue1 = new Queue<int>();
        Queue<int> queue2 = new Queue<int>();

        public static void StackPush(Program program, int p)
        {
            program.queue1.Enqueue(p);
            Console.WriteLine($"Wert {p} wurde gepusht.");
        }

        public void Pop() //Letzten Wert(LIFO) herausschmeissen. (was ja bei einem Queue normalerweise nicht funktioniert)
        {
            int count = queue1.Count;
            while (count > 1)
            {
                queue2.Enqueue(queue1.Dequeue()); //hier wird übertragen und aus queue1 gelöscht bis nur noch die zuletzt eingetragene Zahl
                                                  //stehenbleibt
                count--;
            }
            int poppedValue = queue1.Dequeue(); //Wert wird als int gespeichert und aus der queue1 gelöscht("gilt als Pop")
            Console.WriteLine($"Gepoppter Wert ist {poppedValue}");

            //Tauschen der Queues
            var temp = queue1;
            queue1 = queue2;
            queue2 = temp;
        }

        

        public static void Main(string[] args)
        {
            Program program = new Program();

           
            StackPush(program, 1);
            StackPush(program, 2);
            StackPush(program, 3);
            StackPush(program, 4);
            StackPush(program, 5);

            Console.WriteLine("Inhalte von Queue 1:");
            foreach(var item in program.queue1)
            {
                Console.Write(" "+item);
            }
            Console.WriteLine("");
           


            program.Pop();
            program.Pop();
            program.Pop();
           

            Console.WriteLine("Inhalte von Queue 1 nach den Pops:");
            foreach (var item in program.queue1)
            {
                Console.Write(" "+item);
            }

        }
    }
}
