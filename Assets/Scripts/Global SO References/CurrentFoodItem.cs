using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Current Food item", menuName ="Food/Current Food Item")]
public class CurrentFoodItem : ScriptableObject
{
    [SerializeField] public FoodItem currentItem;
}

