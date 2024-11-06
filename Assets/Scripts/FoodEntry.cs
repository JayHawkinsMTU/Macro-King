using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEntry
{
    public FoodItem food;
    public UnitValue qty;
    public DateTime recorded = DateTime.Now;

    public FoodEntry(FoodItem food, UnitValue qty, DateTime recorded)
    {
        this.food = food;
        this.qty = qty;
        this.recorded = recorded;

    }
    public FoodEntry()
    {
        this.food = null;
        this.qty = null;
        this.recorded = DateTime.Now;
    }

    public UnitValue Calories()
    {
        UnitValue oneServingCals = food.Energy;
        float servings =  (food.ServingSize / qty).Value;
        return servings * oneServingCals;
    }

    public float Servings
    {
        get => (qty / food.ServingSize).Value;
        set => qty = value * food.ServingSize;
    }

}
