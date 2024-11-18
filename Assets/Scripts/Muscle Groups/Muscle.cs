using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Muscle", menuName = "Muscle")]
public class Muscle : ScriptableObject
{
    [SerializeField] string muscleName = "";
    [SerializeField] Sprite image = null;

}
