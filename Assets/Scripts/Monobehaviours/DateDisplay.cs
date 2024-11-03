using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DateDisplay : MonoBehaviour
{
    public static DateTime curDate = DateTime.Today;
    private TMP_Text display;

    void Awake()
    {
        display = GetComponent<TMP_Text>();
        int day = curDate.Day;
        if(calChangeScene.dayToSave != null && calChangeScene.dayToSave != 0)
        {
            day = calChangeScene.dayToSave;
        }
        display.text = $"{curDate.DayOfWeek}\n{curDate.Month}/{day}/{curDate.Year}";
    } 
}
