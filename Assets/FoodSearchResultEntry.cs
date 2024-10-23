using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class FoodSearchResultEntry : MonoBehaviour
{
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text calCount;
    private JToken foodData;
    public void Awake()
    {
        clearData();
    }

    public void setData(JToken foodItem)
    {
        foodData = foodItem;
        if (name != null)
        {
            string name_s = foodData["description"]?.ToString() ?? ""; // Food Name
            name.text = name_s;
        }
        else
        {
            Debug.LogWarning("No name found on result:\n" + foodData.ToString());
        }
        if (calCount != null)
        {
            string calories = foodData["foodNutrients"]?.FirstOrDefault(n => (string)n["nutrientName"] == "Energy")?["value"]?.ToString() ?? "";  // Calorie count
            calCount.text = calories + "cal";
        }
        else
        {
            Debug.LogWarning("No cal count found on result:\n" + foodData.ToString());
        }
    }

    public void clearData()
    {
        if (name != null)
        {
            name.text = "";
        }
        if (calCount != null)
        {
            calCount.text = "cal";
        }
    }

    public void OnButtonPress()
    {
        Debug.Log(foodData.ToString());
    }
}
