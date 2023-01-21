using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionVR : MonoBehaviour
{
    public Transform handTransform;
    public float rayDistance;
    public LayerMask raycastMask;
    public LineRenderer lr;

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

        Vector3[] pos = { handTransform.position, currInteractableInSight != null ? currInteractableInSight.transform.position : handTransform.position + (handTransform.forward * rayDistance) };
        lr.SetPositions(pos);
        lr.transform.position = handTransform.position;
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
        if (Physics.Raycast(handTransform.position, handTransform.forward, out hit, rayDistance, raycastMask))
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
