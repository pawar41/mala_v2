using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;
using System;

public class month_lister1 : MonoBehaviour
{
    public TextMeshProUGUI month_current_display, year_current_display;
    

    public GameObject[] calendar_date_elements;

    DateTime ref_date;
    string ref_date_nr = "2023-10-1";

    DateTime current_plotted;

    public TextMeshProUGUI data_string;
    string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/mala_data.txt";

        calendar_date_elements = GameObject.FindGameObjectsWithTag("calendar_element_dates");
        set_ref_date();

        plot_calendar_dup(DateTime.Now);
        plot_date_data(DateTime.Now);

        
    }

    void test_numbering()
    {
        int a = 1;
        for (int i = calendar_date_elements.Length - 1; i >= 0; i--)
        {
            calendar_date_elements[i].GetComponentInChildren<TextMeshProUGUI>().SetText(a.ToString());
            a++;
        }
    }

    void set_ref_date()
    {
        ref_date = DateTime.Parse(ref_date_nr);
    }

    public void clicked_button()
    {
        GameObject atmp = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        string rec_date = atmp.transform.GetComponentInChildren<TextMeshProUGUI>().text;

        int button_text;
        if (rec_date == null || rec_date == "" || rec_date == " " || rec_date == "  " || rec_date == "   ")
        {
            button_text = 0;
        }
        else
        {
            button_text = int.Parse(rec_date);

            string tmpaui = button_text.ToString() + " " + month_current_display.text + " " + year_current_display.text;
            DateTime gen_date = DateTime.Parse(tmpaui);

            plot_date_data(gen_date);
        }

        

        //DateTime gen_date = new DateTime(int.Parse(year_current_display.text),int.Parse(),);
        //plot_date_data();


        //month_current_display.text;
        
    }

    void plot_calendar(DateTime platting_month)
    {
        
        if(DateTime.Compare(platting_month,ref_date) < 0)
        {
            return;
        }

        DateTime todays_date_in = DateTime.Now;

        month_current_display.SetText(platting_month.ToLongDateString().Split(' ')[1]);
        year_current_display.SetText(platting_month.ToLongDateString().Split(' ')[2]);


       

        int start_block = (((int)(platting_month - ref_date).TotalDays) % 7) + 1;
        //Debug.Log("start block >> " + start_block + " || " + (((int)(platting_month - ref_date).TotalDays)) );
        empty_calendar();

        int block_ref_tmp = 1;
        int date_reference_tmp = 1;
        int days_in_month_ref = DateTime.DaysInMonth(platting_month.Year, platting_month.Month);

        for (int i = calendar_date_elements.Length - 1; i >= 0; i--)
        {
            if(block_ref_tmp == start_block)
            {
                if (date_reference_tmp <= days_in_month_ref)
                {
                    calendar_date_elements[i].GetComponentInChildren<TextMeshProUGUI>().SetText(date_reference_tmp.ToString());
                    date_reference_tmp++;
                }
            }
            else
            {
                block_ref_tmp++;
            }
        }

        for(int j = 0; j < ((start_block + days_in_month_ref) - calendar_date_elements.Length)-1; j++)
        {
            if (date_reference_tmp <= days_in_month_ref)
            {
                calendar_date_elements[(calendar_date_elements.Length - 1)- j].GetComponentInChildren<TextMeshProUGUI>().SetText(date_reference_tmp.ToString());
                date_reference_tmp++;
            }
        }

        current_plotted = platting_month;
    }

    void plot_calendar_dup(DateTime platting_month)
    {

        if (DateTime.Compare(platting_month, ref_date) < 0)
        {
            return;
        }


        month_current_display.SetText(platting_month.ToLongDateString().Split(' ')[1]);
        year_current_display.SetText(platting_month.ToLongDateString().Split(' ')[2]);

        string tmp_date_block_start = platting_month.Year.ToString() + "-" + platting_month.Month.ToString() + "-1";
        DateTime tmp_date_1 = DateTime.Parse(tmp_date_block_start);

        

        int start_block = ((int)(tmp_date_1 - ref_date).TotalDays % 7) + 1;
        empty_calendar();

        if (calendar_date_elements[0].name == "1")
        {

            int block_ref_tmp = 1;
            int date_reference_tmp = 1;
            int days_in_month_ref = DateTime.DaysInMonth(platting_month.Year, platting_month.Month);

            for (int i = 0; i < calendar_date_elements.Length ; i++)
            {
                if (block_ref_tmp == start_block)
                {
                    if (date_reference_tmp <= days_in_month_ref)
                    {
                        calendar_date_elements[i].GetComponentInChildren<TextMeshProUGUI>().SetText(date_reference_tmp.ToString());
                        date_reference_tmp++;
                    }
                }
                else
                {
                    block_ref_tmp++;
                }
            }
            // dt.DayOfWeek


            for (int j = 0; j < ((start_block + days_in_month_ref) - calendar_date_elements.Length) - 1; j++)
            {
                if (date_reference_tmp <= days_in_month_ref)
                {
                    calendar_date_elements[j].GetComponentInChildren<TextMeshProUGUI>().SetText(date_reference_tmp.ToString());
                    date_reference_tmp++;
                }
            }
            

        }
        else if (calendar_date_elements[calendar_date_elements.Length -1].name == "1")
        {
            int block_ref_tmp = 1;
            int date_reference_tmp = 1;
            int days_in_month_ref = DateTime.DaysInMonth(platting_month.Year, platting_month.Month);

            for (int i = calendar_date_elements.Length - 1; i >= 0; i--)
            {
                if (block_ref_tmp == start_block)
                {
                    if (date_reference_tmp <= days_in_month_ref)
                    {
                        calendar_date_elements[i].GetComponentInChildren<TextMeshProUGUI>().SetText(date_reference_tmp.ToString());
                        date_reference_tmp++;
                    }
                }
                else
                {
                    block_ref_tmp++;
                }
            }

            for (int j = 0; j < ((start_block + days_in_month_ref) - calendar_date_elements.Length) - 1; j++)
            {
                if (date_reference_tmp <= days_in_month_ref)
                {
                    calendar_date_elements[(calendar_date_elements.Length - 1) - j].GetComponentInChildren<TextMeshProUGUI>().SetText(date_reference_tmp.ToString());
                    date_reference_tmp++;
                }
            }
        }

        current_plotted = platting_month;
    }

    void plot_date_data(DateTime tmp)
    {
        Vector2 max_cnts = max_mala(tmp);
        string to_write = tmp.ToLongDateString() + "\n" + tmp.DayOfWeek + "\n" + max_cnts.x + "\n" + max_cnts.y;
        data_string.SetText(to_write);
    }

    string read_file()
    {
        string tmp_string;
        using (StreamReader sr = new StreamReader(filePath))
        {
            tmp_string = sr.ReadToEnd();
        }

        return (tmp_string.Replace("\n", ""));
    }

    public void increment_month_plotting()
    {
        plot_calendar_dup(current_plotted.AddMonths(1));
    }

    public void decrement_month_plotting()
    {
        plot_calendar_dup(current_plotted.AddMonths(-1));
    }

    void empty_calendar()
    {
        for (int i = calendar_date_elements.Length - 1; i >= 0; i--)
        {
            calendar_date_elements[i].GetComponentInChildren<TextMeshProUGUI>().SetText(" "); 
        }

    }

    void Update()
    {
        //max_mala(DateTime.Today);
    }


    Vector2 max_mala(DateTime tmpa)
    {
        string[] out_tmp = read_file().Split(";");
        Array.Resize(ref out_tmp, out_tmp.Length - 1);
        int mala_number = 0;
        int mani_number = 0;


        int[] all_entries = new int[out_tmp.Length];

        for (int i = 0; i < out_tmp.Length; i++)
        {
            DateTime entry_date = DateTime.Parse(out_tmp[i].Split(",")[1]);
            
            if(entry_date.Date == tmpa.Date)
            {
                mala_number += int.Parse(out_tmp[i].Split(",")[2]);
                mani_number += int.Parse(out_tmp[i].Split(",")[3]);

            }

        }

        return new Vector2(mala_number, mani_number);
    }

}
