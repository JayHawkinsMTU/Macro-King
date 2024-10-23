using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class FoodSearchResultsField : MonoBehaviour
{
    [SerializeField] SearchFoodResults searchResults;
    TMP_Text tmp;
    private void Start()
    {
        tmp = gameObject.GetComponent<TMP_Text>();
        tmp.text = "...";
    }

    public void UpdateResults()
    {
        Debug.Log("UpdateResults() called");
        JObject json = searchResults.CurrentResults.JObject;
        List<JToken> foods = ((JArray)json["foods"]).ToList();

        string s = "";

        if (foods != null)
        {
            foreach (var food in foods)
            {
                string name = food["description"]?.ToString() ?? "";  // Food name
                string calories = food["foodNutrients"]?.FirstOrDefault(n => (string)n["nutrientName"] == "Energy")?["value"]?.ToString() ?? "";  // Calorie count

                s += $"{name.PadRight(50)}{(calories + "cal").PadLeft(20)}\n";
            }
        }
        tmp.text = s;
    }
}
