using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkModeToggle : MonoBehaviour
{
    void Start()
    {
        DarkModeHandler.isDark = true;
    }
    public void switchMode()
    {
        DarkModeHandler.isDark = !DarkModeHandler.isDark;
        PlayerPrefs.SetInt("isDark", DarkModeHandler.isDark ? 1 : 0);
        PlayerPrefs.Save();

        DarkModeHandler handler = FindObjectOfType<DarkModeHandler>();
        handler.updateVisuals();
    }

    
}
