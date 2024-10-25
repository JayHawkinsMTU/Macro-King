using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName ="New Food Item", menuName ="Food/Food Item")]
public class FoodItem : ScriptableObject
{
    // Key = FoodNutrientID, Value is a Unit Quantity
    public Dictionary<int, UnitValue> foodNutrientQuantities;

    public enum Allergens {
        Peanut,
        Soy,
        Gluten,
        Dairy,
        Shellfish,
        Treenuts
    };
    //food item data
    private int foodID;
    private List<Allergens> allergens = new List<Allergens>();

    public override string ToString()
    {
        return base.ToString();
    }
    [ContextMenu("Print() food item")]
    public void Print()
    {
        Debug.Log(ToString());
    }

    public FoodItem CreateFoodItem(JToken foodData)
    {
        List<JToken> foodNutrients = foodData["foodNutrients"].ToList();

        foreach (JToken nutrient in foodNutrients)
        {
            FoodNutrients.CreateFoodNutrients(
                mono: GameManager.instance
                ); ;
        }
        return null;
    }
}
