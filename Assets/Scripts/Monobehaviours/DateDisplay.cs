using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Jay Hawkins: Displays selected date to a TMP_Text
/// </summary>
public class DateDisplay : MonoBehaviour
{
    private TMP_Text display;

    void Awake()
    {
        display = GetComponent<TMP_Text>();

        /*
        DateTime importedDate;
        if (calChangeScene.dateToSave != DateTime.MinValue) //Don't think this is needed, might remove later
        {
            importedDate = calChangeScene.dateToSave; //Changes date to be displayed to the imported DateTime

        }
        else
        {
            importedDate = curDate; //Defaults to current date if something's wrong
        }
        */
        // ^ Streamlined date selection using DailyNutrition.selectedDate - Jay Hawkins
        DateTime date = DailyNutrition.selectedDate;
        display.text = $"{date.DayOfWeek}\n{date.Month}/{date.Day}/{date.Year}"; //Displays the chosen DateTime
    } 
}
