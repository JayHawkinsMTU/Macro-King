using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Jay Hawkins
/// <summary>
/// Button that adds foodentry to user data in UnitValueEntry scene
/// </summary>
public class LogFoodEntry : MonoBehaviour
{
    public UnitValueEntryField unitValEntry;

    // Add entry to both nutrition list containing all nutrition and to dailynutrition for that day.
    public void LogEntry()
    {
        FoodItem foodItem = GameManager.CurrentFoodItem;
        UnitValue unitVal = unitValEntry.Get();
        DateTime dateSelected = DailyNutrition.selectedDate;
        FoodEntry foodEntry = new(foodItem, unitVal, dateSelected);
        User user = User.LoadUser();
        user.Nutrition.Add(foodEntry);
        user.nutritionCalendar[dateSelected].foodEntries.Add(foodEntry);
        // Return to scene
        SceneManager.LoadScene("Daily Nutrition");
    }
}
