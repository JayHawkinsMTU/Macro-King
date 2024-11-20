using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using JetBrains.Annotations;

public class manageCalendar : MonoBehaviour
{
    public static DateTime today;
    public TMP_Text monthText;
    public int curYear;
    public int curMonth;
    public populateCalendar calendar; //Script to actually add the days to the calendar


    private void Start()
    {
        today = DateTime.Today; //Starts the calendar at today's data
        CalendarDate.curYear = today.Year;
        CalendarDate.curMonth = today.Month;
        monthText.text = $"{new DateTime(CalendarDate.curYear, CalendarDate.curMonth, 1):MMM yyyy}"; //Prints the current month and year
        getDays();
    }

    public void getDays()
    {
        DateTime fDay = new DateTime(CalendarDate.curYear, CalendarDate.curMonth, 1); //First day of the month
        int monthSize = DateTime.DaysInMonth(CalendarDate.curYear, CalendarDate.curMonth); //Gets the number of days in the month
        int startDayOfWeek = (int) fDay.DayOfWeek; //Gets the day of the week the month starts on

        calendar.PrintDates(startDayOfWeek, monthSize);
    }

    //Method to increase month when forwards arrow is clicked
    public void goForward()
    {
        if(CalendarDate.curMonth == 12) //Rolls over to next year if the current month is December
        {
            CalendarDate.curMonth = 1;
            CalendarDate.curYear++;
        }
        else
        {
            CalendarDate.curMonth++;
        }

        monthText.text = $"{new DateTime(CalendarDate.curYear, CalendarDate.curMonth, 1):MMM yyyy}";
        getDays();
    }

    //Method to decrease month when backwards arrow is clicked
    public void goBackward()
    {
        if (CalendarDate.curMonth == 1) //Rolls over to previous year if the current month is January
        {
            CalendarDate.curMonth = 12; 
            CalendarDate.curYear--;
        }
        else
        {
            CalendarDate.curMonth--;
        }

        monthText.text = $"{new DateTime(CalendarDate.curYear, CalendarDate.curMonth, 1):MMM yyyy}";
        getDays();
    }

    //Static class to hold the current year and month so they can be passed to date display
    public static class CalendarDate
    {
        public static int curYear;
        public static int curMonth;
    }
}


