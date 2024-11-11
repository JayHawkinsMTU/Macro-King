using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using Unity.VisualScripting;

//Specific change scene script for calendar day buttons
public class calChangeScene : MonoBehaviour 
{
    public static DateTime dateToSave; //Creates the date time that will be exported

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
