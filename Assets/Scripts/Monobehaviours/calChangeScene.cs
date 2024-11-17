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
    //public static DateTime dateToSave; //Creates the date time that will be exported
    private DateTime date;
    public Image img;
    public static Color 
    accomplished = new Color(0.25f, 1, 0.75f, 0.5f),
    current = new Color(0.75f, 0.75f, 0.2f, 0.5f),
    unaccomplished = new Color(.8f, 0.2f, 0.2f, 0.5f),
    noData = new Color(0.3f, 0.3f, 0.3f, 0.5f);

    // Update proper color on awake
    // GREEN - goals accomplished
    // YELLOW - current day
    // RED - goals not accomplished
    // GREY - not in calendar, likely was before user installed app or forgot to log data
    public void SetDate(DateTime date)
    {
        this.date = date;
        User.LoadUser();
        GetComponentInChildren<TMP_Text>().text = date.Day.ToString();
        if(date == DateTime.Today)
        {
            img.color = current;
            return;
        }
        if(!User.instance.nutritionCalendar.ContainsKey(date))
        {
            img.color = noData;
            return;
        }
        DailyNutrition day = User.instance.nutritionCalendar[date];
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
        // Add new day to user calendar data
        if(!User.instance.nutritionCalendar.ContainsKey(date))
        {
            User.instance.nutritionCalendar.Add(date, new DailyNutrition());
        }
        if (display != null && display.text != "")
        {
            DailyNutrition.selectedDate = date; //This is the date time which is exported
            SceneManager.LoadScene("Daily Nutrition");
        }
        else
        {
            Debug.Log("Non-Existing date was selected."); //I'll replace this with a popup or something later
        }
    }
}
