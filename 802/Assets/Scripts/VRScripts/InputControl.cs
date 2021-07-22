﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InputControl : MonoBehaviour
{
    //Classes
    private SliceBehavior[] slices;
    private HandleBehavior handle;
    private Explode explode;
    private Colour colour;
    //Values
    private float fscale, initalize, start, save;
    private bool expand = false;
    //UI Elements
    public InputField inputfield;
    private Keyboard keyboardScript;
    public Text geneText;
    //Bools
    private bool menuReset = true;
    private bool currentlyResize = false;
    //GameObjects
    public GameObject settingsMenu;
    public GameObject player;
    public GameObject copy;
    public GameObject geneInfo;
    public GameObject trackerSphere;
    public GameObject detector;
    public GameObject keyboard;
    public GameObject geneMenu;
    private GameObject heart_handle;
    //LocalAvatar and Scene Elements
    public Camera cam; //CenterEye
    public GameObject rightHand;
    public GameObject leftHand;
    //Materials
    [SerializeField] private Material highlightMaterialGroup1;
    [SerializeField] private Material highlightMaterialGroup2;
    [SerializeField] private Material defaultMaterial;

    // Start is called before the first frame update
    void Start()
    {
        slices = Object.FindObjectsOfType<SliceBehavior>();
        handle = Object.FindObjectOfType<HandleBehavior>();
        keyboardScript = Object.FindObjectOfType<Keyboard>();
        explode = Object.FindObjectOfType<Explode>();
        heart_handle = GameObject.Find("Heart_Grabber");
        colour = Object.FindObjectOfType<Colour>();

        foreach (SliceBehavior slice in slices) slice.GetComponent<Renderer>().material = defaultMaterial;
    }

    void Update()
    {
        controllerInput();
        interactionCheck();
        menuCheck();
        detectorActivation();
    }

    // ControllerInput by buttons
    private void controllerInput()
    {
        if (OVRInput.Get(OVRInput.Button.Two)) callReset();
        if (OVRInput.GetUp(OVRInput.Button.Start)) callGeneMenu();
        if (OVRInput.GetUp(OVRInput.Button.Four)) callOptions();
        if (OVRInput.GetUp(OVRInput.Button.Three)) callExplode();
        if (OVRInput.GetUp(OVRInput.Button.One)) sliceDetector();
    }

    public void resetColour()
    {
        colour.resetColour();
    }
    IEnumerator waitFunction()
    {
        yield return new WaitForSeconds(0.2f);
        OVRInput.SetControllerVibration(0f, 0f, OVRInput.Controller.RTouch);
    }

    // Detection of single slices for group selection
    private void sliceDetector()
    {
        // selection of slices for first group
        if (Compare.first == 1)
        {
            foreach (SliceBehavior slice in slices)
            {
                if (slice.selected == true)
                {
                    // Haptic Feedback (Vibration)
                    // OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.RTouch);
                    // waitFunction();

                    if (slice.GetComponent<Renderer>().material.name == "HighlightGroup1 (Instance)")
                    {
                        slice.GetComponent<Renderer>().material = defaultMaterial;
                        Object.FindObjectOfType<Selection>().outRemove(slice.name, 1);
                    }
                    else if (slice.GetComponent<Renderer>().material.name == "HeartDefault (Instance)")
                    {
                        slice.GetComponent<Renderer>().material = highlightMaterialGroup1;
                        Object.FindObjectOfType<Selection>().outAdd(slice.name, 1);
                    }
                }
            }
        }

        // selection of slices for second group
        if (Compare.first == 2)
        {
            foreach (SliceBehavior slice in slices)
            {
                if (slice.selected == true)
                {
                    if (slice.GetComponent<Renderer>().material.name == "HighlightGroup1 (Instance)")
                    {
                        Debug.Log("This piece is already selected for Group 1.");
                    }
                    else if (slice.GetComponent<Renderer>().material.name == "HighlightGroup2 (Instance)")
                    {
                        slice.GetComponent<Renderer>().material = defaultMaterial;
                        Object.FindObjectOfType<Selection>().outRemove(slice.name, 2);
                    }
                    else if (slice.GetComponent<Renderer>().material.name == "HeartDefault (Instance)")
                    {
                        slice.GetComponent<Renderer>().material = highlightMaterialGroup2;
                        Object.FindObjectOfType<Selection>().outAdd(slice.name, 2);
                    }
                }
            }
        }

    }
    // Activates slice detection if group selection is used
    private void detectorActivation()
    {
        if (Compare.first != 0) detector.SetActive(true);
        if (Compare.first == 0) detector.SetActive(false);
    }
    private void interactionCheck()
    {
        foreach (SliceBehavior slice in slices)
        {
            // Check if object is grabbed and/or resized 
            if (slice.isGrabbed())
            {
                if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
                {
                    resizeModel(GameObject.Find(slice.name));
                }
            }
            if (handle.isGrabbed())
            {
                if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
                {
                    //  resizeHandle();
                }
            }

        }
    }
    private void resizeHandle()
    {
        //TBD resize function for handle

        foreach (SliceBehavior slice in slices)
        {
            slice.transform.SetParent(GameObject.Find("HeartParent").transform);
        }
        if (currentlyResize)
        {
            heart_handle.transform.position = rightHand.transform.position;
            heart_handle.transform.localScale = new Vector3(initalize, initalize, initalize);
            initalize = ((rightHand.transform.position - leftHand.transform.position).magnitude / start) * save;
        }
        else
        {
            initalize = heart_handle.transform.localScale.x;
            save = initalize;
            start = (rightHand.transform.position - leftHand.transform.position).magnitude;
            currentlyResize = true;
        }
    }
    private void resizeModel(GameObject prominentObject)
    {
        {
            // Resize function work around because of increased object sizes due to import
            if (currentlyResize)
            {
                prominentObject.transform.localScale = new Vector3(initalize, initalize, initalize);
                fscale = (rightHand.transform.position - leftHand.transform.position).magnitude;
                initalize = (fscale / start) * save;
            }
            // Resize initializing parameters
            else
            {
                initalize = prominentObject.transform.localScale.x;
                save = initalize;
                start = (rightHand.transform.position - leftHand.transform.position).magnitude;
                currentlyResize = true;
            }

        }
    }
    public void callReset()
    {
        slices = Object.FindObjectsOfType<SliceBehavior>();

        Destroy(GameObject.Find("HeartCopy(Clone)"));

        foreach (SliceBehavior slice in slices)
        {
            if (slice.copy == true) { slice.selfDestruct(); }
            slice.Reset();
        }

        resetColour();
        geneText.text = "";
        handle.Reset();

        expand = false;
    }

    public void callResetHeatMap()
    {
        slices = Object.FindObjectsOfType<SliceBehavior>();

        Destroy(GameObject.Find("HeartCopy(Clone)"));

        foreach (SliceBehavior slice in slices)
        {
            if (slice.copy == true) { slice.selfDestruct(); }
            slice.Reset();
        }

        handle.Reset();

        expand = false;

    }
    public void callGeneMenu()
    {
        if (geneMenu.activeSelf)
        {
            geneMenu.SetActive(false);
        }
        else if (!geneMenu.activeSelf)
        {
            geneMenu.SetActive(true);
        }
    }
    private void menuCheck()
    {
        if (inputfield.isFocused && menuReset)
        {
            keyboard.SetActive(true);
            keyboardScript.wake();
            menuReset = false;
        }

    }
    public void enableKeyboard()
    {
        if (keyboard.activeSelf) { keyboard.SetActive(false); }
        else if (!keyboard.activeSelf)
        {
            keyboard.SetActive(true);
            keyboardScript.wake();
            menuReset = false;
        }
    }
    public void callOptions()
    {
        settingsMenu.SetActive(true);
    }
    public void combinedView()
    {
        if (GameObject.Find("HeartCopy(Clone)") == null)
            Instantiate(copy);
    }
    public void resetGeneText()
    {
        geneText.text = "";
    }
    public void keyboardOnExit()
    {
        if (keyboard.activeSelf) keyboard.SetActive(false);
    }
    private void callExplode()
    {
        if (expand) return;
        //explode.Splode();
        GameObject sliceA = GameObject.Find("Slice_A");
        GameObject sliceB = GameObject.Find("Slice_B");
        GameObject sliceC = GameObject.Find("Slice_C");
        GameObject sliceD = GameObject.Find("Slice_D");
        GameObject sliceE = GameObject.Find("Slice_E");
        float scale = 12;
        Vector3 startPos = sliceA.transform.position;
        Vector3 pos = new Vector3(sliceA.transform.position.x + 2 * scale, sliceA.transform.position.y - 0.4f * scale, sliceA.transform.position.z);
        lerpTo(sliceA, startPos, pos);

        startPos = sliceB.transform.position;
        pos = new Vector3(sliceB.transform.position.x + 1 * scale, sliceB.transform.position.y - 0.2f * scale, sliceB.transform.position.z);
        lerpTo(sliceB, startPos, pos);

        startPos = sliceD.transform.position;
        pos = new Vector3(sliceD.transform.position.x - 1 * scale, sliceD.transform.position.y + 0.2f * scale, sliceD.transform.position.z);
        lerpTo(sliceD, startPos, pos);

        startPos = sliceE.transform.position;
        pos = new Vector3(sliceE.transform.position.x - 2 * scale, sliceE.transform.position.y + 0.4f * scale, sliceE.transform.position.z);
        lerpTo(sliceE, startPos, pos);

        expand = true;
    }
    private void lerpTo(GameObject slice, Vector3 from, Vector3 to)
    {
        slice.transform.position = Vector3.Lerp(from, to, 0.1f);
    }
    void LateUpdate()
    {
        geneInfo.transform.LookAt(cam.transform);
        geneInfo.transform.rotation = Quaternion.LookRotation(cam.transform.forward);

        if (GameObject.Find("GeneName") != null)
        {
            GameObject.Find("GeneName").transform.LookAt(cam.transform);
            GameObject.Find("GeneName").transform.rotation = Quaternion.LookRotation(cam.transform.forward);
        }
    }
}
