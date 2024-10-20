using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Personal Record List", menuName = "Personal Records List")]
public class PRHolder : ScriptableObject
{
    [SerializeField] List<PersonalRecords> PRList = new List<PersonalRecords>();
    public void OnPressed() 
    {
        
    }
   
    public void AddExercise(PersonalRecords PR) 
    {
        PRList.Add(PR);
    }

}