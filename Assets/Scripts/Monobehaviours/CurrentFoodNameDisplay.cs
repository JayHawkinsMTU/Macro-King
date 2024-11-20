// Jay Hawkins
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Changes the attached text to the name of the current food item.
/// </summary>
public class CurrentFoodNameDisplay : MonoBehaviour
{
    void Awake()
    {
        if(GameManager.CurrentFoodItem == null) return;
        GetComponent<TMP_Text>().text = GameManager.CurrentFoodItem.foodName;
    }
}
