using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName ="New User", menuName ="User")]
public class User : ScriptableObject
{

    // User fields
    [SerializeField] public string Name { get; set; } = "NO_NAME";
    [SerializeField] public List<FoodItem.Allergens> Allergens { get; private set; } = new();
    [SerializeField] public List<FoodItem> Nutrition { get; private set; } = new();
    [SerializeField] public List<NutritionGoal> NutritionGoals { get; private set; } = new();
    [SerializeField] public List<PersonalRecords> PRs { get; private set; } = new();

}

