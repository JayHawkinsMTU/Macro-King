using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewExerciseEntry : MonoBehaviour
{
    [SerializeField] InputField inputWeight;
    [SerializeField] InputField inputExercise;
    [SerializeField] InputField inputTime;
    [SerializeField] InputField inputDistance;
    [SerializeField] InputField inputType;
    [SerializeField] InputField inputReps;

    /*
    Need more input fields for the exercise data
    */
    [SerializeField] Text resultWeight;
    [SerializeField] Text resultExercise;
    [SerializeField] Text resultTime;
    [SerializeField] Text resultDistance;
    [SerializeField] Text resultType;
    [SerializeField] Text resultReps;
    
    
    public void ValidateInput()
    {   
        int weight = Int32.Parse((string) inputWeight.text);
        Exercise exercise = new Exercise();
        exercise.newExercise((string)inputExercise.text);
        DateTime time = DateTime.Parse(inputTime.text);
        float distance = (float) Convert.ToDouble(inputTime.text);
        int type = Int32.Parse((string) inputType.text);
        int reps = Int32.Parse((string) inputReps.text);

        PersonalRecords PR = new PersonalRecords();
        PR.NewExercise(weight, exercise, time, distance, type, reps);
        PRHolder prlist = new PRHolder();
        prlist.AddExercise(PR);
        
    }
   

}
