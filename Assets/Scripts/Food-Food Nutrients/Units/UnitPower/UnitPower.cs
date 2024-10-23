using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Unit Power", menuName = "Food/Unit/Unit Power")]

public class UnitPower : ScriptableObject
{
    [SerializeField] public string prefix;
    [SerializeField] public float multiplicity;
}
