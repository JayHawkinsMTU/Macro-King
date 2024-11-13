using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
/*
This class will be used to display the prs on the pr page for the fitness section
*/
public class DisplayPRS : MonoBehaviour
{
    public RectTransform content;
    int n = GameManager.PRList.GetList().Count();
    
}