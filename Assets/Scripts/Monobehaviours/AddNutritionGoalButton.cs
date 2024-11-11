// Jay Hawkins
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Adds a nutrition goal to user data. Intended to be activated by Unity button
/// </summary>
public class AddNutritionGoalButton : MonoBehaviour
{
    public TMP_InputField textInput;
    public ChangeSceneButton changeSceneButton;
    public void AddGoal()
    {
        NutritionGoal goal = NutritionGoal.instance;
        goal.value = float.Parse(textInput.text);
        NutritionGoal.instance.AddGoal();
        changeSceneButton.ChangeScene();
    }

    public void RemoveGoal()
    {
        NutritionGoal.instance.RemoveGoal();
        changeSceneButton.ChangeScene();
    }
}
