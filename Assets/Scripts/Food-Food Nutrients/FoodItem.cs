using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName ="New Food Item", menuName ="Food/Food Item")]
public class FoodItem : ScriptableObject
{
    // Key = FoodNutrientID, Value is a Unit Quantity
    [SerializeReference] private Dictionary<int, UnitValue> foodNutrientQuantities = new Dictionary<int, UnitValue>();
    [SerializeField] int foodID = -1;
    [SerializeField] string foodName = "New Food Item";
    UnitValue servingSize;
    private List<Allergen> allergens = new List<Allergen>();


    #region Getters
    #region Nutrient Getters
    public UnitValue Energy { get => SafeGetValue(GameManager.energyNutrient.NutrientID); }
    public UnitValue Protien { get => SafeGetValue(GameManager.protienNutrient.NutrientID); }
    public UnitValue Fat { get => SafeGetValue(GameManager.fatNutrient.NutrientID); }
    public UnitValue Carbs { get => SafeGetValue(GameManager.carbsNutrient.NutrientID); }
    #endregion
    #region Food Specific Getters
    public int FoodID { get => foodID;  }
    public string FoodName { get => foodName;  }
    public UnitValue ServingSize { get => servingSize;  }
    public Dictionary<int, UnitValue> FoodNutrientQuantities { get => foodNutrientQuantities; }
    #endregion
    #endregion

    private UnitValue SafeGetValue(int NutrientID)
    {
        if (foodNutrientQuantities.ContainsKey(NutrientID))
        {
            return foodNutrientQuantities[NutrientID];
        }
        return UnitValue.NullUnitValue;
    }
    public static FoodItem CreateFoodItem(JToken foodData, MonoBehaviour mono = null, bool saveAssets = true)
    {
        // Create new food item
        FoodItem newFood = CreateInstance<FoodItem>();
        newFood.foodNutrientQuantities = new Dictionary<int, UnitValue>();
        newFood.foodNutrientQuantities.Add(
            key : GameManager.energyNutrient.NutrientID,
            value : new UnitValue(0, UnitManager.UnitParse("kcal"))
        );

        // Set Data
        newFood.foodName = (string)foodData["description"];
        newFood.foodID = (int)foodData["fdcId"];
        float servingSize = (float)(foodData["servingSize"] ?? 0);
        string ServingSizeunit = (string)(foodData["servingSizeUnit"] ?? "g");
        newFood.servingSize = new UnitValue(servingSize, ServingSizeunit);

#if UNITY_EDITOR
        bool _saveAssets = saveAssets;
#else
        bool _saveAssets = false;
#endif



        // Add food nutrients to the new food item
        List<JToken> foodNutrients = foodData["foodNutrients"].ToList();
        foreach (JToken nutrient in foodNutrients)
        {
            FoodNutrients n  = FoodNutrients.CreateFoodNutrients(
                mono: (mono==null)? GameManager.instance : mono,
                nutrient: nutrient,
                saveAssets: _saveAssets
                ); ;
            float value = (float)nutrient["value"];
            string unit = (string)nutrient["unitName"];

            UnitValue unitValue = new UnitValue(value, unit);
            newFood.foodNutrientQuantities.Add(n.NutrientID, unitValue);

        }

        if (_saveAssets)
        {
            string directoryPath = "Assets/Scripts/Food-Food Nutrients/FoodItems";
            string assetPath = $"{directoryPath}/{DirectoryUtils.SanitizeToValidName(newFood.foodName + "_" + newFood.foodID)}.asset";
            if (!Directory.Exists(directoryPath)) { Directory.CreateDirectory(directoryPath); }
            AssetDatabase.CreateAsset(newFood, assetPath);
            AssetDatabase.SaveAssetIfDirty(newFood);
        }

        return newFood;
    }


    public override string ToString()
    {
        string s = "";
        s += $"{foodName}\n" +
            $"ID:{foodID}\n" +
            $"Serving Size = {servingSize}\n" +
            $"Energy = {Energy}\n" +
            $"Nutrients: \n";
        foreach (var n in foodNutrientQuantities)
        {
            s += $"   {GameManager.foodNutrientsDictionary.GetFood(n.Key)} {n.Value}\n";
        }
        return s;
    }
    [ContextMenu("Print() food item")]
    public void Print()
    {
        Debug.Log(ToString());
    }

}
