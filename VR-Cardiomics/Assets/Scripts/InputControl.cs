using System;
using UnityEngine;
using UnityEngine.UI;


public class InputControl : MonoBehaviour
{
    //Classes
    private Colour colour;
    //Values
    private float fscale;
    private float initalize;
    private float start;
    private float save;
    private int currentSelection;
    //UI Elements
    public InputField inputfield;
    private Keyboard keyboardScript;
    public Text geneText;
    //Bools
    private bool menuReset = true;
    private bool currentlyResize = false;
    private bool expand = false;
    private bool highlighterActive = false;
    private bool groupselectActive = false;
    //GameObjects
    private GameObject select;
    public GameObject settingsMenu;
    public GameObject player;
    public GameObject copy;
    public GameObject detector;
    public GameObject keyboard;
    public GameObject geneMenu;
    public GameObject ColorButtonBig;
    private GameObject heart_handle;

    //LocalAvatar and Scene Elements
    public Camera cam; //CenterEye
    public GameObject rightHand;
    public GameObject leftHand;
    //Materials
    [SerializeField] private Material highlightMaterialGroup1;
    [SerializeField] private Material highlightMaterialGroup2;
    [SerializeField] private Material defaultMaterial;
    private string selectModel = "0";
    private float tempscale =0;

    // Start is called before the first frame update
    void Start()
    {
        keyboardScript = UnityEngine.Object.FindObjectOfType<Keyboard>();
        heart_handle = GameObject.Find("Heart_Grabber");
        colour = UnityEngine.Object.FindObjectOfType<Colour>();

    }

    void Update()
    {
        if (highlighterActive)
        {

            if (OVRInput.GetUp(OVRInput.Button.One))
            {
                if (GameObject.Find("Highlighter") != null)
                {
                    colour.setSelectModel(GameObject.Find("Highlighter").transform.root.name);
                    setSelectModel(GameObject.Find("Highlighter").transform.root.name);
                    GameObject.Find("Highlighter").SetActive(false);
                    highlighterActive = false;
                }
                else callHighlighter();
            }

            if (OVRInput.GetUp(OVRInput.Button.Four))
            {
                if (GameObject.Find("Highlighter") != null)
                {
                    currentSelection = Int16.Parse(GameObject.Find("Highlighter").transform.root.name);
                    try { 
                        GameObject.Find(currentSelection.ToString()).transform.GetChild(0).Find("Extensions").Find("Highlighter").transform.gameObject.SetActive(false); 
                    }
                    catch (Exception) { }

                    currentSelection++;

                    if (GameObject.Find(currentSelection.ToString()) != null)
                    {
                        try { 
                            GameObject.Find(currentSelection.ToString()).transform.GetChild(0).Find("Extensions").Find("Highlighter").transform.gameObject.SetActive(true);
                        }
                        catch (Exception) { }
                    }
                    else
                    {
                        callHighlighter();
                        currentSelection = 0;
                    }
                }
                else
                {
                    callHighlighter();
                }
            }
        }
        else if (!highlighterActive)
        {
            controllerInput();
            interactionCheck();
            menuCheck();
        }
        if (GameObject.Find("hands:b_r_index1") != null) GameObject.Find("Detector_R").transform.position = GameObject.Find("hands:b_r_index_ignore").transform.position;
        if (GameObject.Find("hands:b_l_index1") != null) GameObject.Find("Detector_L").transform.position = GameObject.Find("hands:b_l_index_ignore").transform.position;


    }

    public void setSelectModel(string selectModel)
    {
        this.selectModel = selectModel;
    }


    // ControllerInput by buttons
    private void controllerInput()
    {
       // if (OVRInput.Get(OVRInput.Button.Two)) callReset();
        if (OVRInput.GetUp(OVRInput.Button.Start)) callGeneMenu();
        if (OVRInput.GetUp(OVRInput.Button.Four)) callHighlighter();
        if (OVRInput.GetUp(OVRInput.Button.Three)) callExplode();
        if (groupselectActive) { 
            if (OVRInput.GetUp(OVRInput.Button.One)) sliceDetector(); }

    }

    public void resetColour()
    {
        int num = GameObject.Find("ScriptHolder").GetComponent<ObjectManager>().numberOfObjects();
        for(int i=0; i < num; i++)
        {
            GameObject.Find("ScriptHolder").GetComponent<ObjectManager>().deleteModel();
        }
        GameObject.Find("ScriptHolder").GetComponent<ObjectManager>().addModel();

        colour.resetColour();
    }

    private void callHighlighter()
    {
        highlighterActive = true;

        try
        {
            GameObject.Find("Extensions").transform.Find("Highlighter").transform.gameObject.SetActive(true);
            colour.adjustNorm();
        }
        catch (Exception) { }
    }

    public void activateGroupSelection()
    {
        groupselectActive = true;
    }

    public void setselection(GameObject obj)
    {
        select = obj;
    }

    // Detection of single slices for group selection
    private void sliceDetector()
    { //TBD
        // selection of slices for first group
        if (Compare.first == 1)
        {
            if (select.GetComponent<Renderer>().material.name == "HighlightGroup1 (Instance)")
            {
                select.GetComponent<Renderer>().material = defaultMaterial;
                UnityEngine.Object.FindObjectOfType<Selection>().outRemove(select.name, 1);
            }
            else if (select.GetComponent<Renderer>().material.name == "HeartDefault (Instance)")
            {
                select.GetComponent<Renderer>().material = highlightMaterialGroup1;
                UnityEngine.Object.FindObjectOfType<Selection>().outAdd(select.name, 1);
            }

        }

        // selection of slices for second group
        if (Compare.first == 2)
        {

            if (select.GetComponent<Renderer>().material.name == "HighlightGroup1 (Instance)")
            {
                Debug.Log("This piece is already selected for Group 1.");
            }
            else if (select.GetComponent<Renderer>().material.name == "HighlightGroup2 (Instance)")
            {
                select.GetComponent<Renderer>().material = defaultMaterial;
                UnityEngine.Object.FindObjectOfType<Selection>().outRemove(select.name, 2);
            }
            else if (select.GetComponent<Renderer>().material.name == "HeartDefault (Instance)")
            {
                select.GetComponent<Renderer>().material = highlightMaterialGroup2;
                UnityEngine.Object.FindObjectOfType<Selection>().outAdd(select.name, 2);
            }

        }

    }

    private void interactionCheck()
    {
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
            {
                if (gameObj.transform.GetComponent<OVRGrabbable>() != null) {
                        if (gameObj.transform.GetComponent<OVRGrabbable>().isGrabbed)
                        {
                        resizeModel(gameObj);

                        } 
                }
            }

        }
                
                //        {
        //            resizeModel(GameObject.Find(slice.name));
        //        }
        //    }
        //    if (handle.isGrabbed())
        //    {
        //        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        //        {
        //            //  resizeHandle();
        //        }
        //    }

        //}
    }

    private void resizeModel(GameObject obj)
    {
        {
            // Resize function work around because of increased object sizes due to import
            if (currentlyResize)
            {
                Vector3 x = (rightHand.transform.position - leftHand.transform.position);
                fscale = x.magnitude;

                if (fscale < tempscale * 0.8) fscale = tempscale;


                float v = (fscale -start/ start);
                Debug.Log(fscale);
                obj.transform.localScale += new Vector3(v, v, v);

                tempscale = fscale;

            }
            // Resize initializing parameters
            else
            {
                start = (rightHand.transform.position - leftHand.transform.position).magnitude;
                Debug.Log("start" + start);
                currentlyResize = true;
            }

        }
    }
    public void callReset()
    {

            resetColour();
            foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
            { if(gameObj.name == "GeneOrigName")
                {
                    gameObj.GetComponentInChildren<Text>().text = "";
                }
                if (gameObj.name == "NormText")
                {
                    gameObj.GetComponentInChildren<Text>().text = "";
                }
            }

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

            Vector3 playerPos = player.transform.position;
            Vector3 playerDirection = player.transform.forward;
            Quaternion playerRotation = player.transform.rotation;
            float spawnDistance = 0.5f;

            Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

            keyboard.transform.position = spawnPos;
            keyboard.transform.rotation = playerRotation;
        }
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
        if (!expand)
        {
            try
            {
                foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
                {
                    if (gameObj.name == "Slice_A" && gameObj.transform.root.name == selectModel)
                    {
                        gameObj.transform.position = new Vector3(gameObj.transform.position.x+2, gameObj.transform.position.y, gameObj.transform.position.z);
                    }
                    if (gameObj.name == "Slice_B" && gameObj.transform.root.name == selectModel)
                    {
                        gameObj.transform.position = new Vector3(gameObj.transform.position.x + 1, gameObj.transform.position.y, gameObj.transform.position.z);
                    }
                    if (gameObj.name == "Slice_D" && gameObj.transform.root.name == selectModel)
                    {
                        gameObj.transform.position = new Vector3(gameObj.transform.position.x -1, gameObj.transform.position.y, gameObj.transform.position.z);
                    }
                    if (gameObj.name == "Slice_E" && gameObj.transform.root.name == selectModel)
                    {
                        gameObj.transform.position = new Vector3(gameObj.transform.position.x - 2, gameObj.transform.position.y, gameObj.transform.position.z);
                    }
                }
            }
            catch (Exception) { }


            expand = true;
        }
        else if (expand)
        {
            try
            {
                foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
                {
                    if (gameObj.name == "Slice_A" && gameObj.transform.root.name == selectModel)
                    {
                        gameObj.transform.position = new Vector3(gameObj.transform.position.x - 2, gameObj.transform.position.y, gameObj.transform.position.z);
                    }
                    if (gameObj.name == "Slice_B" && gameObj.transform.root.name == selectModel)
                    {
                        gameObj.transform.position = new Vector3(gameObj.transform.position.x - 1, gameObj.transform.position.y, gameObj.transform.position.z);
                    }
                    if (gameObj.name == "Slice_D" && gameObj.transform.root.name == selectModel)
                    {
                        gameObj.transform.position = new Vector3(gameObj.transform.position.x + 1, gameObj.transform.position.y, gameObj.transform.position.z);
                    }
                    if (gameObj.name == "Slice_E" && gameObj.transform.root.name == selectModel)
                    {
                        gameObj.transform.position = new Vector3(gameObj.transform.position.x + 2, gameObj.transform.position.y, gameObj.transform.position.z);
                    }
                }
            }
            catch (Exception) { }

            expand = false;
        }
    }
    public void showColorbuttonBig()
    {
        switch (ColorButtonBig.activeSelf)
        {
            case (true):
                ColorButtonBig.SetActive(false);
                break;
            case (false):
                ColorButtonBig.SetActive(true);
                break;
        }
    }

    private void lerpTo(GameObject slice, Vector3 from, Vector3 to)
    {
        slice.transform.position = Vector3.Lerp(from, to, 0.1f);
    }

}
