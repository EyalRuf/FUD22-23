using Assets.Scripts.Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : Interactable
{
    public QuestLog ql;

    public List<QuestGiver> Recipes;

    public List<string> questTitles;
    public List<QuestStep> quest1Steps;
    public List<QuestStep> quest2Steps;
    public List<QuestStep> quest3Steps;

    public GameObject[] printQueue;
    public string[] questTextPrint;

    public string ImageToPrint;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        base.Interact();

        ql.quests = new List<List<QuestStep>>();
        ql.quests.Add(quest1Steps);
        ql.quests.Add(quest2Steps);
        ql.quests.Add(quest3Steps);
        ql.questTitles = questTitles;
        ql.ImageToPrint = ImageToPrint;


        PrinterInteractable pi = FindObjectOfType<PrinterInteractable>();
        pi.printQueue = printQueue;

        PrinterQuestStep pqs = FindObjectOfType<PrinterQuestStep>();
        pqs.questTextPrint = questTextPrint;


        ql.StartQuest(0);
        gameObject.SetActive(false);

        Recipes.ForEach(curr => curr.gameObject.SetActive(false));
    }
}
