using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutritionGoal
{
    public static NutritionGoal instance;
    public enum Macros { 
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

    public static Dictionary<Macros, string> macroToString {get; private set;} = new()
    {
        {Macros.CALORIES, "Calories"},
        {Macros.CARBS, "Carbs"},
        {Macros.PROTEIN, "Protein"},
        {Macros.FAT, "Fat"}
    };

    public static Dictionary<Condition, char> conditionToString {get; private set;} = new()
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
    public Macros macro = Macros.CALORIES;
    public Condition condition = Condition.GREATER_THAN;
    public float value = 0;
    // The percantage difference for CLOSE_TO condition. Default 5%
    public float leeway = .05f;

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

    public void AddGoal()
    {
        User.instance.NutritionGoals.Add(this);
    }
    
    public void RemoveGoal()
    {
        if(!User.instance.NutritionGoals.Contains(this))
        {
            Debug.LogError("This goal does not exist in the list!");
            return;
        }
        User.instance.NutritionGoals.Remove(this);
    }
}
