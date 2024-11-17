using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Stefan K: Changes text displayed on directory based on which menu is selected
/// </summary>

public class DirectoryPageHandler : MonoBehaviour
{
    public TMP_Text pageName;
    public TMP_Text pageName2;
    public TMP_Text pageName3;
    public static bool onNutrition = true;

    public void changeToNutrition()
    {
        pageName.text = "Calendar";
        pageName2.text = "Goals";
        pageName3.text = "Today";
        onNutrition = true;

    }

    public void changeToFitness()
    {
        pageName.text = "Fitness Placeholder";
        pageName2.text = "Fitness Placeholder 2";
        pageName3.text = "Fitness Placeholder 3";
        onNutrition = false;
    }


    
}
