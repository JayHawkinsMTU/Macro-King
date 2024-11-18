using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Diet Log", menuName = "DietLog")]
public class DietLog : ScriptableObject
{
    [SerializeField]  List<FoodEntry> dietList = new List<FoodEntry>();
    public void addFoodItem(FoodEntry f)
    {
        dietList.Add(f);
    }

    public FoodEntry searchFoodItem(FoodEntry f)
    {
        int i = dietList.IndexOf(f);
        if(i < 0) {return null; }
        return dietList[i];
    }
    public void removeFoodItem(FoodEntry f)
    {
        int i = dietList.IndexOf(f);
        dietList.RemoveAt(i);
    }
    public List<FoodEntry> getList() //testing purpose : remove later
    {
        return dietList;
    }
}