using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class month_lister1 : MonoBehaviour
{
    public TextMeshProUGUI month_current_display, year_current_display;
    

    public GameObject[] calendar_date_elements;

    DateTime ref_date;
    string ref_date_nr = "2023-10-1";

    // // // delete after release
    public bool test_mode = false;
    DateTime current_plotted;

    void Start()
    {
        calendar_date_elements = GameObject.FindGameObjectsWithTag("calendar_element_dates");
        set_ref_date();

        plot_calendar(DateTime.Now);

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

    

    void plot_calendar(DateTime platting_month)
    {
        
        if(DateTime.Compare(platting_month,ref_date) < 0)
        {
            return;
        }

        DateTime todays_date_in = DateTime.Now;

        month_current_display.SetText(platting_month.ToLongDateString().Split(' ')[1]);
        year_current_display.SetText(platting_month.ToLongDateString().Split(' ')[2]);


        if (test_mode)
        {
            todays_date_in = todays_date_in.AddMonths(3);
        }

        int start_block = (((int)(platting_month - ref_date).TotalDays) % 7) + 1;
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

    public void increment_month_plotting()
    {
        plot_calendar(current_plotted.AddMonths(1));
    }

    public void decrement_month_plotting()
    {
        plot_calendar(current_plotted.AddMonths(-1));
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
        
    }
}
