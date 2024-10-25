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
    [SerializeReference] public Dictionary<int, UnitValue> foodNutrientQuantities = new Dictionary<int, UnitValue>();
    [SerializeField] int foodID = -1;
    [SerializeField] string foodName = "New Food Item";
    UnitValue servingSize;
    [SerializeField] string foodCategory;

    public UnitValue Energy { get => foodNutrientQuantities[GameManager.energyNutrient.NutrientID]; }
        
    
    public enum Allergens {
        Peanut,
        Soy,
        Gluten,
        Dairy,
        Shellfish,
        Treenuts
    };

    private List<Allergens> allergens = new List<Allergens>();


    public static FoodItem CreateFoodItem(JToken foodData, MonoBehaviour mono = null, bool saveAssets = true)
    {
        // Create new food item
        FoodItem newFood = CreateInstance<FoodItem>();
        // Set Data
        newFood.foodName = (string)foodData["description"];
        newFood.foodID = (int)foodData["fdcId"];
        float servingSize = (float)(foodData["servingSize"] ?? 0);
        string ServingSizeunit = (string)(foodData["servingSizeUnit"] ?? "g");
        newFood.servingSize = new UnitValue(servingSize, ServingSizeunit);
        newFood.foodCategory = (string)(foodData["foodCategory"] ?? "");

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
