using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class exit_screen_manager : MonoBehaviour
{
    public bool testMode = true;
    public GameObject exit_screen;

    void Start()
    {

    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android || testMode)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
            {
                exit_screen.SetActive(true);
            }
        }
    }

    public void exit_app()
    {
        Application.Quit();
    }
}
