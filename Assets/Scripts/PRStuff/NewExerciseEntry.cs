using System.Collections;
using System;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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
    {   //convert all data to its respective type
        int weight = Int32.Parse((string) inputWeight.text);
        Exercise exercise = ScriptableObject.CreateInstance<Exercise>();
        exercise.newExercise((string)inputExercise.text);
        DateTime time = new DateTime(0, 0);
        double seconds = Convert.ToDouble(inputTime.text);
        time.AddSeconds(seconds);
        float distance = (float) Convert.ToDouble(inputTime.text);
        int type = Int32.Parse((string) inputType.text);
        int reps = Int32.Parse((string) inputReps.text);

        //Add to list
        PersonalRecords PR = ScriptableObject.CreateInstance<PersonalRecords>();
    
        PR.NewExercise(weight, exercise, time, distance, type, reps);
        AssetDatabase.CreateAsset(PR, "Assets/Scripts/PRStuff/NewPr.so");
        string[] list = AssetDatabase.FindAssets("PRList", null);
        PRHolder prlist = AssetDatabase.ImportAsset("Assets/Scripts/PRStuff/PRList.so");
        prlist.AddExercise(PR);
        // PRHolder prlist = Resources.Load("PRList/PRList") as PRHolder;
        // prlist.AddExercise(PR);
        AssetDatabase.SaveAssets();


        
    }
   

}
