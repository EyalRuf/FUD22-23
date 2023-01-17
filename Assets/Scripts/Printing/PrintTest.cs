using UnityEngine;
using System.IO;
using SmartDLL;

public class PrintTest : MonoBehaviour
{
    public SmartPrinter smartPrinter = new SmartPrinter();
    string headerDirectory = "D:/Hanze/Y4/Future Design/evidence/concept_fleshed_3.PNG";

    void Start()
    {
        Print();
    }

    void Update()
    {
    }

    void Print()
    {
        smartPrinter.PrintDocument("blabla", @headerDirectory);
    }
}