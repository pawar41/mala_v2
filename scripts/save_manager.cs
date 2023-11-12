using System;
using System.IO;
using TMPro;
using UnityEngine;

public class save_manager : MonoBehaviour
{
    private static readonly string language_prefs_int = "language_prefs_int";

    private static readonly string month_active_pref = "month_active_pref";
    string[] english_months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    string filePath;
    FileStream data_file;

    string fileContents;
    public TextMeshProUGUI mala, mani;


    public bool empty_file = false;
    public TextMeshProUGUI warning_text, warning_caption;

    public TextMeshProUGUI month_text, year_text;
    public GameObject Image_to_get, bar_to_get;
    RectTransform rt;


    public TextMeshProUGUI month_days_count, mala_counts;

    public GameObject calendar_graph;
    public GameObject image_load;

    void Start()
    {
        filePath = Application.persistentDataPath + "/mala_data.txt";
        check_make_file();

        if (empty_file)
        {
            reset_file();
        }

        rt = Image_to_get.GetComponent<RectTransform>();

        image_load.SetActive(false);
    }

    public void delete_file()
    {
        reset_file();
    }

    public void save_calendar_count()
    {
        string old_data = read_file();
        string new_data;


        if (old_data.Length < 20 || (old_data == "") || (old_data == " "))
        {
            new_data = "1," + DateTime.Now.ToString() + "," + int.Parse(mala.text).ToString() + "," + int.Parse(mani.text).ToString() + ";";
        } else
        {
            new_data = old_data + get_id_data(old_data).ToString() + "," + DateTime.Now.ToString() + "," + int.Parse(mala.text).ToString() + "," + int.Parse(mani.text).ToString() + ";";
        }
        write_file(new_data);
    }

    int get_id_data(string old_data_to_read)
    {
        if (old_data_to_read.Length < 20 || (old_data_to_read == "") || (old_data_to_read == " "))
        {
            return 1;
        }

        string[] data_entries_tmps = old_data_to_read.Split(";");

        if (data_entries_tmps.Length < 1)
        {
            return 1;
        }
        else
        {
            string[] ret_id = data_entries_tmps[data_entries_tmps.Length - 2].Split(",");
            return (int.Parse(ret_id[0]) + 1);
        }
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

    void write_file(string str_to_write)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            sw.WriteLine(str_to_write);
        }
    }

    int tmp_i = 0;

    void Update()
    {

    }




    void check_make_file()
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        } else
        {
            if (read_file().Length < 20)
            {
                reset_file();
            }
        }


    }

    void reset_file()
    {
        write_file("");
    }

    /*
        English — USA, UK, Australia, Canada
        Japanese — Japan
        Simplified Chinese — Mainland China, Taiwan, Hong Kong
        Hindi — India
        Russian — Russia
        Korean — South Korea
        German — Germany
        Spanish — Mexico, Argentina
        Portuguese — Brazil
        Indonesian — I
    */

    string[] warning_message = new string[] { "All counts are resseted to 0", "すべてのカウントが 0 にリセットされます", "所有计数重置为 0", "सभी गणनाएँ 0 पर पुनः निर्धारित की गई हैं", "Все счетчики сбрасываются на 0.", "모든 카운트가 0으로 재설정됩니다.", "Alle Zählwerte werden auf 0 zurückgesetzt", "Todos los recuentos se restablecen a 0", "Todas as contagens são redefinidas para 0", "Semua hitungan diatur ulang ke 0" };
    string[] warning_message_cap = new string[] { "\n\n jaap-mala count is \"0\" and beads count is \"0\" \n\n", "\n\n jaap-mala カウントは「0」に設定され、ビーズ カウントは「0」に設定されます。 \n\n", "\n\n jaap-mala 计数设置为“0”并且珠子计数设置为“0”。 \n\n", "\n\n जाप-माला की गिनती \"0\" पर और मोतियों की गिनती \"0\" पर सेट है। \n\n", "\n\n Количество jaap-mala установлено на «0», а количество бусин установлено на «0». \n\n", "\n\n jaap-mala 개수는 \"0\"으로 설정되고 구슬 개수는 \"0\"으로 설정됩니다. \n\n", "\n\n Die Jaap-Mala-Anzahl ist auf „0“ und die Perlenanzahl ist auf „0“ gesetzt. \n\n", "\n\n El recuento de jaap-mala se establece en \"0\" y el recuento de cuentas se establece en \"0\". \n\n", "\n\n a contagem de jaap-mala está definida como \"0\" e a contagem de contas está definida como \"0\". \n\n", "\n\n hitungan jaap-mala disetel ke \"0\" dan hitungan manik disetel ke \"0\". \n\n" };

    public void resettted_count_warning()
    {
        int lang_set = PlayerPrefs.GetInt(language_prefs_int);

        warning_text.SetText(warning_message[lang_set]);
        warning_caption.SetText(warning_message_cap[lang_set]);
    }


    string[] entry_saved_message = new string[] { "Entry saved !", "データエントリが保存されました", "数据输入已保存", "डेटा प्रविष्टि सहेजी गई", "Запись данных сохранена", "데이터 항목이 저장되었습니다.", "Dateneingabe gespeichert", "Entrada de datos guardada", "Entrada de dados salva", "Entri data disimpan" };
    string[] entry_saved_caption = new string[] { "You can view your dat entries by clicking calendar icon.", "カレンダーアイコンをクリックすると、データエントリを表示できます。", "您可以通过单击日历图标来查看数据条目。", "आप कैलेंडर आइकन पर क्लिक करके अपनी डेटा प्रविष्टियाँ देख सकते हैं।", "Вы можете просмотреть свои записи данных, щелкнув значок календаря.", "달력 아이콘을 클릭하면 날짜 항목을 볼 수 있습니다.", "Sie können Ihre Dateneinträge anzeigen, indem Sie auf das Kalendersymbol klicken.", "Puede ver sus entradas de datos haciendo clic en el icono de calendario.", "Você pode visualizar suas entradas de dados clicando no ícone do calendário.", "Anda dapat melihat entri data Anda dengan mengklik ikon kalender." };

    public void entry_saved_warning()
    {
        int lang_set = PlayerPrefs.GetInt(language_prefs_int);

        warning_text.SetText(entry_saved_message[lang_set]);
        warning_caption.SetText(entry_saved_caption[lang_set]);
    }

    string[] count_saved_message = new string[] { "counting saved", "保存されたものを数えています", "计数已保存", "गिनती सहेजी गई", "подсчет сохраненных", "계산이 저장되었습니다", "Zählung gespeichert", "Contando guardado", "contagem salva", "menghitung disimpan" };
    string[] count_saved_caption = new string[] { "On starting app, jaap-mala counting and beads counting will be equal to currently saved counting.", "アプリを起動すると、jaap-mala のカウントとビーズのカウントは現在保存されているカウントと同じになります。", "启动应用程序时，jaap-mala 计数和珠子计数将等于当前保存的计数。", "ऐप शुरू करने पर, जाप-माला गिनती और मोतियों की गिनती वर्तमान में सहेजी गई गिनती के बराबर होगी।", "При запуске приложения подсчет джаап-мала и подсчет бус будет равен текущему сохраненному подсчету.", "앱 시작 시 잡말라 세기와 구슬 세기는 현재 저장된 세기와 동일합니다.", "Beim Starten der App entsprechen die Jaap-Mala-Zählung und die Perlenzählung der aktuell gespeicherten Zählung.", "Al iniciar la aplicación, el conteo de jaap-mala y el conteo de cuentas serán iguales al conteo guardado actualmente.", "Ao iniciar o aplicativo, a contagem de jaap-mala e de contas será igual à contagem salva no momento.", "Saat memulai aplikasi, penghitungan jaap-mala dan penghitungan manik-manik akan sama dengan penghitungan yang disimpan saat ini." };

    public void count_saved_warning()
    {
        int lang_set = PlayerPrefs.GetInt(language_prefs_int);

        warning_text.SetText(count_saved_message[lang_set]);
        warning_caption.SetText(count_saved_caption[lang_set]);
    }

    GameObject[] bar_objects = new GameObject[60];

    public void plot_graph()
    {
        empty_graph();

        int month_curr = PlayerPrefs.GetInt(month_active_pref);
        string graph_date;
        if (month_curr != 0)
        {
            graph_date = "01 " + english_months[month_curr - 1] + " " + year_text.text;
        } else
        {
            graph_date = "01 " + english_months[month_curr] + " " + year_text.text;
        }
        
        DateTime dt_graph_date = DateTime.Parse(graph_date);

        int days_in_month = DateTime.DaysInMonth(dt_graph_date.Year, dt_graph_date.Month);
        int max_count_in_month = extract_data_malas_max();

        float width_parent = rt.rect.width;
        float height_parent = rt.rect.height;

        float bar_width = width_parent / days_in_month;
        float bar_height = height_parent / max_count_in_month;


        for (int i = 0;i < days_in_month; i++)
        {
            bar_objects[i] = Instantiate(bar_to_get, bar_to_get.transform.parent);
            RectTransform tmp_rect_trans = bar_objects[i].GetComponent<RectTransform>();


            float bar_height_child = find_height_block(new DateTime(dt_graph_date.Year, dt_graph_date.Month, i + 1));

            bar_height_child *= bar_height;
            tmp_rect_trans.sizeDelta = new Vector2(bar_width, bar_height_child);

            
            // position
            tmp_rect_trans.anchoredPosition = new Vector2(bar_width/2 + (bar_width * i), bar_height_child/2);

            

        }

        month_days_count.SetText(days_in_month.ToString());
        mala_counts.SetText(max_count_in_month.ToString());
    }

    public void reset_all()
    {
        PlayerPrefs.DeleteAll();
    }

    int find_height_block(DateTime date_needed)
    {
        string[] out_tmp = read_file().Split(";");
        Array.Resize(ref out_tmp, out_tmp.Length - 1);

        int max_count = 0;

        for (int i = 0; i < out_tmp.Length; i++)
        {
            DateTime tmp_date = DateTime.Parse(out_tmp[i].Split(",")[1]);

            if(tmp_date.Date == date_needed.Date)
            {
                max_count += int.Parse(out_tmp[i].Split(",")[2]) + int.Parse(out_tmp[i].Split(",")[3]);
            }
        }

        return max_count;
    }

    void empty_graph()
    {
        for(int i = 0; i < bar_objects.Length; i++)
        {
            if(bar_objects[i] != null)
                Destroy(bar_objects[i]);
        }

        month_days_count.SetText("");
        mala_counts.SetText("");
    }

    int extract_data_malas_max()
    {
        string[] out_tmp = read_file().Split(";");
        Array.Resize(ref out_tmp, out_tmp.Length -1);
        int large_array_num = 0;

        int[] all_entries = new int[out_tmp.Length];

        for(int i = 0; i < out_tmp.Length; i++)
        {
            DateTime entry_date = DateTime.Parse(out_tmp[i].Split(",")[1]);

            for(int j = 0; j < out_tmp.Length; j++)
            {
                DateTime tmp_entry_date = DateTime.Parse(out_tmp[j].Split(",")[1]) ;
                if (tmp_entry_date.Date == entry_date.Date)
                {
                    all_entries[i] += int.Parse(out_tmp[j].Split(",")[2]) + int.Parse(out_tmp[j].Split(",")[3]);
                }
            }
        }

        for(int k = 0; k < out_tmp.Length; k++)
        {
            if(all_entries[k] > large_array_num)
            {
                large_array_num = all_entries[k];
            }
            
        }

        return large_array_num;
    }
}
