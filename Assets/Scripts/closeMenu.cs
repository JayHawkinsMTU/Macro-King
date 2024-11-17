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
        setOpacity(0.5F);
    }

    public void setOpacity(float alpha)
    {
        canvasGroup.alpha = alpha;

    }
}
