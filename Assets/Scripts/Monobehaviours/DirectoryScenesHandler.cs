using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Stefan K: Chooses which scene to change to based on which menu is selected
/// </summary>

public class DirectoryScenesHandler : MonoBehaviour
{
    public string nutritionSceneName;
    public string fitnessSceneName;

    public void changeScene()
    {
        ChangeSceneButton.sceneToReturn = SceneManager.GetActiveScene().name;
        if (DirectoryPageHandler.onNutrition)
        {
            SceneManager.LoadScene(nutritionSceneName);
        }
        else
        {
            SceneManager.LoadScene(fitnessSceneName);
        }
    }
}
