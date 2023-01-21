using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestLog : MonoBehaviour
{
    public List<string> questTitles;
    public List<List<QuestStep>> quests;
    public List<QuestStep> quest1Steps;
    public List<QuestStep> quest2Steps;
    public List<QuestStep> quest3Steps;
    public int currQuest = 0;

    //UI
    public TextMeshProUGUI questTitleTextObj;
    public TextMeshProUGUI questProgressTextObj;
    public TextMeshProUGUI questDoneTextObj;
    public TextMeshProUGUI questStep1TextObj;
    public TextMeshProUGUI questStep2TextObj;
    public TextMeshProUGUI questStep3TextObj;
    public Image quest1Checkmark;
    public Image quest2Checkmark;
    public Image quest3Checkmark;

    public GameObject QuestProgUIPanel;
    public GameObject QuestDoneUIPanel;

    public Sprite checkmarkEmpty;
    public Sprite checkmarkFilled;

    public int printIndex = 0;
    public string ImageToPrint = "ass";
    public FirstPersonController controller;

    // Use this for initialization
    void Start()
    {
        quests = new List<List<QuestStep>>();
        quests.Add(quest1Steps);
        quests.Add(quest2Steps);
        quests.Add(quest3Steps);

        questTitleTextObj.text = "Choose Food Recipe";

        questProgressTextObj.text = "";
        questDoneTextObj.text = "Make your choise (click on one of the orange cubes)";
        QuestProgUIPanel.SetActive(false);
        QuestDoneUIPanel.SetActive(true);
        questStep1TextObj.text = "";
        questStep2TextObj.text = "";
        questStep3TextObj.text = "";

        quest1Checkmark.enabled = false;
        quest2Checkmark.enabled = false;
        quest3Checkmark.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateQuestLog ()
    {
        questTitleTextObj.text = questTitles[currQuest];
        var index = 0;
        var prog = quests[currQuest].FindAll(curr => {
            var isdone = curr.isQuestDone(index);
            index++;
            return isdone;
        }).Count;
        questProgressTextObj.text = prog + "/" + quests[currQuest].Count;

        questStep1TextObj.text = quests[currQuest].Count > 0 ? quests[currQuest][0].GetQuestText(0) : "";
        questStep2TextObj.text = quests[currQuest].Count > 1 ? quests[currQuest][1].GetQuestText(1) : "";
        questStep3TextObj.text = quests[currQuest].Count > 2 ? quests[currQuest][2].GetQuestText(2) : "";

        quest1Checkmark.enabled = quests[currQuest].Count > 0;
        quest1Checkmark.sprite = quests[currQuest].Count > 0 && quests[currQuest][0].isQuestDone(0) ? checkmarkFilled : checkmarkEmpty;
        
        quest2Checkmark.enabled = quests[currQuest].Count > 1;
        quest2Checkmark.sprite = quests[currQuest].Count > 1 && quests[currQuest][1].isQuestDone(1) ? checkmarkFilled : checkmarkEmpty;
        
        quest3Checkmark.enabled = quests[currQuest].Count > 2;
        quest3Checkmark.sprite = quests[currQuest].Count > 2 && quests[currQuest][2].isQuestDone(2) ? checkmarkFilled : checkmarkEmpty;

        QuestProgUIPanel.SetActive(prog < quests[currQuest].Count);
        QuestDoneUIPanel.SetActive(prog == quests[currQuest].Count);

        if (prog >= quests[currQuest].Count)
        {
            StartCoroutine(startNextQuest());
        }
    }

    public void StartQuest (int questNm) 
    {
        QuestProgUIPanel.SetActive(true);
        QuestDoneUIPanel.SetActive(false);
        questDoneTextObj.text = "Quest Complete! \n Great job!";

        currQuest = questNm;
        quests[currQuest].ForEach(q => {
            q.isQuestActive = true;
            q.isDone = false;
        });
        UpdateQuestLog();
    }

    IEnumerator startNextQuest ()
    {
        yield return new WaitForSeconds(1f);

        quests[currQuest].ForEach(currStep => currStep.isQuestActive = false);

        currQuest++;
        if (currQuest > 2)
        {
            // LAST QUEST - print!
            PrintTest pt = GetComponent<PrintTest>();

            try
            {
                pt.Print(ImageToPrint);
            }
            catch
            {

            }

            QuestProgUIPanel.SetActive(false);
            QuestDoneUIPanel.SetActive(true);
            questTitleTextObj.text = "YOU DID IT!";
            questDoneTextObj.text = "Printing " + ImageToPrint + " IRL! \n Quitting game in 3 seconds";
            controller.enabled = false;

            yield return new WaitForSeconds(3f);
            Application.Quit();
        } else
        {
            StartQuest(currQuest);
        }
    }
}

