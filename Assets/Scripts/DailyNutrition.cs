using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyNutrition : MonoBehaviour
{
    public static Dictionary<DateTime, DailyNutrition> calendar = new();
    public bool goalsAccomplished = false;
    public List<FoodEntry> foodEntries;


    // Updates goalsAccomplished variable depending on if all current goals in user data is accomplished
    public bool UpdateAccomplished()
    {
        return goalsAccomplished;
    }
}
