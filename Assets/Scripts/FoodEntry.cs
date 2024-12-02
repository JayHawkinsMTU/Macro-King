using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class FoodEntry
{
    public FoodItem food { get;} = new(); // SO food item that has been consumed
    public int foodID;
    public string foodName;
    public UnitValue qty; // consumed quantity with units
    public DateTime recorded = DateTime.Now;

    public FoodEntry(FoodItem food, UnitValue qty, DateTime recorded)
    {
        this.foodID = food.FoodID;
        this.foodName = food.foodName;
        this.qty = qty;
        this.recorded = recorded;
    }

    public FoodEntry()
    {
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
