using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutritionGoalOptionsController : MonoBehaviour
{
    public GameObject newOptions;
    public GameObject editOptions;
    void Start()
    {
        // If null, create new goal.
        if(NutritionGoal.instance == null)
        {
            NutritionGoal.instance = new();
            newOptions.SetActive(true);
        }
        else 
        {
            editOptions.SetActive(true);
        }
    }
}
