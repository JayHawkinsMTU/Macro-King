using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class calChangeScene : MonoBehaviour
{
    
    public static int dayToSave;

    public void ChangeScene()
    {
        TMP_Text display = GetComponentInChildren<TMP_Text>();

        if (display != null)
        {
            dayToSave = int.Parse(display.text);
        }

        SceneManager.LoadScene("Daily Nutrition");
    }
}
