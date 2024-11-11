// Jay Hawkins
// A class to store the nutritional data in a given day
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyNutrition : MonoBehaviour
{
    /// <summary>
    /// The current date that has been selected via UI
    /// </summary>
    public static DateTime selectedDate = DateTime.Today;
    public bool goalsAccomplished = false;
    public List<FoodEntry> foodEntries;


    // Updates goalsAccomplished variable depending on if all current goals in user data is accomplished
    public bool UpdateAccomplished()
    {
        return goalsAccomplished;
    }
}
