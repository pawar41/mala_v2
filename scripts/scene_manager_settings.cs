using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class scene_manager_settings : MonoBehaviour
{
    GameObject[] settings_set_scene;

    int mala_prev_count;
    int mani_prev_count;

    public TextMeshProUGUI mani_count;
    public TextMeshProUGUI mala_count;

    public GameObject /* settings */ menues;

    void Start()
    {
        //settings.SetActive(false);
        menues.SetActive(false);

    }

    void Update()
    {
        
    }

    void update_settings_tag_a()
    {
        settings_set_scene = GameObject.FindGameObjectsWithTag("setting_buttons_a");
        
    }

    public void disable_settings_a()
    {
        foreach (GameObject G_Obj in settings_set_scene)
        {
            G_Obj.SetActive(false);
        }
    }

    public void enable_settings_a()
    {
        foreach (GameObject G_Obj in settings_set_scene)
        {
            G_Obj.SetActive(true);
        }
    }

    public void recover_count()
    {
        mani_count.SetText(mani_prev_count.ToString());
        mala_count.SetText(mala_prev_count.ToString());

    }

    public void secure_count()
    {
        mala_prev_count = Convert.ToInt32(mala_count.text);
        mani_prev_count = Convert.ToInt32(mani_count.text);
    }

    public void decrement_count()
    {
        mala_prev_count = Convert.ToInt32(mala_count.text);
        mani_prev_count = Convert.ToInt32(mani_count.text);
    }

    public void reset_count()
    {
        mala_count.SetText("0");
        mani_count.SetText("0");
    }

    public void imcrement_mala_only()
    {
        int tmp_mala_count = Convert.ToInt32(mala_count.text);
        mala_count.SetText((tmp_mala_count +1).ToString());
    }
}
