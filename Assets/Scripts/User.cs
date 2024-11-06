using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName ="New User", menuName ="User")]
public class User : ScriptableObject
{
    public static User instance;
    // User fields
    [SerializeField] public string Name { get; set; } = "NO_NAME";
    [SerializeField] public List<Allergen> Allergens { get; private set; } = new();
    [SerializeField] public List<FoodEntry> Nutrition { get; private set; } = new();

    [SerializeField] public List<FoodItem> FavoriteFoods { get; private set; } = new();
    [SerializeField] public List<NutritionGoal> NutritionGoals { get; private set; } = new();
    [SerializeField] public List<PersonalRecords> PRs { get; private set; } = new();

    [SerializeField] public PRHolder PRlist;

    // Loads user data from disk
    public static User LoadUser()
    {
        // User has already been loaded, return instance.
        if(instance != null)
        {
            return instance;
        }
        // FOR NOW THIS WILL JUST LOAD EXAMPLE DATA FOR TESTING
        // LOAD ACTUAL DATA LATER
        instance = new();
        for(int i = 0; i < 10; i++) 
        {
            instance.NutritionGoals.Add(new NutritionGoal(NutritionGoal.Macro.CALORIES, NutritionGoal.Condition.CLOSE_TO, 2000 + i));
            // Add multiple instances of default food item
            instance.Nutrition.Add(new FoodEntry());
        }
        return instance;
    }

    public void AddFavoriteFood(FoodItem food)
    {
        FavoriteFoods.Add(food);
    }
}

