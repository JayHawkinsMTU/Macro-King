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

    void Start()
    {

    }

    public void printDates(int startDayOfWeek, int monthSize)
    {
        foreach(GameObject day in days)
        {
            Destroy(day);
        }
        days.Clear();

        int curDay = 1;

        for(int day = 0; day < 7; day++)
        {
            Transform dayCol = dayCols[day];

            if(day < startDayOfWeek)
            {
                makeEmptyDay(dayCol);
            }
            else
            {
                while (curDay <= monthSize)
                {
                    GameObject dayObject = Instantiate(dayPrf, dayCol);
                    dayObject.GetComponentInChildren<TextMeshProUGUI>().text = curDay.ToString();
                    days.Add(dayObject);
                    curDay++;

                    day = (day + 1) % 7;
                    dayCol = dayCols[day];
                }
                break;
            }
        }
    }

    private void makeEmptyDay(Transform parent)
    {
        GameObject empty = Instantiate(dayPrf, parent);
        empty.GetComponentInChildren<TextMeshProUGUI>().text = ""; 
        days.Add(empty);
    }

}
