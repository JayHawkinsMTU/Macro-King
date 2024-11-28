using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

/// <summary>
/// Attach to Nutrition Goal Display prefab. Shows nutrition goal and progress.
/// Jay Hawkins
/// </summary>
public class NutritionGoalDisplay : MonoBehaviour
{
    // Colors taken from superhero bootswatch.
    // Would it be easier to do this in the editor? Yes. shut up.
    private static Color failed = new(.851f, .3254f, .3098f);
    private static Color succeeded = new(.3607f, .7215f, .3607f);

    // When null, selecting will take you to create a new goal instead of editing
    public NutritionGoal goal = null;
    public ChangeSceneButton changeSceneButton;
    public TMP_Text goalTitle;
    public TMP_Text goalProgress;
    public Image backdrop;

    // Start is called before the first frame update
    void Start()
    {
        if(goal == null)
        {
            return;
        }
        string macro = NutritionGoal.macroToString[goal.macro];
        char cond = NutritionGoal.conditionToChar[goal.condition];
        string units = NutritionGoal.UnitsOf(goal.macro);
        goalTitle.text = $"{macro}{cond}{goal.value}{units}";
        // TODO: replace "0f" with today's amount of that macro.
        goalProgress.text = $"{0f}{units}/{goal.value}{units}";
        if(CalculateProgress()) {
            backdrop.color = succeeded;
        } else {
            backdrop.color = failed;
        }
    }

    public bool CalculateProgress()
    {
        float progress = 0;
        DailyNutrition today;
        if(!User.LoadUser().nutritionCalendar.ContainsKey(DailyNutrition.selectedDate)) {
            User.LoadUser().nutritionCalendar.Add(DailyNutrition.selectedDate, new());
        }
        today = User.LoadUser().nutritionCalendar[DailyNutrition.selectedDate];
        foreach(FoodEntry f in today.foodEntries) {
            switch(goal.macro)
            {
                case NutritionGoal.Macro.CALORIES:
                    progress += f.Energy.Value;
                    continue;
                case NutritionGoal.Macro.CARBS:
                    progress += f.Carbs.Value;
                    continue;
                case NutritionGoal.Macro.PROTEIN:
                    progress += f.Protien.Value;
                    continue;
                case NutritionGoal.Macro.FAT:
                    progress += f.Fat.Value;
                    continue;
            }
        }
        // Update display
        string units = NutritionGoal.UnitsOf(goal.macro);
        goalProgress.text = $"{progress}{units}/{goal.value}{units}";
        switch(goal.condition)
        {
            case NutritionGoal.Condition.GREATER_THAN:
                return progress > goal.value;
            case NutritionGoal.Condition.CLOSE_TO:
                return Mathf.Abs((progress - goal.value) / goal.value) < goal.leeway;
            case NutritionGoal.Condition.LESS_THAN:
                return progress < goal.value;
            default:
                Debug.LogError("Invalid condition");
                return false; 
        }
    }

    public void Edit()
    {
        NutritionGoal.instance = this.goal;
        changeSceneButton.ChangeScene();
    }
}
