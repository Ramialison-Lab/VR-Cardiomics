using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    private HapticFeedbackManager hfmanager;


    void OnCollisionEnter(Collision collision)
    {

        switch (gameObject.name)
        {
            case "HandBtn":
                selectHand();
                break;

            case "DecreaseBtn":
                vibrationSetting(false);
                break;
            case "IncreaseBtn":
                vibrationSetting(true);
                break;
        }

    }

    private void vibrationSetting(bool change)
    {
        try
        {
            GameObject.Find("Detector_R").GetComponent<HapticFeedbackManager>().setVibration(change);
        }
        catch (Exception e) { }

    }

    private void selectHand()
    {
        switch (gameObject.GetComponentInChildren<Slider>().value)
        {
            case 0:
                gameObject.GetComponentInChildren<Slider>().value = 1;
                // Switched to Right Hand
                //TBD

                break;
            case 1:
                gameObject.GetComponentInChildren<Slider>().value = 0;
                // Switched to Left Hand
                //TBD
                break;
        }

    }
}
