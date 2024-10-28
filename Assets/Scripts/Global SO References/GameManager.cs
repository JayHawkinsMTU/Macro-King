using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    [Header("References")]
    [SerializeField] User mainUser;
    public static User user;

    [SerializeField] FoodNutrientsDictionary mainFoodNutrientsDictionary;
    public static FoodNutrientsDictionary foodNutrientsDictionary;

    [SerializeField] SearchFoodResults mainSearchFoodResults;
    public static SearchFoodResults searchFoodResults;

    [SerializeField] UnitManager mainUnitManager;
    public static UnitManager unitManager;
    [SerializeField] PRHolder mainPRList;
    public static PRHolder PRList;

    [Header("Nutrients")]
    #region Nutrients
    [SerializeField] FoodNutrients mainEnergyNutrient;
    public static FoodNutrients energyNutrient;

    [SerializeField] FoodNutrients mainProtienNutrient;
    public static FoodNutrients protienNutrient;

    [SerializeField] FoodNutrients mainFatNutrient;
    public static FoodNutrients fatNutrient;

    [SerializeField] FoodNutrients mainCarbsNutrient;
    public static FoodNutrients carbsNutrient;
    #endregion
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
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

        if (energyNutrient == null || forceUpdate) { energyNutrient = mainEnergyNutrient; }
        if (protienNutrient == null || forceUpdate) { protienNutrient = mainProtienNutrient; }
        if (fatNutrient == null || forceUpdate) { fatNutrient = mainFatNutrient; }
        if (carbsNutrient == null || forceUpdate) { carbsNutrient = mainCarbsNutrient; }
    }
}
