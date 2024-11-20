using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NutritionLabelEntry : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI nutrientNameText;
    [SerializeField] private TextMeshProUGUI valueText; //value + units

    public void SetNutrient(int nutrientId, UnitValue value)
    {
        var nutrient = GameManager.foodNutrientsDictionary.GetFood(nutrientId);
        nutrientNameText.text = nutrient.ToString();
        valueText.text = value.ToString();
    }

}
