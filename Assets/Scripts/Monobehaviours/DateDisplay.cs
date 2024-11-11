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
        DateTime importedDate;

        if (calChangeScene.dateToSave != DateTime.MinValue) //Don't think this is needed, might remove later
        {
            importedDate = calChangeScene.dateToSave; //Changes date to be displayed to the imported DateTime

        }
        else
        {
            importedDate = curDate; //Defaults to current date if something's wrong
        }
        display.text = $"{importedDate.DayOfWeek}\n{importedDate.Month}/{importedDate.Day}/{importedDate.Year}"; //Displays the chosen DateTime
    } 
}
