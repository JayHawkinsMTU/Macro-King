using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

//Specific change scene script for calendar day buttons
public class calChangeScene : MonoBehaviour 
{
    public static DateTime dateToSave; //Creates the date time that will be exported
    public DateTime thisDate;
    public Image img;
    public static Color 
    accomplished = new Color(0.25f, 1, 0.75f, 0.25f),
    current = new Color(0.6f, 0.6f, 0.2f, 0.25f),
    unaccomplished = new Color(.8f, 0.2f, 0.2f, 0.25f),
    noData = new Color(0.3f, 0.3f, 0.3f, 0.25f);

    // Update proper color on awake
    // GREEN - goals accomplished
    // YELLOW - current day
    // RED - goals not accomplished
    // GREY - not in calendar, likely was before user installed app or forgot to log data
    public void SetDate(DateTime dateTime)
    {
        thisDate = dateTime;
        Debug.Log(thisDate + " " + DateTime.Today);
        if(thisDate == DateTime.Today)
        {
            img.color = current;
            Debug.Log("Current");
            return;
        }
        if(!DailyNutrition.calendar.ContainsKey(thisDate))
        {
            img.color = noData;
            return;
        }
        DailyNutrition day = DailyNutrition.calendar[thisDate];
        if(day.goalsAccomplished)
        {
            img.color = accomplished;
            return;
        }
        img.color = unaccomplished;
    }

    public void ChangeScene()
    {
        TMP_Text display = GetComponentInChildren<TMP_Text>(); //Gets the text object from the clicked button
        if (display != null && display.text != "")
        {
            int year = manageCalendar.CalendarDate.curYear; //Gets the current year the calendar is on 
            int month = manageCalendar.CalendarDate.curMonth; //Gets the current month the calendar is on 
            int day = int.Parse(display.text); //Gets the date displayed on the clicked button
            dateToSave = new DateTime(year, month, day); //This is the date time which is exported
            SceneManager.LoadScene("Daily Nutrition");
        }
        else
        {
            Debug.Log("Non-Existing date was selected."); //I'll replace this with a popup or something later
        }
    }
}
