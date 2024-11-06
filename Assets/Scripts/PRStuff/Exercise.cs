using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Exercise", menuName = "Exercise")]

/*
Create new exercise TYPE, f.e. Push up, Bench Press, etc.
*/
public class Exercise : ExerciseBase
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
