using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodItem
{
    public enum Allergens {
        Peanut,
        Soy,
        Gluten,
        Dairy,
        Shellfish,
        Treenuts
    };
    //food item data
    private int foodID;
    private List<Allergens> allergens = new List<Allergens>();
}
