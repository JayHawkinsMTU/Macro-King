using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEntry
{
    public FoodItem food; // SO food item that has been consumed
    public UnitValue qty; // consumed quantity with units
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

    public UnitValue Energy
    {
        get => Servings * food.Energy;
    }
    public UnitValue Protien
    {
        get => Servings * food.Protien;
    }
    public UnitValue Carbs
    {
        get => Servings * food.Carbs;
    }
    public UnitValue Fat
    {
        get => Servings * food.Fat;
    }

    public float Servings
    {
        get => (qty / food.ServingSize).Value;
        set => qty = value * food.ServingSize;
    }

}
