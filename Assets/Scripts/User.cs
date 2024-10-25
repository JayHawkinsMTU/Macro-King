using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class User
{
    public static User instance;
    public string name = "NO_NAME";
    public List<FoodItem.Allergens> allergens = new();
    public List<FoodItem> nutrition = new();
    public List<NutritionGoal> nutritionGoals = new();
    public List<PersonalRecords> prs = new();
}
