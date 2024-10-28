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
        string macro = NutritionGoal.macroToString[goal.macro];
        char cond = NutritionGoal.conditionToString[goal.condition];
        goalTitle.text = $"{macro}{cond}{goal.value}";
        // TODO: replace "0f" with today's amount of that macro.
        goalProgress.text = $"{0f}/{goal.value}";
    }
}
