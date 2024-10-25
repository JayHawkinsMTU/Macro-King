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

    [SerializeField] SearchFoodResults mainSearchFoodResults;
    public static SearchFoodResults searchFoodResults;

    [SerializeField] UnitManager mainUnitManager;
    public static UnitManager unitManager;

    public static GameManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            GameObject.Destroy(this);
            return;
        }
        UpdateInstances(forceUpdate:false);
    }

    public void UpdateInstances(bool forceUpdate = false)
    {
        if (user == null || forceUpdate) { user = mainUser; }
        if (foodNutrientsDictionary == null || forceUpdate) { foodNutrientsDictionary = mainFoodNutrientsDictionary; }
        if (searchFoodResults == null || forceUpdate) { searchFoodResults = mainSearchFoodResults; }
        if (unitManager == null || forceUpdate) { unitManager = mainUnitManager; }
    }
}
