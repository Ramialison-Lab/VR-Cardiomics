using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMenu : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject canvas;
    public GameObject expandBtn;
    public GameObject resetBtn;
    public GameObject compareBtn;
    private Vector3 spawnExpand;
    private Vector3 spawnReset;
    private Vector3 spawnCompare;


    private void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("controllerButton");
        spawnCompare = compareBtn.transform.position;
        spawnExpand = expandBtn.transform.position;
        spawnReset = resetBtn.transform.position;

    }
    void Update()
    {
        if (this.gameObject.transform.GetComponent<OVRGrabbable>().isGrabbed)
        {
            menuCollapse();
        }

        if (!this.gameObject.transform.GetComponent<OVRGrabbable>().isGrabbed)
        {
            menuExpand();
        }
    }

    private void menuCollapse()
    {
        foreach (var btn in buttons){
            btn.transform.position = Vector3.Lerp(btn.transform.position, canvas.transform.position, 0.2f);
        }
        canvas.SetActive(false);
    }

    private void menuExpand()
    {        
        canvas.SetActive(true);

        compareBtn.transform.position = Vector3.Lerp(compareBtn.transform.position, spawnCompare, 0.2f);
        expandBtn.transform.position = Vector3.Lerp(expandBtn.transform.position, spawnExpand, 0.2f);
        resetBtn.transform.position = Vector3.Lerp(resetBtn.transform.position, spawnReset, 0.2f);

    }

}
