
//Leetcode 199
//Nur der weiteste rechte Knoten einer Ebene eines Binary tree soll in das Ergebnis aufgenommen werden.

public class TreeNode()
{
    public int Value { get; set; } //Grundwert des Kontenpunktes

    public TreeNode? Left { get; set; } //Der Knoten heisst nur Left,hat aber keine direktionale Komponente

    public TreeNode? Right { get; set; }

    public TreeNode(int value) : this()  // hier wird der erste Wert eingetragen
    {
        Value = value;
        Left = null;
        Right = null;

    }

    public TreeNode(int value, TreeNode? left, TreeNode? right) : this()  // hier wird quasi bei Erstellung mit .Left oder .Right entschieden,welcher Knoten 
    {                                                                     // erstellt wird. Wenn man nur TreeNode eingibt ohne Left oder Right, dann
        Value = value;                                                    // erstellt man automatisch die root.
        Left = left;
        Right = right;
    }
}
//------------------------------------------------------------------------------
public class Program
{

    public List<int> RightSideView(TreeNode root)
    { //Level Order Traversal

        List<int> result = new List<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();  //Bauminstanziierung
        queue.Enqueue(root);  //Root wird erstellt

        while (queue.Count > 0)
        {
            int levelSize = queue.Count; // Anzahl der Knoten auf aktuellem Level. D.h. dieser Wert gilt pro Ebene, weil in die Queue immer 
                                         // basierend auf den Kindelementen, neue Einträge in die Queue stattfinden.
            int lastValue = 0; //Hier wird andauernd der letzte Wert gespeichert. Bedeutet,das bei jeder Ebene immer nur der letzte Wert bleibt.

            for (int i = 0; i < levelSize; i++) //sobald ein Level durchschritten wurde, geht es wieder an die While Schleife zurück ,die auch die levelSize erneuert.
            {
                TreeNode node = queue.Dequeue();//mein Missverständnis - Dequeue leert zwar das queue Objekt, der Wert wird aber in node gespeichert.
                lastValue = node.Value; // es wird hier also pausenlos der node und lastValue überschrieben.

                if (node.Left != null)   //fügt Kind-Knoten hinzu, falls nicht leer. Durch dieses Verfahren entstehen die Queues immer ebenenweise.
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            result.Add(lastValue);  // Letzter Wert einer Ebene wird hinzugefügt, also am weitesten rechter Wert einer Ebene.
        }                           // Falls man den am weitesten links vorhandenen Wert haben möchte, muss man stattdessen einfach
                                    // mit if(i==0){firstValue=node.Value} eintragen und erhält bei jeder Ebene den 0ten Eintrag.

        return result;
    }

    public static void Main()
    {
        Program program = new Program();

        TreeNode root = new TreeNode(1); //erstellt den root-Knoten
        root.Left = new TreeNode(2);
        root.Right = new TreeNode(5);
        root.Left.Left = new TreeNode(3);
        root.Left.Right = new TreeNode(8);
        root.Left.Left.Left = new TreeNode(9);
        root.Left.Left.Right = new TreeNode(10);
        root.Left.Right.Right = new TreeNode(6);
        root.Left.Left.Left.Right = new TreeNode(7);

        List<int> result = program.RightSideView(root);

        foreach (int r in result)
        {
            Console.WriteLine(r);
        }
    }
}