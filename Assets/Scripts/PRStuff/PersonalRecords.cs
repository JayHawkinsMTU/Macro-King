using System;
using UnityEngine;
[CreateAssetMenu(fileName = "Personal Record", menuName = "Personal Records")]

/*
Constructor to make a new workout

TODO:
Implement time to be a better construct of hours:minutes:seconds rather than current date
Maybe ask the user for a comma seperated list and store in a hashmap
*/
[Serializable]
public class PersonalRecords 
{
    [SerializeField] int weight;
    [SerializeField] Exercise exercise;
    [SerializeField] int reps;
    [SerializeField] int type;
    [SerializeField] int time;
    [SerializeField] float distance;
    public string exerciseName = "unchanged"; //update this later to take in user input
    
    public int Weight { get => weight; set => weight = value; }
    public Exercise Exercise { get => exercise; set => exercise = value; }
    public int Reps { get => reps; set => reps = value; }
    public int Type { get => type; set => type = value; }
    public int Time { get => time; set => time = value; }
    public float Distance { get => distance; set => distance = value; }
    public int getTime()
    {
        return time;
    }

    public void NewExercise(int weight, Exercise exercise, int time, float distance, int type, int reps) 
    {
        this.weight = weight;
        this.Exercise = exercise;
        this.type = type;
        this.reps = reps;
        this.time = time;
        this.distance = distance;
        // Exercise.newExercise(exercise.ToString()); going to keep this as a reference but I don't think that this step is necessary
        exerciseName = exercise.getName();
    }

}