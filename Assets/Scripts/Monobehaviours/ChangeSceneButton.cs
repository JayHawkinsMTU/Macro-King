using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] string sceneName;
    public static bool showBackBtn;
    public static string sceneToReturn;

    public void ChangeScene()
    {      
        showBackBtn = true;
        sceneToReturn = SceneManager.GetActiveScene().name;
        Debug.Log("Scene to return to set to: " + sceneToReturn);
        if (sceneToReturn == sceneName)
        {
            showBackBtn = false;
        } 
        SceneManager.LoadScene(sceneName); 
    }

    public void ReturnToScene()
    {
        SceneManager.LoadScene(sceneToReturn);
        sceneToReturn = SceneManager.GetActiveScene().name;
        Debug.Log("Scene to return to updated to: " + ChangeSceneButton.sceneToReturn);
    }
}
