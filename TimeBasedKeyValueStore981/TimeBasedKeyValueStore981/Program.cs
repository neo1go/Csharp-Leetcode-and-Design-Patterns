using System;
using System.Collections.Generic;
using System.Linq;

// Leetcode 981 Timebased Key-Value Store

public class TimeStampedValue
{
    public int timestamp;
    public string val;

    public TimeStampedValue(int timestamp, string val)
    {
        this.timestamp = timestamp;
        this.val = val;
    }
}

public class TimeMap
{
    public Dictionary<string, List<TimeStampedValue>> entriesByKey = new Dictionary<string, List<TimeStampedValue>>();

    public TimeMap()
    {
        entriesByKey = new Dictionary<string, List<TimeStampedValue>>();
    }

    public void Set(string key, string val, int timestamp)
    {
        if (!entriesByKey.ContainsKey(key)) // wenn noch kein key existiert, wird mit dem Wert eine neue List erstellt mit diesem Schlüssel
        {
            entriesByKey.Add(key, new List<TimeStampedValue>());
        }
        List<TimeStampedValue> timeStampedValues = entriesByKey[key];
        timeStampedValues.Add(new TimeStampedValue(timestamp, val));

        //Sortierung
        timeStampedValues = timeStampedValues.OrderBy(t => t.timestamp).ToList();//hier wird sortiert,damit der binary Search auch korrekt funktioniert.
        entriesByKey[key] = timeStampedValues; // Liste im Dictionary aktualisieren nach dem Sortieren
    }

    public string Get(string key, int timestamp)
    {
        if (!entriesByKey.ContainsKey(key))//Wenn kein Schlüssel vorhanden ist
        {
            return "";
        }

        List<TimeStampedValue> timeStampedValues = entriesByKey[key];//erstellt eine neuen Eintrag
        TimeStampedValue timeStamp = BinarySearchTimestamp(timeStampedValues, timestamp);
        if (timeStamp == null) 
        {
            return "";
        }
        return timeStamp.val; //hier wird der String zurückgegeben
    }

    //Binary Search Methode
    private TimeStampedValue BinarySearchTimestamp(List<TimeStampedValue> arr, int target)
    {
        int left = 0; //left, right und mid Pointer
        int right = arr.Count - 1;
        TimeStampedValue bestMatch = null;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            TimeStampedValue cur = arr[mid];

            if (cur.timestamp <= target)
            {
                bestMatch = cur;//Annäherung quasi, falls der Wert nicht vorhanden ist.
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return bestMatch;
    }

    public static void Main(string[] args)
    {
        TimeMap tm = new TimeMap();
        tm.Set("foo", "bar", 1);
        Console.WriteLine(tm.Get("foo", 1));         // Output: bar
        Console.WriteLine(tm.Get("foo", 3));         // Output: bar
        tm.Set("foo", "bar2", 4);
        Console.WriteLine(tm.Get("foo", 4));         // Output: bar2
        Console.WriteLine(tm.Get("foo", 2));         // Output: bar  
        tm.Set("foo", "bar3", 6);
        Console.WriteLine(tm.Get("foo", 6));         // Output: bar3
        Console.WriteLine(tm.Get("foo", 5));         // Output: bar2 -er geht auf die 4, weil die am Nächsten ist ?
        Console.WriteLine(tm.Get("foo", 10));        // Output: bar3
        Console.WriteLine(tm.Get("foo", 0));         // Output: ""
    }
}
