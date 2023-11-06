using System;
using System.IO;
using UnityEngine;
using TMPro;

public class file_log_debug_opt : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    string filePath;

    private void Awake()
    {

        filePath = Application.persistentDataPath + "/mala_data.txt";

        if (File.Exists(filePath))
        {
            tmp.SetText(read_file());
        }
        else
        {
            tmp.SetText("No file Exist");
        }

        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (File.Exists(filePath))
        {
            tmp.SetText(read_file());
        }
        else
        {
            tmp.SetText("No file Exist");
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
}
