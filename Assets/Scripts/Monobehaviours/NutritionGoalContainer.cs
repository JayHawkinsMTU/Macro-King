using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    MonoBehaviour class meant to help Unity interact with NutritionGoal class through UI
    Jay Hawkins
*/
public class NutritionGoalContainer : MonoBehaviour
{
    public static NutritionGoal goal;
    // Start is called before the first frame update
    void Awake()
    {
        goal = new();
    }
    public void AddGoal()
    {
        //TODO
    }
}
