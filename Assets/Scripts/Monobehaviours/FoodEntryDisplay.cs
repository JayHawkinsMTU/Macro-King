using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodEntryDisplay : MonoBehaviour
{
    public FoodEntry entry;
    public TMP_Text title;
    public TMP_Text quantity;
    void Awake()
    {
        if(entry == null) return;
        string foodName = entry.item.FoodName;
        string qty = entry.quantity.ToString("0.##");
        title.text = foodName;
        quantity.text = $"Qty: {qty} {FoodEntry.unitsToString[entry.unit]}";
    }
}
