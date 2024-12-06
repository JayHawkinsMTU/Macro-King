using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkModeToggle : MonoBehaviour
{
    public Toggle darkModeToggle;
    public static bool isDark;

    void Start()
    {
        isDark = PlayerPrefs.GetInt("isDark", 0) == 1;
        darkModeToggle.isOn = isDark;
        darkModeToggle.onValueChanged.AddListener(toggleHandler);
    }

    public void switchMode()
    {
        isDark = !isDark;
        darkModeToggle.onValueChanged.RemoveListener(toggleHandler);
        darkModeToggle.isOn = isDark;
        darkModeToggle.onValueChanged.AddListener(toggleHandler);

        
        DarkModeHandler handler = FindObjectOfType<DarkModeHandler>();
        handler.updateVisuals(isDark);

        PlayerPrefs.SetInt("isDark", isDark ? 1 : 0);
        PlayerPrefs.Save();
    }

    void toggleHandler(bool val)
    {
        isDark = val;

        PlayerPrefs.SetInt("isDark", isDark ? 1 : 0);
        PlayerPrefs.Save();

        DarkModeHandler handler = FindObjectOfType<DarkModeHandler>();
        handler.updateVisuals(isDark);
    }


}
