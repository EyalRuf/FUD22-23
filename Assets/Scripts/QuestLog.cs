using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    // Use this for initialization
    void Start()
    {
        quests = new List<List<QuestStep>>();
        quests.Add(quest1Steps);
        quests.Add(quest2Steps);

        questTitleTextObj.text = "No quests active";

        questProgressTextObj.text = "-";

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

        var prog = quests[currQuest].FindAll(curr => curr.isDone).Count;
        questProgressTextObj.text = prog + "/" + quests[currQuest].Count;

        questStep1TextObj.text = quests[currQuest].Count > 0 ? quests[currQuest][0].questText : "";
        questStep2TextObj.text = quests[currQuest].Count > 1 ? quests[currQuest][1].questText : "";
        questStep3TextObj.text = quests[currQuest].Count > 2 ? quests[currQuest][2].questText : "";

        quest1Checkmark.enabled = quests[currQuest].Count > 0;
        quest1Checkmark.sprite = quests[currQuest].Count > 0 && quests[currQuest][0].isDone ? checkmarkFilled : checkmarkEmpty;
        
        quest2Checkmark.enabled = quests[currQuest].Count > 1;
        quest2Checkmark.sprite = quests[currQuest].Count > 1 && quests[currQuest][1].isDone ? checkmarkFilled : checkmarkEmpty;
        
        quest3Checkmark.enabled = quests[currQuest].Count > 2;
        quest3Checkmark.sprite = quests[currQuest].Count > 2 && quests[currQuest][2].isDone ? checkmarkFilled : checkmarkEmpty;


        QuestProgUIPanel.SetActive(prog < quests[currQuest].Count);
        QuestDoneUIPanel.SetActive(prog == quests[currQuest].Count);
    }

    public void StartQuest (int questNm) 
    {
        currQuest = questNm;
        quests[currQuest].ForEach(q => q.isQuestActive = true);
        UpdateQuestLog();
    }
}

