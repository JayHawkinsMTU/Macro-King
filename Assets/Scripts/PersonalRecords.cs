using System;


public class PersonalRecords 
{
    int weight;
    string exercise;
    int reps;
    int type;
    DateTime time;
    float distance;
    
    void NewExercise(int weight, string exercise, int type, int reps, DateTime time, float distance) 
    {
        this.weight = weight;
        this.exercise = exercise;
        this.type = type;
        this.reps = reps;
        this.time = time;
        this.distance = distance;
    }
    int getWeight() 
    {
        return weight;
    }
    int setWeight(int weight) 
    {
        this.weight = weight;
    }
    string getExercise()
    {
        return exercise;
    }
    string setExercise(string e) 
    {
        exercise = e;
    }
    int getType()
    {
        return type;
    }
    int setType(int t)
    {
        type = t;
    }
    int getReps()
    {
        return reps;
    }
    int setReps(int r)
    { 
        reps = r;
    }
    DateTime getTime()
    {
        return time;
    }
    DateTime setTime(DateTime t) 
    {
        time = t;
    }
    float getDistance()
    {
        return distance;
    }
    float setDistance(float d)
    {
        distance = d;
    }
}