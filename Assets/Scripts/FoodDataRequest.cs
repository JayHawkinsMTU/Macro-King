using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
//using Newtonsoft.Json.Linq;  // For parsing JSON (Install Newtonsoft.Json via NuGet or Unity Package Manager)


public class FoodDataRequest : MonoBehaviour
{
    // Your API key
    private string apiKey = "kt3fDVCgfMw7LSQfAdxF898dDjuQhsj4q2Q1eiXM";
    // Base URL for FoodData Central API
    private string baseUrl = "https://api.nal.usda.gov/fdc/v1/foods/search";

    void Start()
    {
        // Start the coroutine to make the API request
        StartCoroutine(GetFoodData("apple", pageNumber:"1", pageSize:10));
    }

    IEnumerator GetFoodData(string query, string pageNumber = "", int pageSize = 10 )
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
                string jsonResponse = request.downloadHandler.text;
                //DisplayFoodNamesAndCalories(jsonResponse);

                // Save JSON to a file
                SaveJsonToFile(jsonResponse, "Page1Test.json");
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



}
