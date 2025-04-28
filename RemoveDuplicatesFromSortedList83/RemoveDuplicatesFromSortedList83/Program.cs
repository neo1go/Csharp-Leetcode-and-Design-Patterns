using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


// Leetcode 83 
// Die Aufgabe besteht darin, Duplikate aus einer einfach verketteten Linked List zu löschen
// Dabei wird der Zeiger einfach umgesetzt sobald ein doppelter Wert erkannt wird. Er wird einfach übersprungen.
// Der erste Knoten 'head' muß bei diesem Vorgang intakt bleiben, da ja das erste Glied der Kette erhalten bleiben muß,
// um die LL zu iterieren.
public class ListNode
{
    public int val;
    public ListNode? next;

    //Konstrukor
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}


public class Program
{

    public static ListNode DeleteDuplicates(ListNode head)
    {
        ListNode current = head; //wenn man anstatt den head in current zu setzen, 
                                 // mit head direkt arbeiten würde, dann würde alles bis zum letzten Eintrag verschoben werden.
                                 //head muß also intakt bleiben.
                                 //Also erste Regel: Bei Veränderung einer LL nicht den Kopf bewegen, sondern einen Hilfszeiger.

        while (current != null && current.next != null)//head wird hier mit abgefragt wegen möglichem Null Wert
        {
            if (current.val == current.next.val)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }
        return head;
    }

    public static void Main(string[] args)
    {

        ListNode? head = new ListNode(1);  //Root setzen

        head.next = new ListNode(1);
        head.next.next = new ListNode(2);
        head.next.next.next = new ListNode(3);
        head.next.next.next.next = new ListNode(3);

        DeleteDuplicates(head);

        while (head != null)
        {
            Console.WriteLine(head.val);
            head = head.next;
        }
    }
}



