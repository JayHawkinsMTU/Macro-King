using System.Collections;
using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class NewFoodItem : MonoBehaviour
{
    [SerializeField] InputField inputFood;
    [SerializeField] Text resultFood;

    //transfer data to be a food item


    //check to see if the food item already exists in the fooditem folder
    FoodItem food;
    // string newName = "";
    // bool exists = false;
    // DirectoryInfo dir = new DirectoryInfo("Assets/Scripts/Food-Food Nutrients/FoodItems");
    // FileInfo[] info = dir.GetFiles("*.prefab");
    // var foodNames = info.Select(f => f).ToArray();
    // foreach (FoodItem f in foodNames) 
    // {
    //     if(newName = f.foodName)
    //     {
    //         exists = true;
    //         food = f;
    //     }
    // }
    // if(!exists) 
    // {
    //     food = ScriptableObject.CreateInstance<NewFoodItem>();
    //     food.createFoodItem(newName);
    // }

    //add the food item to the list
    // Commented out bc errors so I can work on other things. -Jay
    //GameManager.DietList.addFoodItem(food);
    //AssetDatabase.SaveAssetIfDirty(Gamemanager.DietList);



}