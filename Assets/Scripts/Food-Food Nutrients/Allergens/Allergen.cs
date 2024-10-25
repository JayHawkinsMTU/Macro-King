using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Allergen", menuName ="Food/Allergen")]
public class Allergen : ScriptableObject
{
    [SerializeField] string allergen;
    //[SerializeField] public List<FoodNutrients> nutrientsAssociatedWithAllergen;
    public string AllergenName { get => allergen; }
    public override string ToString()
    {
        return allergen;
    }
}
