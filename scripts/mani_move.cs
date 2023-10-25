using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class mani_move : MonoBehaviour
{
    public TextMeshProUGUI mani_count;
    public TextMeshProUGUI mala_count;

    public GameObject[] selectorArr;


    bool move_mani = false;
    float start_time;
    float duration_time = .1f;

    float drop_number = 275f;
    Vector3 start_position;

    Vector3 tmp_position;
    float[] floatArray = new float[9];
    Vector3 tmp_position_of_mani;

    void Start()
    {
        // 403.76
        mani_count.SetText("0");
        mala_count.SetText("0");

        reset_position();
        tmp_position_of_mani = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Ended)
            {
                Update_mala();
                start_time = Time.fixedTime;
            }
        }

        if (move_mani)
        {
            for (int i = selectorArr.Length -1; i >= 0; i--)
            {
                tmp_position_of_mani.y = Mathf.Lerp(floatArray[i], floatArray[i] - drop_number, (Time.fixedTime - start_time)/duration_time);
                selectorArr[i].transform.position = tmp_position_of_mani;

                //Debug.Log(object_position + " | " + (object_position - drop_number) + " >> " + selectorArr[i].name);

                if (selectorArr[0].transform.position.y <= floatArray[i] - drop_number)
                {
                    move_mani = false;

                    tmp_position_of_mani.y = floatArray[0];
                    selectorArr[selectorArr.Length - 1].transform.position = tmp_position_of_mani;

                    update_object_numbering();
                }
            }




        }

    }

    void Update_mala()
    {
        int current_mani_count = Convert.ToInt32(mani_count.text);
        int current_mala_count = Convert.ToInt32(mala_count.text);

        if (current_mani_count < 108)
        {
            current_mani_count++;
            mani_count.SetText(current_mani_count.ToString());
        } else
        {
            mani_count.SetText("1");

            current_mala_count++;
            mala_count.SetText(current_mala_count.ToString());
        }

        move_mani = true;
        start_position = selectorArr[0].transform.position;
        update_position_data();
    }


    void reset_position()
    {
        Vector3 tmp_position_of = selectorArr[0].transform.position;

        for (int i = 0 ; i < selectorArr.Length; i++)
        {
            tmp_position_of.y -=  275f;
            selectorArr[i].transform.position = tmp_position_of;
        }
    }

    void update_position_data()
    {
        for (int i = 0; i < selectorArr.Length; i++)
        {
            floatArray[i] = selectorArr[i].transform.position.y;
        }
    }

    GameObject tmp_gmo;

    void update_object_numbering()
    {
        for (int i = 0; i < selectorArr.Length; i++)
        {
            if (i != selectorArr.Length -1)
            {
                tmp_gmo = selectorArr[i + 1];
                selectorArr[i + 1] = selectorArr[i];
            } else
            {
                selectorArr[0] = tmp_gmo;
            }
            //floatArray[i] = selectorArr[i].transform.position.y;
        }
    }
}
