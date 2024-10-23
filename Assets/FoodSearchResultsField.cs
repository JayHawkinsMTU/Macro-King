using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class FoodSearchResultsField : MonoBehaviour
{
    [SerializeField] SearchFoodResults searchResults;
    [SerializeField] ObjectPool resultObjectPool;
    public void UpdateResults()
    {
        // Clear Previous Search Results
        resultObjectPool.ReturnFullPool();

        JObject json = searchResults.CurrentResults.JObject;
        List<JToken> foods = ((JArray)json["foods"]).ToList();

        
        if (foods != null)
        {
            foreach (var food in foods)
            {
                GameObject obj = resultObjectPool.GetObject();
                FoodSearchResultEntry foodSearchResult = obj.GetComponent<FoodSearchResultEntry>();
                if(foodSearchResult != null)
                {
                    foodSearchResult.setData(food);
                }
                else
                {
                    Debug.LogError("Search Result Pool unable to find a FoodSearchResultEntry");
                }
            }
        }

    }


}
