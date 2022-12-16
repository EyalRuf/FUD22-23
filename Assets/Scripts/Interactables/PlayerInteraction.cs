using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public Transform cameraTransform;
    public float rayDistance;
    public LayerMask raycastMask;

    public Interactable currInteractableInSight;
    public PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput.currentActionMap.FindAction("Interact").performed += onInteractionBtn;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastInteractable();
    }

    private void onInteractionBtn(InputAction.CallbackContext context)
    {
        if (currInteractableInSight != null)
        {
            currInteractableInSight.Interact();
        }
    }

    void RaycastInteractable()
    {
        Interactable newInteractableInSIght = null;
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, rayDistance, raycastMask))
        {
            newInteractableInSIght = hit.collider.GetComponent<Interactable>();
        }

        if (currInteractableInSight != null && currInteractableInSight != newInteractableInSIght)
        {
            currInteractableInSight.UnHighlight();
            currInteractableInSight = null;
        }

        if (newInteractableInSIght != null)
        {
            currInteractableInSight = newInteractableInSIght;
            currInteractableInSight.Highlight();
        }
    }
}
