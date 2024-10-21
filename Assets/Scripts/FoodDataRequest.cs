using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;
using TMPro;
using System.Collections.Generic;
//using Newtonsoft.Json.Linq;  // For parsing JSON (Install Newtonsoft.Json via NuGet or Unity Package Manager)


public class FoodDataRequest : MonoBehaviour
{
    [SerializeField] int currentPage = 1;
    [SerializeField] IntVariable resultsPerPage;
    [SerializeField] SearchFoodResults SearchResultsScriptableObject;
    [SerializeField] List<string> queries = new List<string>();
    [SerializeField] GameEvent QueryComplete;
    // Your API key
    private string apiKey = "kt3fDVCgfMw7LSQfAdxF898dDjuQhsj4q2Q1eiXM";
    // Base URL for FoodData Central API
    private string baseUrl = "https://api.nal.usda.gov/fdc/v1/foods/search";

    int CurrentPage {
        get => currentPage;
        set {
            if (value <= 1) { currentPage = 1; }
            currentPage = value;
        }
    }

    TMP_InputField searchBar;

    void Start()
    {
        // Start the coroutine to make the API request
        //StartCoroutine(GetFoodData("apple", pageNumber:"1", pageSize:resultsPerPage.Value, saveToJSON:true));
        searchBar = GetComponent<TMP_InputField>();
    }

    public void OnPrevPG()
    {
        CurrentPage = CurrentPage - 1;
        UpdateSearch();
    }
    public void OnNextPG()
    {
        CurrentPage = CurrentPage + 1;
        UpdateSearch();
    }
    public void UpdateSearch()
    {
        var query = searchBar.text;
        queries.Add(query);
        Debug.Log("Starting coroutine");
        StartCoroutine(
            GetFoodData(
                query, 
                pageNumber: CurrentPage.ToString(), 
                pageSize: resultsPerPage.Value,
                saveToJSON: false,
                triggerGameEvent: true
            ) );
    }

    IEnumerator GetFoodData(string query, string pageNumber = "", int pageSize = 10, bool saveToJSON = false, bool triggerGameEvent = false)
    {
        // Build the complete URL with query parameters
        var pg_num = "";
        if(pageNumber != "") { pg_num = "&pageNumber=" + pageNumber; }
        string url = $"{baseUrl}?query={query}{pg_num}&pageSize={pageSize}&api_key={apiKey}";

        // Make the request
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            // Send the request and wait for a response
            yield return request.SendWebRequest();

            // Check for errors
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error: {request.error}");
            }
            else
            {
                // Successful response
                string jsonResponse_str = request.downloadHandler.text;
                // Save JSON to a file
                if (saveToJSON) { SaveJsonToFile(jsonResponse_str, "Page1Test.json"); }

                // Convert to JObject
                JObject jsonResponse = JObject.Parse(jsonResponse_str);
                //DisplayFoodNamesAndCalories(jsonResponse);

                SearchResultsScriptableObject.AddResult(jsonResponse);
                // Trigger Game Event
                if (triggerGameEvent) { QueryComplete.Raise(); }

            }
        }
    }
    void SaveJsonToFile(string jsonData, string fileName)
    {
        // Path to save the file in the Unity project directory
        string path = Path.Combine(Application.dataPath, fileName);

        // Write the JSON data to the file
        File.WriteAllText(path, jsonData);

        Debug.Log($"JSON data saved to {path}");
    }

   
    void DisplayFoodNamesAndCalories(string json)
    {
        // Parse the JSON response using JObject (from Newtonsoft.Json)
        JObject parsedData = JObject.Parse(json);
        DisplayFoodNamesAndCalories(parsedData);
    }
    void DisplayFoodNamesAndCalories(JObject json)
    {
        // Extract the "foods" array from the JSON
        JArray foods = (JArray)json["foods"];

        Debug.Log("Length of Foods" + foods.Count);

        if (foods != null)
        {
            foreach (var food in foods)
            {
                Debug.Log(food["description"]);
                string name = food["description"]?.ToString();  // Food name
                string calories = food["foodNutrients"]?.FirstOrDefault(n => (string)n["nutrientName"] == "Energy")?["value"]?.ToString();  // Calorie count

                Debug.Log($"Food: {name}, Calories: {calories} kcal");
            }
        }
        else
        {
            Debug.LogWarning("No foods found in the response.");
        }
    }
}
