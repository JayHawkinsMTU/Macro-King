using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Jay Hawkins
/// <summary>
/// Lists all foodentries for a given day.
/// </summary>
public class FoodEntryDisplayList : MonoBehaviour
{
    // Assign prefab of a goal display entry here
    public RectTransform entryDisplay;
    public RectTransform content;

    // Minimum height of content object in scroll view
    private float minContentHeight = 300;
    // Distance between each goal display
    public float verticalPadding = 50;

    // Load list immediately
    void Awake()
    {
        User.LoadUser();
        DailyNutrition thisDay = User.GetDay(DailyNutrition.selectedDate);
        // Automatically adjust minimum based no what's in the editor
        minContentHeight = content.rect.height;
        // Number of elements to display
        int n = thisDay.foodEntries.Count;
        // Desired height of "content" object in scroll view
        float contentHeight = Mathf.Clamp(n * (entryDisplay.rect.height + verticalPadding), minContentHeight, float.MaxValue);
        content.sizeDelta = new Vector2(content.rect.width, contentHeight);
        // Display all goals
        for(int i = 0; i < n; i++)
        {
            RectTransform rect = Instantiate(entryDisplay, content.transform);
            FoodEntryDisplay fed = rect.GetComponent<FoodEntryDisplay>();
            fed.entry = thisDay.foodEntries[i];
            rect.anchoredPosition = new Vector2(0, i * -(rect.rect.height + verticalPadding));
        }

    }
}
