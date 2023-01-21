using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidOutlineThing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableAfterSec());
    }

    IEnumerator DisableAfterSec ()
    {
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }
}
