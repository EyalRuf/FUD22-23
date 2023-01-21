using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Interactables
{
    public class PrinterInteractable : QuestInteractable
    {
        public GameObject[] printQueue;

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
            if (questStep.isQuestActive)
            {
                // spawn thingy
                if (ql.printIndex < printQueue.Length)
                    printQueue[ql.printIndex].SetActive(true);
            }

            base.Interact();
            questStep.isDone = false;
        }
    }
}