//Hier wird der BinaryTree manuell erstellt in Program  

namespace BinaryTreeIterators
{
    //Diese Klasse definiert die Knotenpunkte 
    public class TreeNode<T>
    {
        public T Value { get;  }  //T gilt als generisch.,es kann also jeder Datentyp sein
        public TreeNode<T>? Left { get; set; }
        public TreeNode<T>? Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Left = null;  //Startwerte 
            Right = null; //Startwerte 
        }
    }

    public class BinaryTree<T>
    {
        public TreeNode<T>? Root { get; set; }  //Wurzel

        public BinaryTree(T rootValue)
        {
            Root = new TreeNode<T>(rootValue);
        }

        public void DepthFirstSearch() //Nutzt die Funktionalität des Program-Call-Stacks mit LIFO
        {
            Console.WriteLine("Depth-First Search");
            DFSRecursive(Root);
        }

        //Diese Suche geht zuerst bis zum tiefsten linken Knoten oder Blatt
        private static void DFSRecursive(TreeNode<T>? node)
        {
            if (node == null) 
            {
                return;
            }
            Console.WriteLine(node.Value); //Pre-Order Traversal
            DFSRecursive(node.Left);//Die Reihenfolge bewirkt, das solange links weiteriteriert wird, solange ein Wert vorhanden ist.
            DFSRecursive(node.Right);//Erst wenn links "null" ist, wird zurückgesprungen und der node.Right ausgeführt.

            //Es wird immer zum letzten besuchten Knoten zurückgesprungen, weil dieser im Call-Stack als letztes hinterlegt wurde.
        }

        public void BreadthFirstSearch()
        {
            Console.WriteLine("Breadth-First Search");

            if (Root == null) return;

            //Hier werden immer beim Besuch eines Knotens die Kinder in die Queue eingefügt, während der aktuelle Knoten herausgeworfen
            //wird. So wird automatisch immer der nächste Knoten besucht,der herausgeworfen werden soll. (FIFO).
            //Es wird also horizontal iteriert.
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            queue.Enqueue(Root);

            //Solange noch Knoten vorhanden sind
            while (queue.Count > 0)
            {
                TreeNode<T> current = queue.Dequeue(); //der aktuell besuchte Knoten wird wieder aus der Queue herausgeschmissen.
                Console.WriteLine(current.Value);

                if (current.Left != null)  //Solange Knoten einen Wert haben, werden sie in die Queue eingestellt.
                {
                    queue.Enqueue(current.Left);  //Es wird mit links angefangen.
                }
                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
                
            }
            
        }
    }

    public class Program
    {
        public static void Main()
        {
            //Baum erstellen
            BinaryTree<int> binaryTree = new BinaryTree<int>(1);  //hier muß anstatt T der tatsächliche Datentyp stehen.

            binaryTree.Root.Left = new TreeNode<int>(2);
            binaryTree.Root.Right = new TreeNode<int>(3);
            binaryTree.Root.Left.Left = new TreeNode<int>(4);
            binaryTree.Root.Left.Right = new TreeNode<int>(5);
            binaryTree.Root.Right.Left = new TreeNode<int>(6);
            binaryTree.Root.Right.Right = new TreeNode<int>(7);


            binaryTree.DepthFirstSearch();
            Console.WriteLine();

            binaryTree.BreadthFirstSearch();
        }

    }
}