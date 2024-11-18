using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Exercise List", menuName = "Exercise List")]
/*
Class to hold a list of exercise TYPES, not the entire workout
*/
public class ExerciseHolder : ScriptableObject 
{
    [SerializeField] List<Exercise> eList = new List<Exercise>();
    public void AddExerciseToList(Exercise e) 
    {
        eList.Add(e);
    }
    public List<Exercise> getList() 
    {
        return eList;
    }
    public Exercise ExerciseSearch(Exercise e)
    {
        int i = eList.IndexOf(e);
        if(i < 0) { return null; }
        return eList[i];
}
}