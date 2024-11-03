using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FoodSelectionInfoMenuInitializer : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI foodNameText; //displays the name of the FoodItem at the top

    private FoodItem foodItem;
    private Dictionary<int, UnitValue> foodNutrientQualities;


    void OnRectTransformDimensionsChange()
    {
        updateText();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Entering the food selection/info menu.");
        if (GameManager.CurrentFoodItem != null)
        {
            foodItem = GameManager.CurrentFoodItem;
            foodNutrientQualities = foodItem.FoodNutrientQuantities;
            Debug.Log("Current Food Item: " + GameManager.CurrentFoodItem.ToString());
            
            // Update the UI
            updateText();
        }
        else
        {
            Debug.Log("No food item selected (must've started from debug).");
        }


    }

    //update the name of the fooditem at the top of the screen
    void updateText()
    {
        //--------------------------------------------------------------------------------------
        // Update food name margins and text
        float parentWidth = foodNameText.transform.parent.GetComponent<RectTransform>().rect.width; // Get parent's (Canvas') width
        Vector4 margins = foodNameText.margin;  // Get current margins
        margins.z = -parentWidth/2;         // Modify right margin
        foodNameText.margin = margins;          // Set modified margins back

        foodNameText.text = foodItem.FoodName;
        //--------------------------------------------------------------------------------------
    }
}
