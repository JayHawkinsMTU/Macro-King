using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutritionGoalList : MonoBehaviour
{
    // Assign prefab of a goal display entry here
    public RectTransform goalDisplay;
    public RectTransform content;

    // Minimum height of content object in scroll view
    private float minContentHeight = 300;
    // Distance between each goal display
    public float verticalPadding = 50;

    // Load list immediately
    void Awake()
    {
        User user = User.LoadUser();
        // Automatically adjust minimum based no what's in the editor
        minContentHeight = content.rect.height;
        // Number of elements to display
        int n = user.NutritionGoals.Count;
        // Desired height of "content" object in scroll view
        float contentHeight = Mathf.Clamp(n * (goalDisplay.rect.height + verticalPadding), minContentHeight, float.MaxValue);
        content.sizeDelta = new Vector2(content.rect.width, contentHeight);
        // Display all goals
        for(int i = 0; i < n; i++)
        {
            RectTransform rect = Instantiate(goalDisplay, content.transform);
            NutritionGoalDisplay ngd = rect.GetComponent<NutritionGoalDisplay>();
            ngd.goal = user.NutritionGoals[i];
            rect.anchoredPosition = new Vector2(0, i * -(rect.rect.height + verticalPadding));
        }

    }
}
