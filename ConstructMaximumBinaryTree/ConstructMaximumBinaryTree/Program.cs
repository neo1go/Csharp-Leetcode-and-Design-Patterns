namespace constructMaxBinaryTree
{
    public class MaxBinaryTree
    {

        //Hier wird der fertige Tree returned falls er nicht leer ist
        public TreeNode? ConstructMaximumBinaryTree(int[] nums)
        {
            //wenn nums leer ist , null returnen
            if (nums == null || nums.Length == 0)
            {
                return null;

            }

            return build(nums, 0, nums.Length - 1); //Erstellt den gesamten Baum, wobei die build-Methode rekursiv alles erzeugt 

        }

        //Hier wird der Tree erstellt
        private TreeNode? build(int[] nums, int start, int end)
        {
            if (start > end) //um die Methode zu beenden, also ein Ausstieg
            {
                return null;
            }

            //den Maxwert und somit den Wurzelknotenpunkt ermitteln WICHTIG!!!
            int indexMax = start; //Intialisieren des Maxwerts. Dieser Wert enthält die Pivot-Position des Maxwertes als Indexwert

            for (int i = start; i <= end; i++)
            {
                if (nums[i] > nums[indexMax])  // Setzen des Maxwertes als Indexpivot
                {
                    indexMax = i;

                }
            }

            //Erzeugen des Rootknotenpunktes mit dem Maxwert
            TreeNode? root = new TreeNode(nums[indexMax]);

            root.left = build(nums, start, indexMax - 1);  //rekursiv, um die linke Seite jedesmal beim Aufruf mit dem Maxwert zu populieren
            root.right = build(nums, indexMax + 1, end); //rekursiv, um die rechte Seite jedesmal beim Aufruf mit dem Maxwert zu populieren



            return root;
        }




        public void PrintTreeAsArray(TreeNode? root)  //Dies ist der BFS Ansatz (Breadth-First-Search)
                                                     //Es werden immer erst alle Knoten einer Ebene von links nach rechts besucht
        {
            if (root == null)
            {
                Console.WriteLine("[]");  //Falls der Baum leer ist
                return;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>(); //Queue-Klasse stammt aus der  Library, genauso wie List oder Dictonary
            queue.Enqueue(root);                             //Einfügen des ersten Elements (root), also nur des ersten Knotens

            List<string> result = new List<string>();

            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue(); //Der vorderste Knotenpunkt wird entfernt aus der Queue und der currenNode hinzugefügt 
                                                        //Immer ein Wert wird aus der queue entfernt
                if (currentNode != null)
                {
                    result.Add(currentNode.val.ToString()); //Der Knotenwert wird der Liste result als String hinzugefügt
                    queue.Enqueue(currentNode.left!);  //Erst wird das linke Kind des jeweiligen Knoten dem Queue-Objekt hinzugefügt.
                    queue.Enqueue(currentNode.right!); //Dann wird das recht Kind des jeweiligen  Knoten dem Queue-Objekt hinzugefügt.
                                                       //(mit dem ! wird null ignoriert).                
                }
                else
                {
                    result.Add("null");
                }
            }

            // Entferne überflüssige null-Werte am Ende der momentanen List mittels Rückwärtsschleife,
            // d.h. es wird nach jeder hinzugefügten Knotenebene erneut von hinten iteriert um Fehlern durch Indexverschiebung vorzubeugen
            // da ja Elemente aus der List<string> entfernt werden u.U..
            for (int i = result.Count - 1; i >= 0; i--)
            {
                if (result[i] == "null")
                {
                    result.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }

            // Ausgabe des Baums als Array wobei Join die Werte seriell verkettet (konkateniert)
            // und einen Trenner benötigt, in diesem Fall das Komma.
            Console.WriteLine("[" + string.Join(", ", result) + "]");
        }
    }




    public class Program
    {
        public static void Main(string[] args)
        {
            MaxBinaryTree maxBinaryTree = new MaxBinaryTree();  //leeres Objekt mit der Datenstruktur MaxBinaryTree
            int[] nums = { 3, 2, 1, 6, 0, 5 };  //Ergebnis sollte sein [6,3,5,null,2,0,null,null,1]

            TreeNode? root = maxBinaryTree.ConstructMaximumBinaryTree(nums); //Übergabe des Arrays an das Objekt und den Methodenaufruf


            maxBinaryTree.PrintTreeAsArray(root); //Hier werden alle Werte als lesbares Array in der Konsole ausgegeben.
        }
    }




    //Für die Erstellung der Knotenpunkte
    public class TreeNode
    {
        //Felder
        public int val;
        public TreeNode? left;
        public TreeNode? right;


        //Konstruktor
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}
