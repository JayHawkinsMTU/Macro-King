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
    public populateCalendar calendar;


    private void Start()
    {
        today = DateTime.Today;
        curYear = today.Year;
        curMonth = today.Month;

        getDays();
    }

    public void getDays()
    {
        DateTime fDay = new DateTime(curYear, curMonth, 1);
        int monthSize = DateTime.DaysInMonth(curYear, curMonth);
        int startDayOfWeek = (int) fDay.DayOfWeek;

        calendar.printDates(startDayOfWeek, monthSize);
    }

    public void goForward()
    {
        if(curMonth == 12)
        {
            curMonth = 1;
            curYear++;
        }
        else
        {
            curMonth++;
        }

        monthText.text = $"{curMonth} - {curYear}";
        getDays();
    }

    public void goBackward()
    {
        if (curMonth == 1)
        {
            curMonth = 12;
            curYear--;
        }
        else
        {
            curMonth--;
        }

        monthText.text = $"{curMonth} - {curYear}";
        getDays();
    }

}
