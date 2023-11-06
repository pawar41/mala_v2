using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen_size_manager : MonoBehaviour
{

    void Start()
    {
        Debug.Log(new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, Screen.height /10));
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, Screen.height/4);

        Rect tmp = gameObject.GetComponent<RectTransform>().rect;
        tmp.size = new Vector2(0, Screen.height);
    }

    void Update()
    {
        
    }
}
