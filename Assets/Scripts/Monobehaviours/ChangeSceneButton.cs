using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] string sceneName;
    public static string sceneToReturn;
    
    public void ChangeScene()
    {
        sceneToReturn = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName); 
    }

    public void ReturnToScene()
    {
        SceneManager.LoadScene(sceneToReturn);
    }
}
