using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NutritionGoalDisplay : MonoBehaviour
{
    // When null, selecting will take you to create a new goal instead of editing
    public NutritionGoal goal = null;
    public ChangeSceneButton changeSceneButton;
    public TMP_Text goalTitle;
    public TMP_Text goalProgress;

    // Start is called before the first frame update
    void Start()
    {
        if(goal == null)
        {
            return;
        }
        string macro = NutritionGoal.macroToString[goal.macro];
        char cond = NutritionGoal.conditionToChar[goal.condition];
        goalTitle.text = $"{macro}{cond}{goal.value}";
        // TODO: replace "0f" with today's amount of that macro.
        goalProgress.text = $"{0f}/{goal.value}";
    }

    public void Edit()
    {
        NutritionGoal.instance = this.goal;
        changeSceneButton.ChangeScene();
    }
}
