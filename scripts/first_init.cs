using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class first_init : MonoBehaviour
{
    private static readonly string initial_start_prefs = "initial_start_prefs";
    private static readonly string language_prefs = "language_prefs";
    private static readonly string language_prefs_int = "language_prefs_int";


    private static readonly string texture_seleted = "texture_seleted";
    



    bool is_initial_user = false;

    List<string> m_DropOptions_languages = new List<string> { "English", "日本語", "中国人", "हिंदी", "русский", "한국인", "Deutsch", "Español", "Português", "bahasa Indonesia" };
    List<string> english_tans = new List<string> { "English", "Japanese", "Chinese", "Hindi", "Russian", "Korean", "German", "Spanish", "Portuguese", "Indonesian" };

    public TMP_Dropdown tmp_dropdown;

    public GameObject language_object;

    //public GameObject touch_manager;

    // move to side
   

    bool slide_left = false;
    bool onlyonce = true;

    float pos_to_reach;
    float duration_to_reach = 0.5f;
    float start_move_measured;


    //delete after release
    public bool clear_prefs = false;
    //delete after release

    public GameObject user_guide;
    bool next_ug_active = false;

    void Start()
    {

        if (PlayerPrefs.GetInt(initial_start_prefs) != -1 && !is_initial_user)
        {
            PlayerPrefs.SetInt(initial_start_prefs, -1);
            PlayerPrefs.SetString(language_prefs, m_DropOptions_languages[0]);
            PlayerPrefs.SetInt(language_prefs_int, 0);

            tmp_dropdown.onValueChanged.AddListener(delegate {
                set_language();
            });


            is_initial_user = true;
            language_object.SetActive(true);

            PlayerPrefs.SetInt(texture_seleted,0);
        }


        if (is_initial_user)
        {
            select_language();
            next_ug_active = true;
            is_initial_user = false;
        }


        if(PlayerPrefs.GetString(language_prefs) == "" || PlayerPrefs.GetString(language_prefs) == " " || PlayerPrefs.GetString(language_prefs) == null)
        {
            PlayerPrefs.SetString(language_prefs, m_DropOptions_languages[0]);
            PlayerPrefs.SetInt(language_prefs_int, 0);
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

    public void launch_donate_site()
    {
        Application.OpenURL("https://pawar41.github.io/pawar41/");
    }

    void Update()
    {

    }

    private void Awake()
    {
        select_language();
    }


    public void select_language()
    {
        if(tmp_dropdown == null)
        {
            Debug.LogWarning("add TMP DROPDOWN");
            return;
        }

        tmp_dropdown.ClearOptions();
        tmp_dropdown.AddOptions(m_DropOptions_languages);
    }



    public void set_language(){;
        PlayerPrefs.SetString(language_prefs, english_tans[tmp_dropdown.value]);
        PlayerPrefs.SetInt(language_prefs_int, tmp_dropdown.value);
    }

    public void next_button()
    {
        set_language();
        if (user_guide != null && next_ug_active)
        {
            user_guide.SetActive(true);
            next_ug_active = false;
        }
    }

    string selected_lang_tmp = "";

    public void SetLangTmp(int lang_to_select)
    {
        selected_lang_tmp = m_DropOptions_languages[lang_to_select];
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

            //touch_manager.SetActive(true);
        }
    }
}
