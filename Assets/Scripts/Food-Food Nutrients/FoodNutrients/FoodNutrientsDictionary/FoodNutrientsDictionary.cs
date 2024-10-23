using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Food Nutrient Dictionary", menuName = "Food/Food Nutrient/Food Nutrient Dictionary")]
public class FoodNutrientsDictionary : ScriptableObject
{
    [SerializeField] Dictionary<int, FoodNutrients> dict = new Dictionary<int, FoodNutrients>();
    [SerializeField] List<FoodNutrients> foods = new List<FoodNutrients>();


    public bool addFood(FoodNutrients food)
    {
        if (containsFood(food))
        {
            return false;
        }
        dict[food.NutrientID] = food;
        foods.Add(food);
        return true;
    }
    public bool containsFood(FoodNutrients food)
    {
        return containsFood(food.NutrientID);
    }
    public bool containsFood(int nutrientID)
    {
        if(nutrientID == -1) { return false; }
        return dict.ContainsKey(nutrientID);
    }
}
