using UnityEngine;
using UnityEngine.UI;

public class HapticFeedbackManager : MonoBehaviour
{
    public float frequency = 1f;
    public float amplitude = 1f;

    public int vibrationLevel = 100;
    public GameObject selected;

    private void Start()
    {
        frequency = amplitude = ((float)vibrationLevel / 100);
    }

    private void OnCollisionEnter(Collision collision)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
        GameObject.Find("ScriptHolder").GetComponent<InputControl>().setselection(collision.gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {

    }


    private void OnCollisionExit(Collision collision)
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }

    public void setVibration(bool change)
    {
        if (change)
        {
            if (vibrationLevel < 100) vibrationLevel += 10;
        }
        else if (!change)
        {
            if (vibrationLevel > 0) vibrationLevel -= 10;
        }

        string s = vibrationLevel.ToString() + "%";

        GameObject.Find("CurrentLevelVibration").GetComponent<Text>().text = s;

        frequency = amplitude = ((float)vibrationLevel / 100);
    }


}
