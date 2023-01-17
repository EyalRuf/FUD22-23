using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : QuestInteractable
{
    public MeshRenderer meshRenderer;
    public Collider collider;

    public override void Interact()
    {
        base.Interact();

        meshRenderer.enabled = false;
        collider.enabled = false;
    }
}
