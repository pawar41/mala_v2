using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;



public class mani_move : MonoBehaviour
{
    public TextMeshProUGUI mani_count;
    public TextMeshProUGUI mala_count;

    public GameObject[] selectorArr;
    public GameObject languageTab;

    bool move_mani = false;
    float start_time;
    float duration_time = .1f;
    
    float drop_number = 15f;
    Vector3 start_position;

    Vector3 tmp_position;
    float[] floatArray; 
    Vector3 tmp_position_of_mani;

    public Material current_material;

    private static readonly string mala_prefs = "mala_prefs";
    private static readonly string mani_prefs = "mani_prefs";

    private static readonly string texture_seleted = "texture_seleted";


    public Texture[] all_images;


    public Material test_mani_material;

    void Start()
    {
        floatArray = new float[selectorArr.Length];

        if (PlayerPrefs.GetInt(mala_prefs) == 0 && PlayerPrefs.GetInt(mani_prefs) == 0)
        {
            mani_count.SetText("0");
            mala_count.SetText("0");
            //PlayerPrefs.SetInt(initial_start_prefs, -1);
        } else
        {
            mani_count.SetText(PlayerPrefs.GetInt(mani_prefs).ToString());
            mala_count.SetText(PlayerPrefs.GetInt(mala_prefs).ToString());
        }

        reset_position();
        tmp_position_of_mani = transform.position;

        //gameObject.
        //ahi.mainTexture = tex;

        current_material.mainTexture = all_images[PlayerPrefs.GetInt(texture_seleted)];
        
    }

    void test_viewer_update()
    {
        test_viewer = PlayerPrefs.GetInt(texture_seleted);
    }

    void Update()
    {
        if (move_mani)
        {
            for (int i = selectorArr.Length -1; i >= 0; i--)
            {
                tmp_position_of_mani.y = Mathf.Lerp(floatArray[i], floatArray[i] - drop_number, (Time.fixedTime - start_time)/duration_time);
                selectorArr[i].transform.position = tmp_position_of_mani;

                
                if (selectorArr[0].transform.position.y <= floatArray[i] - drop_number)
                {
                    move_mani = false;

                    tmp_position_of_mani.y = floatArray[0];
                    selectorArr[selectorArr.Length - 1].transform.position = tmp_position_of_mani;

                    update_object_numbering();
                }
            }
        }

    }

    public void save_mala_mani_count()
    {
        PlayerPrefs.SetInt(mani_prefs, Convert.ToInt32(mani_count.text));
        PlayerPrefs.SetInt(mala_prefs, Convert.ToInt32(mala_count.text));
    }

    public void increment_mala_button()
    {
        Update_mala();
        start_time = Time.fixedTime;
    }

    void Update_mala()
    {
        int current_mani_count = Convert.ToInt32(mani_count.text);
        int current_mala_count = Convert.ToInt32(mala_count.text);

        if (current_mani_count < 107)
        {
            current_mani_count++;
            mani_count.SetText(current_mani_count.ToString());
        } else
        {
            mani_count.SetText("0");

            current_mala_count++;
            mala_count.SetText(current_mala_count.ToString());
        }

        move_mani = true;
        start_position = selectorArr[0].transform.position;
        update_position_data();
    }


    void reset_position()
    {
        Vector3 tmp_position_of = selectorArr[0].transform.position;

        for (int i = 0 ; i < selectorArr.Length; i++)
        {
            tmp_position_of.y -=  drop_number;
            selectorArr[i].transform.position = tmp_position_of;
        }
    }

    void update_position_data()
    {
        for (int i = 0; i < selectorArr.Length; i++)
        {
            floatArray[i] = selectorArr[i].transform.position.y;
        }
    }

    GameObject tmp_gmo;


    void update_object_numbering()
    {
        tmp_gmo = null;

        for (int i = selectorArr.Length -1; i >= 0; i--)
        {
            if (i == selectorArr.Length -1)
            {
                tmp_gmo = selectorArr[i];

            } else
            {
                selectorArr[i+1] = selectorArr[i];
            }

            if (i == 0)
            {
                selectorArr[i] = tmp_gmo;
            }
        }
    }

    public void test_setup_mani()
    {
        test_mani_material.mainTexture = all_images[PlayerPrefs.GetInt(texture_seleted)];
    }

    int test_viewer = 0;

    public void increment_test_mani()
    {
        if(test_viewer < all_images.Length -1)
        {
            test_viewer++;
        }
        else
        {
            test_viewer = 0;
        }
        test_mani_material.mainTexture = all_images[test_viewer];
    }

    public void decrement_test_mani()
    {
        if (test_viewer > 0)
        {
            test_viewer--;
        }
        else
        {
            test_viewer = all_images.Length -1;
        }

        test_mani_material.mainTexture = all_images[test_viewer];
    }

    public void save_test_mani()
    {
        PlayerPrefs.SetInt(texture_seleted,test_viewer);
        current_material.mainTexture = all_images[test_viewer];
    }

    
}
