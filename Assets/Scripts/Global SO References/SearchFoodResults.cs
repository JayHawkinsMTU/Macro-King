using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[CreateAssetMenu(fileName = "New Search Food Results", menuName = "Search Food Results")]

public class SearchFoodResults : ScriptableObject
{
    [SerializeField] private SearchFoodResult_Singular currentResults = new SearchFoodResult_Singular(null);
    [SerializeField] private SearchFoodResult_Singular previousResults = new SearchFoodResult_Singular(null);

    public SearchFoodResult_Singular CurrentResults { get => currentResults; }
    public SearchFoodResult_Singular PreviousResults { get => previousResults;}
    

    public void AddResult(JObject result)
    {
        previousResults.JObject = currentResults.JObject;
        currentResults.JObject = result;
        OnNewResults();
    }

    public void OnNewResults()
    {
        Debug.Log("New Result Added!");
    }


}
