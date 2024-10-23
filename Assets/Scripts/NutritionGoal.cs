using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutritionGoal
{
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
    /*
    For a goal to be under 3000 calories
    macro = CALORIES
    condition = LESS_THAN
    value = 3000
    */
    public Macros macro;
    public Condition condition;
    public float value;
}
