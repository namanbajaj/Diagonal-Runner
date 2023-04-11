using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public static BackgroundLoop instance;

    public AudioSource music;

    private void Awake()
    {
        //if (instance == null)
        //    instance = this;
        //else if (instance != this)
        //{
        //    //Destroy(gameObject);
        //}

        //DontDestroyOnLoad(gameObject);

        //if (PlayerPrefs.GetInt("Music") == 1)
        //    music.Play();
    }

}
