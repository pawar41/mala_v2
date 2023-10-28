using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class first_init : MonoBehaviour
{
    private static readonly string initial_start_prefs = "initial_start_prefs";
    private static readonly string language_prefs = "language_prefs";

    bool is_initial_user = false;

    List<string> m_DropOptions_languages = new List<string> { "English", "हिंदी", "mandarine chinese", "Spanish" , "Arabic" , "English", "French", "Portugese", "Russian", "Japanese", "German", "chinese", "mandarine chinese", "italian" , "Turkish" };
    List<string> english_tans = new List<string> { "English", "Hindi", "mandarine chinese", "Spanish", "Arabic", "English", "French", "Portugese", "Russian", "Japanese", "German", "chinese", "mandarine chinese", "italian", "Turkish" };

    public TMP_Dropdown tmp_dropdown;

    public GameObject language_object;

    public GameObject touch_manager;

    // move to side
   

    bool slide_left = false;
    bool onlyonce = true;

    float pos_to_reach;
    float duration_to_reach = 0.5f;
    float start_move_measured;


    //delete after release
    public bool clear_prefs = false;
    //delete after release

    void Start()
    {
        if (PlayerPrefs.GetInt(initial_start_prefs) != -1 && !is_initial_user)
        {
            PlayerPrefs.SetInt(initial_start_prefs, -1);
            PlayerPrefs.SetString(language_prefs, m_DropOptions_languages[0]);

            tmp_dropdown.onValueChanged.AddListener(delegate {
                set_language();
            });


            is_initial_user = true;
            language_object.SetActive(true);
            touch_manager.SetActive(false); ;
        }
        
        





        /* delete on release
         * 
         */

        if (clear_prefs)
        {
            PlayerPrefs.DeleteAll();
        }

        /* delete on release
         * 
         */
    }

    void Update()
    {
        // setlanguage
        if (is_initial_user)
        {
            select_language();
            is_initial_user = false;
        }

        if (slide_left)
        {
            if (onlyonce)
            {
                pos_to_reach = language_object.transform.position.x;
                start_move_measured = Time.fixedTime;

                onlyonce = false;
            }
            slide_gameonject();
        }



    }


    
    void select_language()
    {
        if(tmp_dropdown == null)
        {
            Debug.LogWarning("add TMP DROPDOWN");
            return;
        }

        tmp_dropdown.ClearOptions();
        tmp_dropdown.AddOptions(m_DropOptions_languages);
    }



    void set_language(){;
        PlayerPrefs.SetString(language_prefs, english_tans[tmp_dropdown.value]);
    }

    public void next_button()
    {
        //Vector3 tmp_store = language_object.transform.position;
        //tmp_store.x -= 300;
        //language_object.transform.position = tmp_store;

        slide_left = true;
    }


    void slide_gameonject()
    {
        float x_position_tmp = Mathf.Lerp(pos_to_reach, pos_to_reach - 300f, (Time.fixedTime - start_move_measured)/ duration_to_reach);
        Vector3 tmp_v3 = language_object.transform.position;
        tmp_v3.x = x_position_tmp;

        language_object.transform.position = tmp_v3;

        if(language_object.transform.position.x <= pos_to_reach - 300f)
        {
            slide_left = false;
            language_object.SetActive(false);

            touch_manager.SetActive(true);
        }
    }
}
