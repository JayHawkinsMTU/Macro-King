using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class closeMenu : MonoBehaviour
{
    public GameObject canvas;
    public CanvasGroup canvasGroup;
    public void hideMenu()
    {
        canvas.SetActive(false);
        setOpacity();
    }

    public void setOpacity()
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.interactable = true;

    }
}
