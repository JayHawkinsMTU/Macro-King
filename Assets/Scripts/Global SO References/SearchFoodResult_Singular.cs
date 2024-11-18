using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class SearchFoodResult_Singular
{
    JObject jObject;
    public JObject JObject { get => jObject; set => jObject = value; }
    public SearchFoodResult_Singular(JObject j)
    {
       jObject = j;
    }
    public int TotalPages
    {
        get => (int)(JObject?["totalPages"] ?? 0);  // Default to 0 if null
    }

    public int CurrentPage
    {
        get => (int)(JObject?["currentPage"] ?? 0);  // Default to 0 if null
    }

    public int TotalHits
    {
        get => (int)(JObject?["totalHits"] ?? 0);  // Default to 0 if null
    }

    public List<int> PageList
    {
        get
        {
            JToken pageListToken = JObject?["pageList"];
            return pageListToken?.ToObject<List<int>>() ?? new List<int>();
        }
    }



    // Explicit cast operator from JObject to SearchFoodResult_Singular
    public static explicit operator SearchFoodResult_Singular(JObject obj)
    {
        return obj == null ? null : new SearchFoodResult_Singular(obj);
    }

    // Explicit cast operator from SearchFoodResult_Singular to JObject
    public static explicit operator JObject(SearchFoodResult_Singular singular)
    {
        if (singular == null)
        {
            return null;
        }
        return singular.jObject;
    }
}
