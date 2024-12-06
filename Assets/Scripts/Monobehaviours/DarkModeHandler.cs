using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DarkModeHandler : MonoBehaviour
{  
    public GameObject canvas;
    public Camera mainCam;
    private TMP_Text[] textObjs;
    private GameObject[] images;
    private GameObject[] backgrounds;
    private Color lightBg;
    private Color darkBg;
    private Color darkCam;
    private Color lightCam;


    void Start()
    {
        textObjs = FindObjectsOfType<TMP_Text>();
        images = GameObject.FindGameObjectsWithTag("dark");
        backgrounds = GameObject.FindGameObjectsWithTag("bg");     
        ColorUtility.TryParseHtmlString("#648DB7", out lightBg);   
        ColorUtility.TryParseHtmlString("#1B3247", out darkBg);        
        ColorUtility.TryParseHtmlString("#20374C", out darkCam);        
        ColorUtility.TryParseHtmlString("#7FA9CB", out lightCam);
        updateVisuals(PlayerPrefs.GetInt("isDark", 0) == 1);
    }

    public void updateVisuals(bool isDark)
    {
        if (isDark)
        {
            changeToDark();
        }
        else
        {
            changeToLight();
        }
    }

    public void changeToDark()
    {
        foreach (TMP_Text textObj in textObjs)
        {
            textObj.color = Color.white;
        }

        foreach (GameObject img in images)
        {
            Image img2 = img.GetComponent<Image>();
            img2.color = Color.white;
        }

        foreach (GameObject bg in backgrounds)
        {
            Image bgs = bg.GetComponent<Image>();
            bgs.color = darkBg;
        }

        if(mainCam != null)
        {
            mainCam.backgroundColor = darkCam;
        }
        
    }

    public void changeToLight()
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

        foreach (GameObject bg in backgrounds)
        {
            Image bgs = bg.GetComponent<Image>();
            bgs.color = lightBg;
        }

        if (mainCam != null)
        {
            mainCam.backgroundColor = lightCam;
        }  
    }

}
