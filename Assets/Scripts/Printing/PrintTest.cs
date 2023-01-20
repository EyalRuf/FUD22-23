using UnityEngine;
using System.IO;
using SmartDLL;

public class PrintTest : MonoBehaviour
{
    public SmartPrinter smartPrinter = new SmartPrinter();
    string headerDirectory;

    void Start()
    {
        headerDirectory = Application.dataPath + "/Prints/ass.PNG";
        Print();
    }

    void Update()
    {
    }

    void Print()
    {
        //smartPrinter.PrintDocument("blabla", @headerDirectory);
    }
}