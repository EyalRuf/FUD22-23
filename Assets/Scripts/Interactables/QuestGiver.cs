using System.Collections;
using UnityEngine;

public class QuestGiver : Interactable
{
    public QuestLog ql;
    public int questNum = 0;

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

        ql.StartQuest(questNum);
        gameObject.SetActive(false);
    }
}
