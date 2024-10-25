using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NutritionGoalDisplay : MonoBehaviour
{
    public NutritionGoal goal = new();
    public TMP_Text goalTitle;
    public TMP_Text goalProgress;

    // Start is called before the first frame update
    void Start()
    {
        string macro;
        switch (goal.macro) {
            case NutritionGoal.Macros.CALORIES:
                macro = "Calories";
                break;
            case NutritionGoal.Macros.CARBS:
                macro = "Carbs";
                break;
            case NutritionGoal.Macros.PROTEIN:
                macro = "Protein";
                break;
            case NutritionGoal.Macros.FAT:
                macro = "Fat";
                break;
            default:
                Debug.LogError("NULL macro assigned to goal");
                return;
        }
        char cond;
        switch (goal.condition) {
            case NutritionGoal.Condition.GREATER_THAN:
                cond = '>';
                break;
            case NutritionGoal.Condition.LESS_THAN:
                cond = '<';
                break;
            case NutritionGoal.Condition.CLOSE_TO:
                cond = '=';
                break;
            default:
                Debug.LogError("NULL condition assigned to goal");
                return;
        }
        goalTitle.text = $"{macro}{cond}{goal.value}";
        // TODO: replace "0f" with today's amount of that macro.
        goalProgress.text = $"{0f}/{goal.value}";
    }
}
