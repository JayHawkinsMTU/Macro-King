using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class NutritionGoal
{
    public static NutritionGoal instance;
    public enum Macro { 
        CALORIES, 
        CARBS, 
        PROTEIN,
        FAT
    };

    public enum Condition {
        GREATER_THAN,
        LESS_THAN,
        CLOSE_TO
    }

    public static Dictionary<Macro, string> macroToString {get; private set;} = new()
    {
        {Macro.CALORIES, "Calories"},
        {Macro.CARBS, "Carbs"},
        {Macro.PROTEIN, "Protein"},
        {Macro.FAT, "Fat"}
    };

    public static Dictionary<Condition, char> conditionToChar {get; private set;} = new()
    {
        {Condition.GREATER_THAN, '>'},
        {Condition.LESS_THAN, '<'},
        {Condition.CLOSE_TO, '='}
    };
    /*
    For a goal to be under 3000 calories
    macro = CALORIES
    condition = LESS_THAN
    value = 3000
    Default goal basically means eat something today.
    */
    public Macro macro = Macro.CALORIES;
    public Condition condition = Condition.CLOSE_TO;
    public float value = 0;
    // The percantage difference for CLOSE_TO condition. Default 5%
    public float leeway = .05f;

    public NutritionGoal() {}

    public NutritionGoal(Macro m, Condition c, float v)
    {
        macro = m;
        condition = c;
        value = v;
    }

    // Determines if goal has been accomplished
    public bool IsAccomplished(float logged)
    {
        switch (condition)
        {
            case Condition.GREATER_THAN:
                return logged > value;
            case Condition.CLOSE_TO:
                return Mathf.Abs((logged - value) / value) < leeway;
            case Condition.LESS_THAN:
                return logged < value;
            default:
                Debug.LogError("NULL condition assigned to a goal");
                return false;
        }
    }

    public static string UnitsOf(Macro m)
    {
        if(m == Macro.CALORIES)
        {
            return "cals";
        }
        else
        {
            return "g";
        }
    }

    public void AddGoal()
    {
        User.LoadUser().NutritionGoals.Add(this);
    }
    
    public void RemoveGoal()
    {
        if(!User.LoadUser().NutritionGoals.Contains(this))
        {
            Debug.LogError("This goal does not exist in the list!");
            return;
        }
        User.LoadUser().NutritionGoals.Remove(this);
    }
}
