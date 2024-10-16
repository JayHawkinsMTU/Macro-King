using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PageNumberUpdater : MonoBehaviour
{
    TMP_Text TMP;
    [SerializeField] SearchFoodResults searchResults;
    [SerializeField] IntVariable resultsPerPage;
    void Awake()
    {
        TMP = gameObject.GetComponent<TMP_Text>();
    }
    private void Start()
    {
        try
        {
            var x = searchResults.CurrentResults.CurrentPage;
            var y = searchResults.CurrentResults.TotalHits;
            var z = resultsPerPage.Value;

            UpdateText(x, y, z);
        }
        catch(Exception e)
        {
            UpdateText("---");
        }

    }

    public void UpdateText(int CurrentPage, int TotalHits, int ResultsPerPage)
    { 
        UpdateText( $"Showing {CurrentPage*ResultsPerPage} / {TotalHits}" );
    }
    public void UpdateText(string text)
    {
        if (TMP == null) { return; }
        TMP.text = text;
    }

    public void UpdateText()
    {
        try
        {
            var x = searchResults.CurrentResults.CurrentPage;
            var y = searchResults.CurrentResults.TotalHits;
            var z = resultsPerPage.Value;

            UpdateText(x, y, z);
        }
        catch (Exception e)
        {
            UpdateText("Update text failed! Exception:" + e);
        }
    }
}
