using System.Collections;
using System.IO;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class month_lister1 : MonoBehaviour
{
    private static readonly string language_prefs_int = "language_prefs_int";
    private static readonly string month_active_pref = "month_active_pref";


    public TextMeshProUGUI month_current_display, year_current_display;
    

    public GameObject[] calendar_date_elements;

    DateTime ref_date;
    string ref_date_nr = "2023-10-1";

    DateTime current_plotted;

    public TextMeshProUGUI data_string;
    string filePath;

    // "English", "Japanese", "Chinese", "Hindi", "Russian", "Korean", "German", "Spanish", "Portuguese", "Indonesian"

    string[] english_months = new string[]{ "January","February","March","April","May","June","July","August","September","October","November","December"};
    string[] japnese_months = new string[] { "1月", "2月", "行進", "4月", "5月", "六月", "7月", "8月", "9月", "10月", "11月", "12月" };
    string[] chinese_months = new string[] { "一月", "二月", "行进", "四月", "可能", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月" };
    string[] hindi_months = new string[] { "जनवरी", "फ़रवरी", "मार्च", "अप्रैल", "मई", "जून", "जुलाई", "अगस्त", "सितम्बर", "अक्टूबर", "नवंबर", "दिसंबर" };
    string[] russian_months = new string[] { "январь", "февраль", "Маршировать", "апрель", "Может", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "ноябрь", "Декабрь" };
    string[] Korean_months = new string[] { "1월", "2월", "3월", "4월", "5월", "6월", "칠월", "팔월", "구월", "십월", "십일월", "12월" };
    string[] German_months = new string[] { "Januar", "Februar", "Marsch", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember" };
    string[] Spanish_months = new string[] { "Enero", "Febrero", "Marzo", "Abril", "Puede", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
    string[] Portuguese_months = new string[] { "Janeiro", "Fevereiro", "Marchar", "abril", "Poderia", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "novembro", "dezembro" };
    string[] Indonesian_months = new string[] { "Januari", "Februari", "Berbaris", "April", "Mungkin", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" };


    string[] English_weeks = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    string[] Japanese_weeks = new string[] { "月曜日", "火曜日", "水曜日", "木曜日", "金曜日", "土曜日", "日曜日" };
    string[] Chinese_weeks = new string[] { "周一", "周二", "周三", "周四", "星期五", "周六", "星期日" };
    string[] Hindi_weeks = new string[] { "सोमवार", "मंगलवार", "बुधवार", "गुरुवार", "शुक्रवार", "शनिवार", "रविवार" };
    string[] Russian_weeks = new string[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

    string[] Korean_weeks = new string[] { "월요일", "화요일", "수요일", "목요일", "금요일", "토요일", "일요일" };
    string[] German_weeks = new string[] { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };
    string[] Spanish_weeks = new string[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
    string[] Portuguese_weeks = new string[] { "Segunda-feira", "Terça-feira", "Quarta-feira", "Quinta-feira", "Sexta-feira", "Sábado", "Domingo" };
    string[] Indonesian_weeks = new string[] { "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu", "Minggu" };







    string language_month_maker(int month_num)
    {
        // starts from 0
        int lang_selected = PlayerPrefs.GetInt(language_prefs_int);
        string[] lang_string;


        switch (lang_selected)
        {
            case 1:
                {
                    lang_string = japnese_months;
                    break;
                }
            case 2:
                {
                    lang_string = chinese_months;
                    break;
                }
            case 3:
                {
                    lang_string = hindi_months;
                    break;
                }
            case 4:
                {
                    lang_string = russian_months;
                    break;
                }
            case 5:
                {
                    lang_string = Korean_months;
                    break;
                }
            case 6:
                {
                    lang_string = German_months;
                    break;
                }
            case 7:
                {
                    lang_string = Spanish_months;
                    break;
                }
            case 8:
                {
                    lang_string = Portuguese_months;
                    break;
                }
            case 9:
                {
                    lang_string = Indonesian_months;
                    break;
                }
            default:
                {
                    lang_string = english_months;
                    break;
                }
        }

        return lang_string[month_num-1];
    }




    string language_week_maker(int week_day)
    {
        // starts from 0
        int lang_selected = PlayerPrefs.GetInt(language_prefs_int);
        string[] lang_string;


        switch (lang_selected)
        {
            case 1:
                {
                    lang_string = Japanese_weeks;
                    break;
                }
            case 2:
                {
                    lang_string = Chinese_weeks;
                    break;
                }
            case 3:
                {
                    lang_string = Hindi_weeks;
                    break;
                }
            case 4:
                {
                    lang_string = Russian_weeks;
                    break;
                }
            case 5:
                {
                    lang_string = Korean_weeks;
                    break;
                }
            case 6:
                {
                    lang_string = German_weeks;
                    break;
                }
            case 7:
                {
                    lang_string = Spanish_weeks;
                    break;
                }
            case 8:
                {
                    lang_string = Portuguese_weeks;
                    break;
                }
            case 9:
                {
                    lang_string = Indonesian_weeks;
                    break;
                }
            default:
                {
                    lang_string = English_weeks;
                    break;
                }
        }

        return lang_string[week_day];
    }




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


    public void clicked_button_sound()
    {
        GameObject atmp = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        TextMeshProUGUI rec_date_tmp = atmp.transform.GetComponentInChildren<TextMeshProUGUI>();
        string rec_date = rec_date_tmp.text;
    }



    Image old_image = null;
    TextMeshProUGUI old_tmp= null;

    public void clicked_button()
    {
        Image bgma = null;
        GameObject atmp = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        TextMeshProUGUI rec_date_tmp = atmp.transform.GetComponentInChildren<TextMeshProUGUI>();
        string rec_date = rec_date_tmp.text;



        if (atmp.transform.GetChild(0).name == "Image")
        {
            bgma = atmp.transform.GetChild(0).GetComponentInChildren<Image>();
        }
        else
        {
             bgma = atmp.transform.GetChild(1).GetComponentInChildren<Image>();
        }
        
        ColorUtility.TryParseHtmlString("#0E8BAD", out Color default_bg_color);
        ColorUtility.TryParseHtmlString("#F6F1F1", out Color shift_bg_color);

        ColorUtility.TryParseHtmlString("#146C94", out Color text_colour);

        int button_text;
        if (rec_date == null || rec_date == "" || rec_date == " " || rec_date == "  " || rec_date == "   ")
        {
            button_text = 0;
        }
        else
        {
            button_text = int.Parse(rec_date);
            string tmpaui;

            int tmp_pref = PlayerPrefs.GetInt(month_active_pref);
            if (tmp_pref == 0)
            {
                tmpaui = button_text.ToString() + " " + english_months[tmp_pref] + " " + year_current_display.text;
            } else
            {
                tmpaui = button_text.ToString() + " " + english_months[tmp_pref -1] + " " + year_current_display.text;
            }
            
            DateTime gen_date = DateTime.Parse(tmpaui);
            plot_date_data(gen_date);


            if (bgma != null)
            {
                bgma.color = shift_bg_color;
            }


            if(old_image != null)
            {
                old_image.color = default_bg_color;
            }

            if(old_tmp != null)
            {
                old_tmp.color = shift_bg_color;
            }

            old_image = bgma;
            old_tmp = rec_date_tmp;
            rec_date_tmp.color = text_colour;
        }

    }

    public void reset_click_colour()
    {
        ColorUtility.TryParseHtmlString("#0E8BAD", out Color default_bg_color);
        if(old_image != null)
        {
            old_image.color = default_bg_color;

        }
    }

    

    void plot_calendar(DateTime platting_month)
    {
        
        if(DateTime.Compare(platting_month,ref_date) < 0)
        {
            return;
        }

        DateTime todays_date_in = DateTime.Now;

        
        


       

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


        month_current_display.SetText(language_month_maker(platting_month.Month));
        PlayerPrefs.SetInt(month_active_pref, platting_month.Month);
        year_current_display.SetText(platting_month.Year.ToString());

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
        string to_write = tmp.ToShortDateString() + "\n" + language_week_maker((int)tmp.DayOfWeek) + "\n" + max_cnts.x + "\n" + max_cnts.y;
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


    public void reset_all_imgs()
    {

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
