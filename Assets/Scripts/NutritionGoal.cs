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
    Default goal basically means eat something today.
    */
    public Macros macro = Macros.CALORIES;
    public Condition condition = Condition.GREATER_THAN;
    public float value = 0;
}
