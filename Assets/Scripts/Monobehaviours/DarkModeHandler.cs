using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DarkModeHandler : MonoBehaviour
{
    public static bool isDark = true;
    public GameObject canvas;
    public Camera mainCam;

    void Start()
    {
        if (isDark)
        {
           // tmp.color = Color.white;
        }
        else
        {
            //tmp.color = Color.black;
        }
    }

    void Update()
    {
        TMP_Text[] textObjs = FindObjectsOfType<TMP_Text>();
        GameObject[] images = GameObject.FindGameObjectsWithTag("dark");
        if (isDark)
        {
            foreach(TMP_Text textObj in textObjs)
            {
                textObj.color = Color.white;
            }

            
            foreach (GameObject img in images)
            {
                Image img2 = img.GetComponent<Image>();
                img2.color = Color.white;
            }
        }
        else
        {
            foreach (TMP_Text textObj in textObjs)
            {
                textObj.color = Color.black;
            }

            foreach (GameObject img in images)
            {
                Image img2 = img.GetComponent<Image>();
                img2.color = Color.black;
            }
        }
    }

    public void switchMode()
    {
        if(isDark)
        {
            isDark = false;
        }
        else
        {
            isDark = true;
        }
    }

}
