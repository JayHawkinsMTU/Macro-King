using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; //to change the scene when an entry is selected

public class FoodSearchResultEntry : MonoBehaviour
{

    [SerializeField] private static GameManager gameManager;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text calCount;
    private JToken foodData;
    [SerializeField] FoodItem currentFoodItem;
    
    public void Awake()
    {
        clearData();

        if (gameManager == null)
        {
            gameManager = GameManager.instance;
            if (gameManager == null)
            {
                Debug.LogError("GameManager instance not found.");
            }
        }
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

    [ContextMenu("Run OnButtonPress()")]
    public void OnButtonPress()
    {
        // Print the food string out
        Debug.Log(foodData.ToString());

        // Create new food item and save it as the current item
        this.currentFoodItem = FoodItem.CreateFoodItem(foodData, mono: this, true);

        // Set the game manager's current chosen food result as this food result
        GameManager.CurrentFoodItem = currentFoodItem;

        //Scene changes into another window
        SceneManager.LoadScene("Food Selection Info Menu");
    }
}
