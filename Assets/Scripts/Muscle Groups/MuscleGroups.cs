using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Muscle Group", menuName = "Muscle Group")]
public class MuscleGroups : ScriptableObject
{
    [SerializeField] string name = "";
    [SerializeField] Sprite image = null;
    [SerializeField] List<Muscle> MusclesInGroup = new List<Muscle>();
}
