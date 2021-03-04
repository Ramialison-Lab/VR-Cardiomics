using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public Text deviceText;
	public GameObject settingsMenu;
	private string deviceName;
    
    // Update is called once per frame
    void Start()
    {
		deviceName = "Connected device: ";

		switch (OVRPlugin.GetSystemHeadsetType().ToString())
        {
			case ("Oculus_Quest_2"):
				deviceName += "Oculus Quest 2"; break;
			case ("Rift_S"):
				Debug.Log("here");
				deviceName += "Oculus Rift S";
				Debug.Log(deviceName);
				break;
			case ("Oculus_Link_Quest"):
				deviceName += "Oculus Link Quest"; break;
			case ("Oculus_Link_Quest_2"):
				deviceName += "Oculus Link Quest 2"; break;
			case ("Rift_DK1"):
			case ("Rift_DK2"):
			case ("Rift_CV1"):
			case ("Rift_CB"):
				deviceName += "Oculus device"; break;
        }
		Debug.Log(deviceName);
        deviceText.text = deviceName;
    }

	public void exitApplication()
    {
		Application.Quit();
    }

	public void resumeApplication()
    {
		settingsMenu.SetActive(false);

    }

	public void showOptions()
    {
		//TBD
    }
}
