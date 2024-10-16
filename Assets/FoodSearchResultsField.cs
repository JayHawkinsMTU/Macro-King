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
        JObject json = searchResults.CurrentResults.JObject;
        //JArray foods = (JArray) currentResults["foods"];
        List<JToken> foods = ((JArray)json["foods"]).ToList();

        Debug.Log("Length of FoodsL " + foods.Count);

        Debug.Log("foods");
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
