using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrateToggleController : MonoBehaviour
{
    public Transform checkmark;
    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Vibrate") == 1)
            checkmark.gameObject.SetActive(true);

        else
            checkmark.gameObject.SetActive(false);
    }

    // Function called when the toggle state changes
    public void OnToggleValueChanged()
    {
        if (toggle.isOn)
        {
            // Perform actions for when the toggle is turned on
            PlayerPrefs.SetInt("Vibrate", 1);
            PlayerPrefs.Save();
        }
        else
        {
            // Perform actions for when the toggle is turned off
            PlayerPrefs.SetInt("Vibrate", 0);
            PlayerPrefs.Save();
        }
    }
}
