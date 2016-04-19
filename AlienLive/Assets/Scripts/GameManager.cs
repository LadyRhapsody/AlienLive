using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private int year;
    private int month;
    private int day;
    private int hour;
    private int minute;
    private bool timePass;

    private Text timeText;

    

    

	// Use this for initialization
	void Start () {
        year = 1;
        month = 1;
        day = 1;
        hour = 6;
        minute = 0;
        timePass = true;

        Init();
	}

    private void Init()
    {
        timeText = GameObject.FindWithTag("Timetext").GetComponent<Text>(); ;

        if (minute == 0)
        {
            timeText.text = "Year: " + year + "  Month: " + month + "\n" + hour + ":" + minute + "0";
        }
        else
            timeText.text = "Year: " + year + "  Month: " + month + "\n" + hour + ":" + minute;
        if (timePass)
        {
            InvokeRepeating("UpdateTime", 1, 2);
        }
    }

    // Update is called once per frame
    void Update () {
       
	}



    void UpdateTime()
    {
        minute += 1;
        if (minute == 60)
        {
            hour += 1;
            minute = 0;
        }

        if(hour == 24)
        {
            day += 1;
        }
        if(minute%10 == 0)
        {
            if(minute == 0)
            {
                timeText.text = "Year: " + year + "  Month: " + month + "\n" + hour + ":" + minute+"0";
            }else
            timeText.text = "Year: " + year + "  Month: " + month + "\n" + hour + ":" + minute;

        }
        Debug.Log(hour + ":" + minute);
    }

    public int GetHour()
    {
        return hour;
    }
    public int GetMinuit()
    {
        return minute;
    }
}
