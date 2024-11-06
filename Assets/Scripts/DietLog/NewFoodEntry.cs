using System.Collections;
using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Unity.VisualScripting;

public class NewFoodEntry : MonoBehaviour
{
    [SerializeField] InputField inputFood;
    [SerializeField] Text resultFood;
    
    public void ValidateInput() 
    {
    FoodEntry food = new FoodEntry();
    GameManager.DietList.addFoodItem(food.food);
    }

}