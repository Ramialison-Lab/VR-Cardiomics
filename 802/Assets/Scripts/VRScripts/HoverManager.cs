using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverManager : MonoBehaviour
{
    public GameObject infoText;
    private bool currentOn=false;
    
    public void enableText()
    {
        currentOn = true;
        StartCoroutine(ExampleCoroutine());
    }

    public void disableText()
    {
        currentOn = false;
        infoText.SetActive(false);
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        if(currentOn == true) infoText.SetActive(true);

    }

    
}
