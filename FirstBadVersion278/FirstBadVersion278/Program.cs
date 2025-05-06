//Leetcode 278 First Bad Version

public class VersionControl
{
    private int _firstBad;
    public VersionControl(int firstBad)
    {
        _firstBad = firstBad;
    }
    public bool IsBadVersion(int version)
    {
        return version >= _firstBad; //werden auf true gesetzt ab version
    }
}

public class Solution : VersionControl
{
    public Solution(int firstBad) : base(firstBad) { } //Konstruktor,der sich auf firstBad aus der Basisklasse bezieht.

    public int FirstBadVersion(int n)
    {
        //binary search: "lower bound" oder auch "First True" genannnt.
        int left  = 1;// 1 da mit Version 1 angefangen wird.
        int right = n;

        // Es wird hier solange der rechte Pointer nach links bewegt, solange man auf true steht.
        // Also alle Werte, die als falsch gelten, sind ja auf true gesetzt.
        // Wenn ein false Wert erscheint, wird der linke Pointer nach rechts versetzt.
        //
        // ACHTUNG Diese Variante muß immer voll durchlaufen bis sich beide Pointer treffen und somit
        // die Grenze gefunden wurde.
        while (left < right)
        {
            int mid = left + (right - left) / 2;//wird jedesmal neu berechnet

            if (IsBadVersion(mid)) //wenn true, dann 
            {
                right = mid;  //der rechte Pointer wird auf die Mitte gesetzt
            }
            else
            {
                left = mid + 1;//da dann alle bools links von mid auch false sind
            }
        }
        return left;
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        int n = 5;//Gesamtlänge
        int firstBad = 4;//Auftreten des ersten Fehlers, wird nur zur Übung angezeigt. Normalerweise nicht sichtbar.
        Solution solution = new Solution(firstBad);

        Console.WriteLine(solution.FirstBadVersion(n));
    }
}

