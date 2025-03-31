namespace PartitionLabels763
{
    // Leetcode 763
    // Es sollen Partitionen eines Strings zurückgeben werden.
    // Bspl.:  "ababcbacadefegdehijhklij"
    // Es wird vom ersten Buchstaben, in diesem Fall das a, bis zum letzten a ein max Partitionslänge ermittelt.
    // Quasi eine Spannweite für die Partition. Da alle Werte innerhalb dieses Partitionsbereiches kleiner als
    // die Position von a waren, gilt dies als eine Partition. Nun wird die nächste Partition erstellt.
    // Hier wird es interessant da mit dem Wert von d ein Maxwert gesetzt wird. Es sit aber ein Buchstabe innerhalb dieses
    // Bereiches, der den Maxwert erhöht, nämlich das e. Dadurch wird ein neuer Maxwert  gesetzt. Da jetzt kein größerer Wert
    // mehr gesetzt wurde, gilt die Position von e als Ende der Partition und es wird eine neue Partition angefangen.....usw.
    //
    // 2tes Beispiel: "cdedcaba" -> 5,3  "cdedc" weil c bis c      und "aba" weil a bis a
    public class Program
    {

        public List<int> PartitionLabels(string s)
        {
            Dictionary<Char, int> lastIndex = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                lastIndex[s[i]] = i;  //hier wird der dict befüllt mit den Values der Buchstaben.
            }

            List<int> partitions = new List<int>();
            int partitionEnd = 0;
            int partitionStart = 0;

            for (int i = 0; i < s.Length; i++)
            {
                partitionEnd = Math.Max(partitionEnd, lastIndex[s[i]]);

                if (partitionEnd == i)
                {
                    partitions.Add(i - partitionStart + 1);
                    partitionStart = i + 1;
                }
            }
            return partitions;
        }


        public static void Main(string[] args)
        {
            Program program = new Program();
            // string s = "ababcbacadefegdehijhklij";
            string s = "cdedcaba";
            List<int> result = program.PartitionLabels(s);

            foreach (int r in result)
            {
                Console.Write(r + ", ");
            }
        }
    }
}
