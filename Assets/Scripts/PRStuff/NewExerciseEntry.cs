using System.Collections;
using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class NewExerciseEntry : MonoBehaviour
{
   public string exerciseName = "testName";
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
        // PRHolder prlist = GameManager.PRList; //get list from user
        //this doesn't work and I have no clue why!!
        // PRHolder prlist = ScriptableObject.CreateInstance<GameManager.PRList>(); 
        //This works for right now but it doesn't update to the list or take in the exercise so data

        // PRHolder prlist = ScriptableObject.CreateInstance<PRHolder>(); 
        // PRHolder prlist = GameManager.PRList;
        
        PersonalRecords PR = ScriptableObject.CreateInstance<PersonalRecords>(); //create instance
        PR.NewExercise(weight, exercise, time, distance, type, reps); //add values
        // prlist.AddExercise(PR); //add to list
        GameManager.PRList.AddExercise(PR);

        // for(PersonalRecords pr : GameManager.PRList) 
        // {

        // }
        

        string directoryPathPR = "Assets/Scripts/PRStuff/ExerciseList";
        string assetPathPR = $"{directoryPathPR}/{DirectoryUtils.SanitizeToValidName(PR.exerciseName)}.asset";

        if(!Directory.Exists(directoryPathPR)) 
        {
            Directory.CreateDirectory(directoryPathPR); 
        }
        AssetDatabase.CreateAsset(PR, assetPathPR);
        Debug.Log("Creating Asset at" + assetPathPR);

        AssetDatabase.SaveAssetIfDirty(PR);
        // AssetDatabase.SaveAssetIfDirty(prlist);








    
        // AssetDatabase.CreateAsset(PR, "Assets/Scripts/PRStuff/NewPr.so");
        // string[] list = AssetDatabase.FindAssets("PRList", null);
        // // PRHolder prlist = AssetDatabase.ImportAsset("Assets/Scripts/PRStuff/PRList.so");
        // PRHolder prlist = GameManager.PRList;
        // // PRHolder prlist = Resources.Load("PRList/PRList") as PRHolder;
        // // prlist.AddExercise(PR);
        // AssetDatabase.SaveAssets();
       


        
    }
   

}
