using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "New Food Nutrient Dictionary", menuName = "Food/Food Nutrient/Food Nutrient Dictionary")]
public class FoodNutrientsDictionary : ScriptableObject
{
    [SerializeField] Dictionary<int, FoodNutrients> dict = new Dictionary<int, FoodNutrients>();
    [SerializeField] List<FoodNutrients> foods = new List<FoodNutrients>();

    private void OnEnable()
    {
        RebuildDictionary();
    }

    private void RebuildDictionary()
    {
        dict.Clear();
        foreach (var food in foods)
        {
            if (food != null && food.NutrientID != -1)
            {
                dict[food.NutrientID] = food;
            }
        }
    }

    public bool AddFood(FoodNutrients food)
    {
        if (ContainsFood(food.NutrientID)) return false;

        foods.Add(food);
        dict[food.NutrientID] = food;
        return true;
    }

    public bool ContainsFood(FoodNutrients food)
    {
        return ContainsFood(food.NutrientID);
    }
    public bool ContainsFood(int nutrientID)
    {
        if(nutrientID == -1) { return false; }
        return dict.ContainsKey(nutrientID);
    }
}
