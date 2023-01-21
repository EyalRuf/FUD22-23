using System.Collections;
using UnityEngine;

public class PrinterQuestStep : QuestStep
{
    public bool[] isDonePrint;
    public string[] questTextPrint;

    public override bool isQuestDone(int v)
    {
        return isDonePrint[v];
    }

    public override string GetQuestText(int v)
    {
        return questTextPrint[v];
    }

    public override void CompleteStep()
    {
        isDonePrint[ql.printIndex] = true;
        ql.printIndex++;

        base.CompleteStep();
        isDone = ql.printIndex >= isDonePrint.Length;
    }
}