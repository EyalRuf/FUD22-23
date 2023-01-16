using System.Collections;
using UnityEngine;

public class QuestInteractable : Interactable
{
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

        if (questStep.isQuestActive)
        {
            questStep.CompleteStep();

            if (doesDisappear)
            {
                meshRenderer.enabled = false;
                collider.enabled = false;
            }
        }
    }
}