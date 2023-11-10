using System;
using System.IO;
using TMPro;
using UnityEngine;

public class save_manager : MonoBehaviour
{
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


    void Start()
    {
        filePath = Application.persistentDataPath + "/mala_data.txt";
        check_make_file();

        if (empty_file)
        {
            reset_file();
        }

        rt = Image_to_get.GetComponent<RectTransform>();

        //save_calendar_count();

        // write_file("Test");
        // Debug.Log(read_file());

        // convert from string to Datetime
        //var parsedDate = DateTime.Parse(DateTime.Now.ToString());
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
        if(old_data_to_read.Length < 20 || (old_data_to_read == "") || (old_data_to_read == " "))
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
            if(read_file().Length < 20)
            {
                reset_file();
            }
        }

        
    }

    void reset_file()
    {
        write_file("");
    }

    public void resettted_count_warning()
    {
        warning_text.SetText("All count resseted to 0");
        warning_caption.SetText("\n\nMala count = 0 & mani count = 0\n\n");
    }

    public void entry_saved_warning()
    {
        warning_text.SetText("Entry saved !");
        warning_caption.SetText("You can view your entries in Calendar.");
    }

    public void count_saved_warning()
    {
        warning_text.SetText("count saved!");
        warning_caption.SetText("On app start, mala & mani count will be wqual to saved.");
    }

    GameObject[] bar_objects = new GameObject[60];

    public void plot_graph()
    {
        empty_graph();

        string graph_date = "01 " + month_text.text + " " + year_text.text;
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
        Debug.Log("deleted " + Time.fixedTime);
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
