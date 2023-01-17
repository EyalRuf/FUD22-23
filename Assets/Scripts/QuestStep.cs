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

    public void CompleteStep ()
    {
        isDone = true;
        ql.UpdateQuestLog();
    }
}
