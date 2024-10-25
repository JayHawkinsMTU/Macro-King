using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] User mainUser;
    public static User user;

    [SerializeField] FoodNutrientsDictionary mainFoodNutrientsDictionary;
    public static FoodNutrientsDictionary foodNutrientsDictionary;

    [SerializeField] SearchFoodResults searchFood;
  
    [SerializeField] PRHolder holder;
    void Awake()
    {
        UpdateInstances(forceUpdate:false);
    }

    public void UpdateInstances(bool forceUpdate = false)
    {
        if (user == null || forceUpdate) { user = mainUser; }
        if (foodNutrientsDictionary == null || forceUpdate) { foodNutrientsDictionary = mainFoodNutrientsDictionary; }
    }
}
