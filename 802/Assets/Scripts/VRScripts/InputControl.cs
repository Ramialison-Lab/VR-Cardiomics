using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputControl : MonoBehaviour
{
    private SliceBehavior[] slices;
    private HandleBehavior handle;
    public GameObject rightHand;
    public GameObject leftHand;
    private bool currentlyResize = false;
    private float fscale;
    private float initalize;
    private float start;
    private float save;
    public InputField inputfield;
    public GameObject keyboard;
    public GameObject GeneMenu;


    // Start is called before the first frame update
    void Start()
    {
        slices = Object.FindObjectsOfType<SliceBehavior>();
        handle = Object.FindObjectOfType<HandleBehavior>();                
    }

    void Update()
    {
        controllerInput();
        interactionCheck();
        menuCheck();
    }

    // ControllerInput by buttons
    private void controllerInput()
    {
        // HotKey reset method
        if (OVRInput.Get(OVRInput.Button.Two)) callReset();
        if (OVRInput.Get(OVRInput.Button.Start)) callGeneMenu();
    }

    // Check for interaction with heart model
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
        }
    }


    // Resizefunction of slices
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

    // Reset function
    private void callReset()
    {
        foreach (SliceBehavior slice in slices)
        {
            slice.Reset();
        }
        handle.Reset();
    }


    private void callGeneMenu()
    {
        // GeneMenu.SetActive(true);
        GeneMenu.SetActive(true);
        Debug.Log("Menu");
    }
    private void menuCheck()
    {
        if (inputfield.isFocused) keyboard.SetActive(true);

    }

}
