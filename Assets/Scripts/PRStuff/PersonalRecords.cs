using System;
using UnityEngine;
[CreateAssetMenu(fileName = "Personal Record", menuName = "Personal Records")]
public class PersonalRecords : PRBase
{
    [SerializeField] int weight;
    [SerializeField] Exercise exercise;
    [SerializeField] int reps;
    [SerializeField] int type;
    [SerializeField] DateTime time;
    [SerializeField] float distance;
    
    public int Weight { get => weight; set => weight = value; }
    public Exercise Exercise { get => exercise; set => exercise = value; }
    public int Reps { get => reps; set => reps = value; }
    public int Type { get => type; set => type = value; }
    public DateTime Time { get => time; set => time = value; }
    public float Distance { get => distance; set => distance = value; }

    void NewExercise(int weight, Exercise exercise, DateTime time, float distance, int type, int reps) 
    {
        this.weight = weight;
        this.Exercise = exercise;
        this.type = type;
        this.reps = reps;
        this.time = time;
        this.distance = distance;
    }

}