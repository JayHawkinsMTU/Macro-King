using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Diet Log", menuName = "DietLog")]
public class DietLog : ScriptableObject
{
    [SerializeField]  List<FoodItem> dietList = new List<FoodItem>();
    public void addFoodItem(FoodItem f)
    {
        dietList.Add(f);
    }

    public FoodItem searchFoodItem(FoodItem f)
    {
        int i = dietList.IndexOf(f);
        if(i < 0) {return null; }
        return dietList[i];
    }
    public List<FoodItem> getList() //testing purpose : remove later
    {
        return dietList;
    }
}