using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class populateCalendar : MonoBehaviour
{
    private TMP_Text dayText;
    public GameObject dayPrf;
    public Transform[] dayCols;
    private List<GameObject> days = new List<GameObject>();

    public void printDates(int startDayOfWeek, int monthSize)
    {
        foreach(GameObject day in days) //Clears previous day prefabs
        {
            Destroy(day);
        }
        days.Clear();

        int curDay = 1; //Starts at day 1 by default
        int numBoxes = 35; //35 boxes by default since that's what 99% of months use
        if(startDayOfWeek + monthSize > 35) //If more than 35 boxes are needed, adds another row
        {
            numBoxes = 42;
        }

        for(int i = 0; i < numBoxes; i++)
        {
            Transform dayCol = dayCols[i % 7]; //Calculates what day-column each dat should be at
            GameObject dayObject = Instantiate(dayPrf, dayCol); //Creates the day prefab at calculated day-columns
            dayText = dayObject.GetComponentInChildren<TMP_Text>();

            if(i >= startDayOfWeek && curDay <= monthSize) //Runs for all days in the month
            {
                dayText.text = curDay.ToString(); //Sets the day in the prefab and increments
                curDay++;
            }
            else
            {
                dayText.text = ""; //Fills out the blank days
            }
            days.Add(dayObject);
        }
    }
}
