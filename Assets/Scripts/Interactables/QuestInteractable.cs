using System.Collections;
using UnityEngine;

public class QuestInteractable : Interactable
{
    public QuestLog ql;
    public QuestStep questStep;
    public bool doesDisappear;

    public MeshRenderer meshRenderer;
    public Collider collider;

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

        if (questStep.isQuestActive && !questStep.isQuestDone(ql.printIndex))
        {
            questStep.CompleteStep();

            if (doesDisappear)
            {
                if (meshRenderer != null) meshRenderer.enabled = false;
                if (collider != null) collider.enabled = false;
                Destroy(gameObject);
            }
        }
    }
}