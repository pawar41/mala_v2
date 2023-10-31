using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;

public class save_manager : MonoBehaviour
{
    string filePath;
    FileStream data_file;

    string fileContents;
    public TextMeshProUGUI mala, mani;



    public bool empty_file = false;

    void Start()
    {
        filePath = Application.persistentDataPath + "/mala_data.txt";
        check_make_file();

        if (empty_file)
        {
            reset_file();
        }

        //save_calendar_count();

        // write_file("Test");
        // Debug.Log(read_file());

        // convert from string to Datetime
        //var parsedDate = DateTime.Parse(DateTime.Now.ToString());

        /// "id,date_time,mala,mani;"
        //Debug.Log("1000000000," + DateTime.Now.ToString() + "," + "10000000000" + "," + "222" + ";");
        //string min_str = "1" + DateTime.Now.ToString() + "," + "1" + "," + "2" + ";";
        //Debug.Log(min_str.Length);
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
            string[] ret_id = data_entries_tmps[data_entries_tmps.Length - 1].Split(",");
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

    void print_file()
    {

    }

}
