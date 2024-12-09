using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class openMenu : MonoBehaviour
{
    public GameObject canvas;
    public CanvasGroup canvasGroup;
    public GameObject canvas2;

    public void showMenu()
    {
        canvas.SetActive(true);
        setOpacity();
    }

    public void showSecondMenu()
    {
        canvas2.SetActive(true);
        setOpacity();
    }

    public void setOpacity()
    {
        canvasGroup.alpha = 0.2F;
        canvasGroup.interactable = false;
    }
}
