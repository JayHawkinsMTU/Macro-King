using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class openMenu : MonoBehaviour
{
    public GameObject canvas;
    public CanvasGroup canvasGroup;

    public void showMenu()
    {
        DirectoryPageHandler.onNutrition = true;
        canvas.SetActive(true);
        setOpacity();
    }

    public void setOpacity()
    {
        canvasGroup.alpha = 0.2F;
    }
}
