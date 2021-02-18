using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    private SliceBehavior[] slices;
    public GameObject rightHand;
    public GameObject leftHand;
    private bool currentlyResize = false;
    private float fscale;
    private float initalize;
    private float start;
    private float save;


    // Start is called before the first frame update
    void Start()
    {
        slices = Object.FindObjectsOfType<SliceBehavior>();
    }

    void Update()
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

        // HotKey reset method
        if (OVRInput.Get(OVRInput.Button.One))
        {
            foreach (SliceBehavior slice in slices)
            {
                slice.Reset();
            }
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
}
