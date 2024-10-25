using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Nutrient", menuName = "Food/Food Nutrient/Food Nutrient")]
public class FoodNutrients : ScriptableObject
{
    [SerializeField] int nutrientID;
    [SerializeField] string nutrientName;
    [SerializeField] int indentLevel; // Not sure what this does yet

    public int NutrientID { get => nutrientID;  }
    public string NutrientName { get => nutrientName; }
    public int IndentLevel { get => indentLevel;  }

    public void SetValues(int nutrientID = -1,string nutrientName = "",int indentLevel = 0)
    {
        this.nutrientID = nutrientID;
        this.nutrientName = nutrientName;
        this.indentLevel = indentLevel;
    }
 
    public void SetValues(JToken nutrient)
    {
        SetValues(
            (int)nutrient["nutrientId"],
            (string)nutrient["nutrientName"],
            (int)nutrient["indentLevel"]
        );
    }

    public static FoodNutrients CreateFoodNutrients(MonoBehaviour mono, JToken nutrient = null, bool saveAssets = true)
       
    {
        JToken t = nutrient?["nutrientId"];
        int id = -1;
        if (t != null)
        {
            id = (int)t;
        }
        FoodNutrientsDictionary nutrientDict = GameManager.foodNutrientsDictionary;



        if (!nutrientDict.ContainsFood(id))
        {
            // Create an instance of the ScriptableObject
            FoodNutrients newData = ScriptableObject.CreateInstance<FoodNutrients>();
            // Set the object's data (optional)
            newData.SetValues(nutrient);
            nutrientDict.AddFood(newData);

            mono.StartCoroutine(CreateFoodNutrientCoroutine(newData, true));

            return newData;
        }
        else
        {
            return nutrientDict.GetFood(id);
        }
    }
    static IEnumerator CreateFoodNutrientCoroutine(FoodNutrients newData, bool saveAssets = true)
    {
        yield return null;
        FoodNutrientsDictionary nutrientDict = GameManager.foodNutrientsDictionary;
        // Save the object as an asset file
        // Define the asset path
        string directoryPath = "Assets/Scripts/Food-Food Nutrients/FoodNutrients";
        string assetPath = $"{directoryPath}/{DirectoryUtils.SanitizeToValidName(newData.nutrientName)}.asset";
        // Ensure the directory exists
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Save the object as an asset file
        AssetDatabase.CreateAsset(newData, assetPath); // Save asset to disk
        Debug.Log("Creating asset at: " + assetPath);

        if (saveAssets)
        {
            AssetDatabase.SaveAssetIfDirty(newData); // Ensure the asset database is updated
            AssetDatabase.SaveAssetIfDirty(nutrientDict);
        }        
        yield break;
    }

    // Explicit cast operator to convert FoodNutrients to int using nutrientID
    public static explicit operator int(FoodNutrients nutrient)
    {
        return nutrient.nutrientID;
    }
}

