using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NutrientDisplayPool : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private ScrollRect scrollView;
    [SerializeField] private RectTransform content;
    private float entryHeight;

    private void Start()
    {
        GameObject tempDisplay = objectPool.GetObject();
        entryHeight = ((RectTransform)tempDisplay.transform).rect.height;
        objectPool.ReturnObject(tempDisplay);

        DisplayCurrentFoodItem();
    }

    public void DisplayCurrentFoodItem()
    {
        objectPool.ReturnFullPool();

        if (GameManager.CurrentFoodItem == null) return;

        var nutrients = GameManager.CurrentFoodItem.FoodNutrientQuantities;
        content.sizeDelta = new Vector2(content.sizeDelta.x, nutrients.Count * entryHeight);

        int index = 0;
        foreach (var nutrient in nutrients)
        {
            GameObject display = objectPool.GetObject();
            RectTransform rect = display.GetComponent<RectTransform>();

            // Start from content height and move down
            rect.anchoredPosition = new Vector2(0, - (index * entryHeight));

            var nutrientDisplay = display.GetComponent<NutritionLabelEntry>();
            nutrientDisplay.SetNutrient(nutrient.Key, nutrient.Value);

            index++;
        }
    }
}
