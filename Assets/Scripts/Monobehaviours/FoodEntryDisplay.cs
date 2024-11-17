using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodEntryDisplay : MonoBehaviour
{
    public FoodEntry entry;
    public TMP_Text title;
    public TMP_Text quantity;
    void Start()
    {
        if(entry == null) 
        {
            return;
        }
        string foodName = entry.food.FoodName;
        string qty = entry.qty.ToString();
        Debug.Log(qty);
        title.text = foodName;
        quantity.text = qty;
    }
}
