using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to represent how much food was eaten from a foodItem
/// </summary>
public class FoodItemQuantity 
{
    private FoodItem foodItem;
    private UnitValue consumedqtn;

    FoodItemQuantity(FoodItem foodItem, UnitValue qtn)
    {
        this.foodItem = foodItem;
        consumedqtn = qtn;
    }
    // Finish Unit Class
    public UnitValue Calories()
    {
        return consumedqtn;
    }

}
