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
    /*
    ALL SETTERS RETURN OLD VALUE
    */
    int getWeight() 
    {
        return weight;
    }
    int setWeight(int weight) 
    {
        int w = this.weight;
        this.weight = weight;
        return w;
    }
    string getExercise()
    {
        return exercise;
    }
    string setExercise(string exercise) 
    {
        string e = this.exercise;
        this.exercise = exercise;
        return e;
    }
    int getType()
    {
        return type;
    }
    int setType(int type)
    {
        int t = this.type;
        this.type = type;
        return t;
    }
    int getReps()
    {
        return reps;
    }
    int setReps(int reps)
    { 
        int r = this.reps;
        this.reps = reps;
        return r;
    }
    DateTime getTime()
    {
        return time;
    }
    DateTime setTime(DateTime time) 
    {
        DateTime t = this.time;
        this.time = t;
        return t;
    }
    float getDistance()
    {
        return distance;
        
    }
    float setDistance(float distance)
    {
        float d = this.distance;
        this.distance = distance;
        return d;
    }
}