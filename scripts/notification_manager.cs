using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class notification_manager : MonoBehaviour
{
    // date
    public TMP_Dropdown date;
    public TMP_Dropdown month;
    public TMP_Dropdown year;


    // option
    public TextMeshProUGUI repear_options;

    // time
    public TMP_Dropdown hour;
    public TMP_Dropdown minutes;
    public TMP_Dropdown am_pm;

    // strings
    string daily_repeat = "Daily";
    string once_repeat = "Once";
    string weekly_repeat = "Weekly";

    // gameobjects
    public GameObject once_go, week_go;

    // time options
    List<string> hours_timeoptions = new List<string> { };
    List<string> minutes_timeoptions = new List<string> { };
    List<string> am_pm_timeoptions = new List<string> { "AM", "PM" };

    int current_display_set;

    List<string> date_dateOptions = new List<string> { };
    List<string> month_dateOptions = new List<string> { };
    List<string> year_dateOptions = new List<string> { };

    bool[] selected_weeks = new bool[7];
    public GameObject[] week_buttons = new GameObject[7];

    private void Start()
    {
        set_time_dropdown();
        set_content(0);
    }

    void set_content(int opt_sel)
    {
        if (opt_sel == 1)
        {
            repear_options.SetText(once_repeat);
            once_go.SetActive(true);
            week_go.SetActive(false);

            set_date_init();
        }
        else if (opt_sel == 2)
        {
            repear_options.SetText(weekly_repeat);
            once_go.SetActive(false);
            week_go.SetActive(true);
        }
        else
        {

            repear_options.SetText(daily_repeat);
            once_go.SetActive(false);
            week_go.SetActive(false);
        }

        current_display_set = opt_sel;
    }


    void set_time_dropdown()
    {
        int current_hr = 0, current_min = 0;

        DateTime current_time = DateTime.Now;

        for (int i = 1; i <= 12; i++)
        {
            if(i == current_time.Hour || i == (current_time.Hour - 12))
            {
                current_hr = i;
            }
            hours_timeoptions.Add(i.ToString());
        }

        for (int i = 1; i <= 60; i++)
        {
            if (i == current_time.Minute)
            {
                current_min = i;
            }
            minutes_timeoptions.Add(i.ToString());
        }

        hour.ClearOptions();
        hour.AddOptions(hours_timeoptions);
        hour.value = current_hr-1;

        minutes.ClearOptions();
        minutes.AddOptions(minutes_timeoptions);
        minutes.value = current_min - 1;

        am_pm.ClearOptions();
        am_pm.AddOptions(am_pm_timeoptions);
        if(current_time.Hour > 12)
        {
            am_pm.value = 1;
        } else
        {
            am_pm.value = 0;
        }
    }

    void set_date_init()
    {
        DateTime current_dt = DateTime.Now;

        int date_dt = 0, month_dt = 0, year_dt = 0;

        date_dateOptions.Clear();
        month_dateOptions.Clear();
        year_dateOptions.Clear();

        date.ClearOptions();
        month.ClearOptions();
        year.ClearOptions();

        int tmp = 0;

        for (int i = current_dt.Year ; i <= current_dt.Year + 10; i++)
        {
            year_dateOptions.Add(i.ToString());

            if(current_dt.Year == i)
            {
                year_dt = tmp;
            }
            tmp++;
        }

        for (int i = 1; i <= 12; i++)
        {
            month_dateOptions.Add(i.ToString());
            if (current_dt.Month == i)
            {
                month_dt = i-1;
            }
        }

        tmp = 0;
        for (int i = current_dt.Day; i < DateTime.DaysInMonth(current_dt.Year,current_dt.Month); i ++)
        {
            date_dateOptions.Add(i.ToString());
            if (current_dt.Day == i)
            {
                date_dt = tmp;
            }
            tmp++;
        }

        date.AddOptions(date_dateOptions);
        month.AddOptions(month_dateOptions);
        year.AddOptions(year_dateOptions);

        date.value = date_dt;
        month.value = month_dt;
        year.value = year_dt;
    }


    public void increment_notificaation_repeater()
    {
        if (current_display_set < 2)
        {
            set_content(current_display_set+= 1);
        } else
        {
            set_content(0);
        }
    }

    public void decrement_notificaation_repeater()
    {
        if (current_display_set >= 0)
        {
            set_content(current_display_set-= 1);
        }
        else
        {
            set_content(2);
        }
    }

    public void update_date_dd()
    {
        DateTime generate_date = new DateTime(int.Parse(year_dateOptions[year.value]), int.Parse(month_dateOptions[month.value]), 1);

        if(generate_date.Year == DateTime.Now.Year && generate_date.Month == DateTime.Now.Month)
        {
            return;
        }

        date_dateOptions.Clear();
        date.ClearOptions();

        int tmp = 0;
        int date_dt = 0;
        for (int i = generate_date.Day; i < DateTime.DaysInMonth(generate_date.Year, generate_date.Month); i++)
        {
            date_dateOptions.Add(i.ToString());
            if (generate_date.Day == i)
            {
                date_dt = tmp;
            }
            tmp++;
        }

        date.AddOptions(date_dateOptions);
        date.value = date_dt;
    }

    public void clicked_button_week()
    {
        GameObject atmp = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        //string clicked_weekday = atmp.transform.GetComponentInChildren<TextMeshProUGUI>().text;

        
        string weekday = atmp.name;

        
        if(weekday == "MON")
        {
            selected_weeks[0] = !selected_weeks[0];
        } else if (weekday == "TUE")
        {
            selected_weeks[1] = !selected_weeks[1];
        }
        else if (weekday == "WED")
        {
            selected_weeks[2] = !selected_weeks[2];
        }
        else if (weekday == "THU")
        {
            selected_weeks[3] = !selected_weeks[3];
        }
        else if (weekday == "FRI")
        {
            selected_weeks[4] = !selected_weeks[4];
        }
        else if (weekday == "SAT")
        {
            selected_weeks[5] = !selected_weeks[5];
        }
        else if (weekday == "SUN")
        {
            selected_weeks[6] = !selected_weeks[6];
        }

        update_colour();
    }

    void update_colour()
    {
        for (int i = 0; i < selected_weeks.Length; i++)
        {
            if (selected_weeks[i])
            {
                week_buttons[i].GetComponent<Image>().color = Color.red;
            } else
            {
                week_buttons[i].GetComponent<Image>().color = Color.white;
            }
        }
    }

    const string ACTION_SET_ALARM = "android.intent.action.SET_ALARM";
    const string EXTRA_HOUR = "android.intent.extra.alarm.HOUR";
    const string EXTRA_MINUTES = "android.intent.extra.alarm.MINUTES";
    const string EXTRA_MESSAGE = "android.intent.extra.alarm.MESSAGE";

    public void CreateAlarm(string message, int hour, int minutes)
    {
        AndroidJavaObject intentAJO = new AndroidJavaObject("android.content.Intent", ACTION_SET_ALARM);


        intentAJO.Call<AndroidJavaObject>("putExtra", EXTRA_MESSAGE, message);
        intentAJO.Call<AndroidJavaObject>("putExtra", EXTRA_HOUR, hour);
        intentAJO.Call<AndroidJavaObject>("putExtra", EXTRA_MINUTES, minutes);

        GetUnityActivity().Call("startActivity", intentAJO);
    }

    AndroidJavaObject GetUnityActivity()
    {
        AndroidJavaObject localMediaPlayer = null;

        using (AndroidJavaClass javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            using (AndroidJavaObject tmp_a = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                localMediaPlayer = new AndroidJavaObject("my/plugin/vr/ExoPlayerBridge", tmp_a);
                /*
                if (localMediaPlayer != null)
                {
                    // Do some work with your java object outside the Android UI thread
                    localMediaPlayer.Call("addSubtitles", subtitleURL);

                    currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                    {
                        // Do some work on Android UI thread
                        localMediaPlayer.Call("prepare", true);
                    }));
                }
                */
            }

            return localMediaPlayer;
        }
        /*
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        }
        */
    }

    public void alarm_data()
    {
        if (am_pm.value == 0)
        {
            Debug.Log("setting 0");
            CreateAlarm("test", int.Parse(hours_timeoptions[hour.value]), int.Parse(minutes_timeoptions[minutes.value]));
        } else
        {
            Debug.Log("setting 1");
            CreateAlarm("test", int.Parse(hours_timeoptions[hour.value]) + 12, int.Parse(minutes_timeoptions[minutes.value]));
        }
    }

    public void notify_data()
    {
        // gather data

        // create notification
    }
}
