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


    void Start()
    {
        update_settings_tag_a();
        disable_settings_a();
        
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

    void log_names()
    {
        foreach (GameObject G_Obj in settings_set_scene)
        {
            Debug.Log(G_Obj.name);
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
        int tmp_mala_count;
        int tmp_mani_count;
        mala_prev_count = Convert.ToInt32(mala_count.text);
        mani_prev_count = Convert.ToInt32(mani_count.text);
    }

    public void reset_count()
    {
        mala_count.SetText("0");
        mani_count.SetText("0");
    }
}
