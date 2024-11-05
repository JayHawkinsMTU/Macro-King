using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEntry
{
    public enum Units
    {
        GRAMS,
        MILLIGRAMS,
        SERVINGS
    }

    public static Dictionary<Units, string> unitsToString = new()
    {
        {Units.GRAMS, "g"},
        {Units.MILLIGRAMS, "mg"},
        {Units.SERVINGS, "servings"},
    };
    public FoodItem item = new();
    public Units unit = Units.SERVINGS;
    public float quantity = 1;
    public DateTime recorded = DateTime.Now;
}
