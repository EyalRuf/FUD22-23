using System;
using System.Collections;
using UnityEngine;

public class QuestStep : MonoBehaviour
{
    public bool isDone;
    public string questText;
    public QuestLog ql;
    public bool isQuestActive = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    virtual public void CompleteStep ()
    {
        isDone = true;
        ql.UpdateQuestLog();
    }

    virtual public string GetQuestText(int v)
    {
        return questText;
    }

    virtual public bool isQuestDone(int v)
    {
        return isDone;
    }
}
