using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class FoodDataRequest : MonoBehaviour
{
    // Your API key
    private string apiKey = "kt3fDVCgfMw7LSQfAdxF898dDjuQhsj4q2Q1eiXM";
    // Base URL for FoodData Central API
    private string baseUrl = "https://api.nal.usda.gov/fdc/v1/foods/search";

    void Start()
    {
        // Start the coroutine to make the API request
        StartCoroutine(GetFoodData("apple"));
    }

    IEnumerator GetFoodData(string query)
    {
        // Build the complete URL with query parameters
        string url = $"{baseUrl}?query={query}&pageSize=10&api_key={apiKey}";

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
                Debug.Log(jsonResponse);

                // Save JSON to a file
                SaveJsonToFile(jsonResponse, "API_CALL.json");
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
