using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class InputControl : MonoBehaviour
{
    private SliceBehavior[] slices;
    private HandleBehavior handle;
    private GameObject heart_handle;
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
    private Keyboard keyboardScript;
    private bool menuReset = true;
    public GameObject settingsMenu;
    public GameObject player;
    private Vector3 pos;
    public GameObject copy;
    public Camera camera;
    public GameObject geneInfo;
    public OVRCameraRig cam;
    public GameObject trackerSphere;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    [SerializeField] private string selectableTag = "slice";
    private Transform _selection;


    // Start is called before the first frame update
    void Start()
    {
        slices = Object.FindObjectsOfType<SliceBehavior>();
        handle = Object.FindObjectOfType<HandleBehavior>();
        keyboardScript = Object.FindObjectOfType<Keyboard>();
        heart_handle = GameObject.Find("Heart_Grabber");
        pos = GeneMenu.transform.TransformPoint(GeneMenu.transform.position);
        Debug.Log("hoch " + Screen.height);
        Debug.Log("breit " +Screen.width);

    }

    void Update()
    {
        controllerInput();
        interactionCheck();
        menuCheck();
    }


    void LateUpdate()
    {
        //Object follows view of main camera
        geneInfo.transform.LookAt(camera.transform);
        geneInfo.transform.rotation = Quaternion.LookRotation(camera.transform.forward);

        if (GameObject.Find("GeneName") != null)
        {
            GameObject.Find("GeneName").transform.LookAt(camera.transform);
            GameObject.Find("GeneName").transform.rotation = Quaternion.LookRotation(camera.transform.forward);
        }
    }

    // ControllerInput by buttons
    private void controllerInput()
    {
        // HotKey reset method
        if (OVRInput.Get(OVRInput.Button.Two)) callReset();
        if (OVRInput.GetUp(OVRInput.Button.Start)) callGeneMenu();
        if (OVRInput.GetUp(OVRInput.Button.Four)) callOptions();
        if (OVRInput.GetUp(OVRInput.Button.One)) sliceDetector();

            if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }


        // var ray = Camera.main.ScreenPointToRay(cam.centerEyeAnchor.transform.position);
        //var ray = Camera.current.ScreenPointToRay(Input.mousePosition);


        //if trackerspehere collides with slice
        //var ray = Camera.current.ScreenPointToRay(trackerSphere.transform.position);

        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    var selection = hit.transform;
        //    if (selection.CompareTag(selectableTag))
        //    {
        //        var selectionRenderer = selection.GetComponent<Renderer>();
        //        if (selectionRenderer != null)
        //        {

        //            selectionRenderer.material = highlightMaterial;
        //        }
        //        _selection = selection;

        //    }

        //}

    }

    private void sliceDetector()
    {
        foreach (SliceBehavior slice in slices)
        {
            if (slice.selected == true)
            {
                slice.GetComponent<Renderer>().material = highlightMaterial;

                //TBD SliceNames for Compare Menu
            }
        }

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
            if (handle.isGrabbed())
            {
                if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
                {
                  //  resizeHandle();
                }
            }

        }
    }

    //TBD resize function for handle
    private void resizeHandle()
    {
        foreach (SliceBehavior slice in slices)
        {
            slice.transform.SetParent(GameObject.Find("HeartParent").transform);
        }

            // heart_handle.transform.DetachChildren();
           // heart_handle.transform.SetParent(null);

        {
            // Resize function work around because of increased object sizes due to import
            if (currentlyResize)
            {
                heart_handle.transform.position = rightHand.transform.position;
                heart_handle.transform.localScale = new Vector3(initalize, initalize, initalize);
                fscale = (rightHand.transform.position - leftHand.transform.position).magnitude;
                initalize = (fscale / start) * save;
            }
            // Resize initializing parameters
            else
            {
                initalize = heart_handle.transform.localScale.x;
                save = initalize;
                start = (rightHand.transform.position - leftHand.transform.position).magnitude;
                currentlyResize = true;
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
    public void callReset()
    {
        slices = Object.FindObjectsOfType<SliceBehavior>();

        Destroy(GameObject.Find("HeartCopy(Clone)"));

        foreach (SliceBehavior slice in slices)
        {
            if (slice.copy == true) { slice.selfDestruct(); }
            slice.Reset();
        }
        handle.Reset();
    }

    public void callGeneMenu()
    {
        if (GeneMenu.activeSelf)
        {
            GeneMenu.SetActive(false);
        }
        else if (!GeneMenu.activeSelf)
        {
            GeneMenu.SetActive(true);
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
        if (keyboard.activeSelf) { keyboard.SetActive(false);}
        else if(!keyboard.activeSelf){
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
}
