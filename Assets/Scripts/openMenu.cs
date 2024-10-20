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
        canvas.SetActive(true);
        setOpacity(0.5F);
    }

    public void setOpacity(float alpha)
    {
        canvasGroup.alpha = alpha;

    }
}
