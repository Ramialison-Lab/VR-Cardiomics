using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Keyboard : MonoBehaviour
{

    public InputField inputfield;
    public GameObject[] keyboardButtonObjects;
    public List<Button> buttons;
    private bool initiate =false;
    private string input;
    private string buffer;
    public GameObject keyboardObject;
    private InputControl inputcontrol;

    // Update is called once per frame
    void Update()
    {
        if (initiate)
        {
            foreach (var button in buttons)
            {
               // button.onClick.AddListener(readButton);
            }

        }
        
    }

    public void wake()
    {
        keyboardButtonObjects = GameObject.FindGameObjectsWithTag("keyboard");

        for (int i = 0; i < keyboardButtonObjects.Length; i++)
        {
            buttons.Add(keyboardButtonObjects[i].GetComponent<Button>());
        }

        initiate = true;

    }

    private void task()
    {
        inputfield.text = "S";
    }

    public void readButton()
    {

        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case ("Enter"):
                keyboardObject.SetActive(false);
                break;
            case ("Clear"):
                buffer = "";
                inputfield.text = "";
                break;
            case ("Close"):
                Object.FindObjectOfType<InputControl>().enableKeyboard();
                break;
            default:
                buffer = buffer + EventSystem.current.currentSelectedGameObject.name;
                inputfield.text = buffer;
                break;
        }
        //if (EventSystem.current.currentSelectedGameObject.name == "Enter")
        //{

        //    keyboardObject.SetActive(false);
        //}
        //if (EventSystem.current.currentSelectedGameObject.name == "Clear") { 
        //    buffer = "";
        //    inputfield.text = "";
        //}
        //if (EventSystem.current.currentSelectedGameObject.name == "Close")
        //{
        //    Object.FindObjectOfType<InputControl>().enableKeyboard();
        //}
        //else if (EventSystem.current.currentSelectedGameObject.name != "Enter")
        //    {
        //        buffer = buffer + EventSystem.current.currentSelectedGameObject.name;
        //        inputfield.text = buffer;
        //    }
        
    }
}
