using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddNutritionGoalButton : MonoBehaviour
{
    public TMP_Text textInput;
    public ChangeSceneButton changeSceneButton;
    public void AddGoal()
    {
        NutritionGoal goal = NutritionGoal.instance;
        goal.value = int.Parse(textInput.text);
        NutritionGoal.instance.AddGoal();
        changeSceneButton.ChangeScene();
    }

    public void RemoveGoal()
    {
        NutritionGoal.instance.RemoveGoal();
        changeSceneButton.ChangeScene();
    }
}
