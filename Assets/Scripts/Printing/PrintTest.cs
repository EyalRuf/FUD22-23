using UnityEngine;
using System.IO;
using SmartDLL;

public class PrintTest : MonoBehaviour
{
    public SmartPrinter smartPrinter = new SmartPrinter();

    public void Print(string ImageName)
    {
        string headerDirectory = Application.dataPath + "/Prints/" + ImageName + ".PNG";
        smartPrinter.PrintDocument("", @headerDirectory);
    }
}