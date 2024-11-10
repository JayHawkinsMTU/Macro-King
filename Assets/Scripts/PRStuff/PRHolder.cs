using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Personal Record List", menuName = "Personal Records List")]




/*
List Class that holds all of the PRS
*/
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
    public List<PersonalRecords> GetList() 
    {
        return PRList;
    }

    public PersonalRecords PRSearch(PersonalRecords PR)
    {
        int i = PRList.IndexOf(PR);
        if (i<0) {return null; }
        return PRList[i];
    }

}