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
    accomplished = new Color(0.25f, 1, 0.75f, 0.3f),
    current = new Color(0.25f, 1.07f, 0.33f, 0.3f),
    unaccomplished = new Color(.8f, 0.2f, 0.2f, 0.3f),
    noData = new Color(0.3f, 0.3f, 0.3f, 0.3f);

    // Update proper color on awake
    // GREEN - goals accomplished
    // YELLOW - current day
    // RED - goals not accomplished
    // GREY - not in calendar, likely was before user installed app or forgot to log data
    public void SetDate(DateTime date)
    {
        this.date = date;
        User user = User.LoadUser();
        GetComponentInChildren<TMP_Text>().text = date.Day.ToString();
        if(date == DateTime.Today)
        {
            img.color = current;
            return;
        }
        if(!user.nutritionCalendar.ContainsKey(date))
        {
            img.color = noData;
            return;
        }
        DailyNutrition day = user.nutritionCalendar[date];
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
        User user = User.LoadUser();
        // Add new day to user calendar data
        if(!user.nutritionCalendar.ContainsKey(date))
        {
            user.nutritionCalendar.Add(date, new DailyNutrition());
        }
        if (display != null && display.text != "")
        {
            DailyNutrition.selectedDate = date; //This is the date time which is exported
            SceneManager.LoadScene("Daily Nutrition");
        }
        else
        {
            openMenu open = FindObjectOfType<openMenu>();
            open.showSecondMenu();
            Debug.Log("Non-Existing date was selected."); //I'll replace this with a popup or something later
        }
    }
}
