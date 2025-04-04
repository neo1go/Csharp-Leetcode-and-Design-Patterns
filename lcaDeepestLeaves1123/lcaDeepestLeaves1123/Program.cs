using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


// Leetcode 1123
// Lowest common Ancestor of a deepest Leave
// Es geht um den tiefsten gemeinsamen Verwandten. Dies ist verwirrend. Es ist der erste gemeinsame Knoten von unten, der von beiden Blättern erreicht wird
// Bei 2 Blättern mit dem selben Elternknoten ist das leicht weil es dann natürlich der Elternknoten ist.
// Wenn es nur ein Blatt gibt auf einer Ebene, dann ist dieses Blatt selbst der LCA weil auch keine Verwandtschaftsbeziehung zwischen 2 Blättern
// existiert. Erst wenn ein zweites Blatt alleine stehen würde, muß man eine Beziehung herleiten.
// Die Besonderheit:
// Wenn die Blätter weiter auseinanderliegen, dann muß man durch eine Helfermethode den TIEFSTEN gemeinsamen Verwandten suchen. 
//       1
//      / \
//     4   9
//    /\   /\
//   6  2 3  5
//  /         \
// 7           8
//
//  Das Ergebnis ist dann [1,7,8] weil 1 der tiefste gemeinsame Verwandte ist.
//
//
//       1
//      / \
//     4   9
//    /\   /\
//   n  2 3  5
//       /    \
//      6      8
//  hier ist der tiefste gemeinsame Verwandte die 9  also  [9,6,8]

public class TreeNode
{
    public int Value;        // Wert des Knotens
    public TreeNode? Left;   // Zeiger auf das linke Kind
    public TreeNode? Right;  // Zeiger auf das rechte Kind

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}


public class Program
{

    public static int?[] LcaDeepestLeaves(int?[] root)
    {
        if (root == null || root.Length == 0 || !root[0].HasValue)
            return new int?[0];

        Dictionary<int, int> depthMap = new Dictionary<int, int>();
        Dictionary<int, int> parentMap = new Dictionary<int, int>();//Das ist die Beziehung zwischen Blättern und Knoten 
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);
        depthMap[0] = 0;  //hält fest, wie viele Ebenen es gibt
        int maxDepth = 0; //Der Zähler für die Anzahl der Level. So weiß man , das man nur auf der untersten Ebene auslesen darf.
        List<int> leaves = new List<int>();

        // BFS to calculate depth and parent for each node, and collect leaves
        while (queue.Count > 0)
        {
            int index = queue.Dequeue();
            int currentDepth = depthMap[index];
            bool isLeaf = true;

            int leftChild = 2 * index + 1;
            if (leftChild < root.Length && root[leftChild].HasValue)//Wenn Wert vorhanden
            {
                depthMap[leftChild] = currentDepth + 1;
                parentMap[leftChild] = index;
                queue.Enqueue(leftChild);
                isLeaf = false;
            }

            int rightChild = 2 * index + 2;
            if (rightChild < root.Length && root[rightChild].HasValue)
            {
                depthMap[rightChild] = currentDepth + 1;
                parentMap[rightChild] = index;
                queue.Enqueue(rightChild);
                isLeaf = false;
            }

            if (isLeaf) //Bleibt nur auf true, wenn keine Kindknoten dieses Knotens mehr exisitieren und es somit zum Blatt wird.
            {
                leaves.Add(index);
                if (currentDepth > maxDepth)
                    maxDepth = currentDepth; //Setzen des größten Wertes für die maximale Anzahl an Ebenen
            }
        }

        
        var deepestLeaves = leaves.Where(l => depthMap[l] == maxDepth).ToList();//es werden die tiefsten Blätter gespeichert

        if (deepestLeaves.Count == 0) //Wenn keine vorhanden, dann ist das vorherige Level voll von Nodes ohne Kindknoten.
            return new int?[0];

        // Find LCA of all deepest leaves
        int lcaIndex = deepestLeaves[0];
        foreach (var leaf in deepestLeaves.Skip(1))
        {
            lcaIndex = FindLca(parentMap, lcaIndex, leaf);//Die Indexe im Baum ,z.B. 3,4,5 .Dies sind nicht die Werte sondern die Positionen
        }

        // Collect the deepest leaves' values
        int?[] result = new int?[3];
        result[0] = root[lcaIndex];  //Den Elternknoten setzen an erster Stelle. Der Wert des Elternknotens wird mittels Methode ermittelt.
        if (deepestLeaves.Count >= 1)
            result[1] = root[deepestLeaves[0]];
        if (deepestLeaves.Count >= 2)
            result[2] = root[deepestLeaves[1]];

        return result;
    }

    // Die Werte von a und b werden in ein HashSet eingetragen und sobald b auf einen Wert trifft ,der von a schon gesetzt wurde, ist der lca gefunden
    // worden.
    private static int FindLca(Dictionary<int, int> parentMap, int a, int b)
    {
        HashSet<int> path = new HashSet<int>();
        
        while (true)
        {
            path.Add(a);                         //Der Pfad wird im HashSet gespeichert solange Werte kommen
            if (!parentMap.ContainsKey(a))
                break;
            a = parentMap[a];  //zum Elternknoten von a setzen. Wird ja eigentlich immer root
        }

        // Traverse from b to root to find common ancestor
        while (true)
        {
            if (path.Contains(b))//diese Scheife sucht im Pfad von b den ersten Knoten, der auch im Pfad von a existiert.Dies ist dann der lca.
                return b;        //HIER IST DIE BESONDERHEIT: Es wird sofort abgebrochen, wenn der lca gefunden wurde.
            if (!parentMap.ContainsKey(b))
                break;
            b = parentMap[b];
        }

        
        return -1;//kann unter normalen Bedingungen nie passieren außer der Tree ist nicht sauber programmiert.
    }


    public static void Main(string[] args)
    {
        int?[] root = [3, 5, 1, 6, 2, 0, 8, null, null, 7, 4];

        int?[] result = LcaDeepestLeaves(root);

        foreach (var r in result) 
        {
            Console.Write(r + " ");
        }
    }

}
