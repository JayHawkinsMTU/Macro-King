using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName ="New User", menuName ="User")]
[Serializable]
public class User : ScriptableObject
{
    // For some reason { get; set } messes with serialization, so I had to remove it from
    // All attributes to save properly. -Jay
    public static User instance;
    // User fields
    public string Name = "NO_NAME";
    [SerializeField] public List<Allergen> Allergens = new();
    [SerializeField] public List<FoodEntry> Nutrition = new();

    [SerializeField] public List<FoodItem> FavoriteFoods = new();
    [SerializeField] public List<NutritionGoal> NutritionGoals = new();
    [SerializeField] public List<PersonalRecords> PRs = new();
    /// <summary>
    /// A mapping from day to data for that day. Should only use date, not time in key.
    /// </summary>
    public Dictionary<DateTime, DailyNutrition> nutritionCalendar = new();
    [SerializeField] public PRHolder PRlist;

    public void AddFavoriteFood(FoodItem food)
    {
        FavoriteFoods.Add(food);
    }

    /// <summary>
    /// Returns proper day from calendar. Initializes new DailyNutrition (day) if there's no data for that day.
    /// </summary>
    /// <param name="day">The day to select. Should be date only, no time</param>
    /// <returns>DailyNutrition of day from nutritionCalendar</returns>
    public static DailyNutrition GetDay(DateTime day)
    {
        if(!instance.nutritionCalendar.ContainsKey(day))
        {
            instance.nutritionCalendar.Add(day, new DailyNutrition());
        }
        return instance.nutritionCalendar[day];
    }
    public void addPR(PersonalRecords pr)
    {
        PRs.Add(pr);
    }

    // Save user data to disk
    public static void SaveUser()
    {
        string path = Path.Combine(Application.persistentDataPath, string.Concat(instance.name, ".json"));
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            string dataToStore = JsonUtility.ToJson(instance, true);

            // Overwrte file or create new one.
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + path + "\n" + e);
        }
    }

    // Loads user data from disk
    public static User LoadUser(string username = "NO_NAME")
    {
        // User has already been loaded, return instance.
        if(instance != null)
        {
            return instance;
        }

        string path = Path.Combine(Application.persistentDataPath, string.Concat(username, ".json"));

        User loadedData = null;
        if(File.Exists(path))
        {
            try
            {
                // Read data as a json string from file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                // Loads data from string
                loadedData = JsonUtility.FromJson<User>(dataToLoad);
                instance = loadedData;
            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + path + "\n" + e);
            }
        }
        else
        {
            instance = new();
        }

        /* EXAMPLE DATA
        instance = new();
        instance.nutritionCalendar.Add(DateTime.Today, new DailyNutrition());
        List<FoodEntry> todaysFoods = instance.nutritionCalendar[DateTime.Today].foodEntries;

        for(int i = 0; i < 10; i++) 
        {
            instance.NutritionGoals.Add(new NutritionGoal(NutritionGoal.Macro.CALORIES, NutritionGoal.Condition.CLOSE_TO, 2000 + i));
            // Add multiple instances of default food item to today
            instance.Nutrition.Add(new FoodEntry());
            //todaysFoods.Add(new FoodEntry());
        }
        */

        return instance;
    }
}

