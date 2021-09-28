using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    public InputField inputfield;
    public GameObject[] keyboardButtonObjects;
    public List<Button> buttons;
    private string buffer;
    public GameObject keyboardObject;

    public void wake()
    {
        keyboardButtonObjects = GameObject.FindGameObjectsWithTag("keyboard");
        for (int i = 0; i < keyboardButtonObjects.Length; i++)
        {
            buttons.Add(keyboardButtonObjects[i].GetComponent<Button>());
        }
    }
    public void readButton()
    {
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case ("Enter"):
                keyboardObject.SetActive(false);
                break;
            case ("Clear"):
                inputfield.text = buffer = "";
                break;
            case ("Close"):
                Object.FindObjectOfType<InputControl>().enableKeyboard();
                break;
            case ("Backspace"):
                buffer = buffer.Substring(1);
                inputfield.text = buffer;
                break;
            default:
                buffer = buffer + EventSystem.current.currentSelectedGameObject.name;
                inputfield.text = buffer;
                break;
        }
    }


    public void touchInput(string input)
    {
        switch (input)
        {
            case ("Enter"):
                keyboardObject.SetActive(false);
                break;
            case ("Clear"):
                inputfield.text = buffer = "";
                break;
            case ("Close"):
                Object.FindObjectOfType<InputControl>().enableKeyboard();
                break;
            case ("Backspace"):
                inputfield.text = buffer = buffer.Remove(buffer.Length - 1);
                break;
            default:
                buffer = buffer + input;
                inputfield.text = buffer;
                break;
        }
    }
    public void keyboardReset()
    {
        inputfield.text = buffer = "";
    }

}
