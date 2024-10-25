using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddNutritionGoalButton : MonoBehaviour
{
    public TMP_Text textInput;
    public void AddGoal()
    {
        NutritionGoal goal = NutritionGoalContainer.goal;
        goal.value = int.Parse(textInput.text);
        GameManager.user.NutritionGoals.Add(goal);
    }
}
