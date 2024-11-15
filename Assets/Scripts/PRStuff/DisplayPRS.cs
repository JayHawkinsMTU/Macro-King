using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
/*
This class will be used to display the prs on the pr page for the fitness section
*/
public class DisplayPRS : MonoBehaviour
{
    public int i;
    public RectTransform content;
    public RectTransform prDisplay;
    public float minimumContentHeight = 300;
    public float verticalPad = 50;
    
    void Awake()
    {
        
        int n = GameManager.PRList.GetList().Count();
        minimumContentHeight = content.rect.height;
        float contentVertHeight = Mathf.Clamp(n * (prDisplay.rect.height + verticalPad), minimumContentHeight, float.MaxValue);
        content.sizeDelta = new Vector2(content.rect.width, contentVertHeight);
        for(int i = 0; i < n; i++) 
        {
            RectTransform rect = Instantiate(prDisplay, content.transform);
            PRGoalFormat pgf = rect.GetComponent<PRGoalFormat>();
            pgf.pr = GameManager.PRList.GetList()[i];
            rect.anchoredPosition = new Vector2(0, i * -(rect.rect.height + verticalPad));
        }
    }
    
}