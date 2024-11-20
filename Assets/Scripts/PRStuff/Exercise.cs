using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[CreateAssetMenu(fileName = "New Exercise", menuName = "Exercise")]

/*
Create new exercise TYPE, f.e. Push up, Bench Press, etc.
*/
[Serializable]
public class Exercise
{
    private string name;
    public void newExercise(string s)
    {
        name = s;
    }
    public string getName()
    {
        return name;
    }
}
