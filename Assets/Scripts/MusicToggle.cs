using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public Transform checkmark;
    public Toggle toggle;

    public BackgroundLoop loop;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            checkmark.gameObject.SetActive(true);
            music.Play();
        }

        else
        {
            checkmark.gameObject.SetActive(false);
            music.Stop();
        }
    }

    // Function called when the toggle state changes
    public void OnToggleValueChanged()
    {
        if (toggle.isOn)
        {
            // Perform actions for when the toggle is turned on
            PlayerPrefs.SetInt("Music", 1);
            PlayerPrefs.Save();
            //loop.gameObject.SetActive(true);
            music.Play();
        }
        else
        {
            // Perform actions for when the toggle is turned off
            PlayerPrefs.SetInt("Music", 0);
            PlayerPrefs.Save();
            //loop.gameObject.SetActive(false);
            music.Stop();
        }
    }
}
