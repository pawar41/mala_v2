using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch_dev : MonoBehaviour
{
    string site_url = "https://pawar41.github.io/pawar41/";

    public void launch_url()
    {
        Application.OpenURL(site_url);
    }
    private void Start()
    {
        
    }
}
