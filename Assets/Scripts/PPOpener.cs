using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPOpener : MonoBehaviour
{
    public Button PP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Application.OpenURL("https://sites.google.com/view/mini-tennis-policy-privacy/home");
    }
}
