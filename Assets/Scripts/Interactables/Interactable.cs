using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Highlight()
    {
        outline.enabled = true;
    }

    public void UnHighlight()
    {
        outline.enabled = false;
    }

    public virtual void Interact()
    {

    }
}
