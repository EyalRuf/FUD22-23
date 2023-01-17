using UnityEngine;
using System.IO;
using System.Printing;

public class PrintTest : MonoBehaviour
{
    PrintQueue printQueue;
    void Start()
    {
        LocalPrintServer localPrintServer = new LocalPrintServer();
        printQueue = localPrintServer.GetPrintQueue("Lexmark Printer");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Print();
        }
    }

    void Print()
    {
        var writer = new StreamWriter("print.txt");
        writer.WriteLine("Hello, Lexmark Printer!");
        writer.Close();
        var printServer = new PrintServer();
        var printQueue = new PrintQueue(printServer, "Lexmark Printer");
        var printJob = printQueue.AddJob("print.txt", "print.txt", false);
    }
}