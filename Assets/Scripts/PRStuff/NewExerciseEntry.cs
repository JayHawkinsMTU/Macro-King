using System.Collections;
using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro; //allows the use of TextMesh Input Fields 
/*
Change the scriptable objects in order to save to disk
*/

public class NewExerciseEntry : MonoBehaviour
{
   public string exerciseName = "testName";
    [SerializeField] TMP_InputField inputWeight;
    [SerializeField] TMP_InputField inputExercise;
    [SerializeField] TMP_InputField inputTime;
    [SerializeField] TMP_InputField inputDistance;
    [SerializeField] TMP_InputField inputType;
    [SerializeField] TMP_InputField inputReps;

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
        int weight = Int32.Parse(inputWeight.text);
        DateTime time = new DateTime(0, 0);
        double seconds = Convert.ToDouble(inputTime.text);
        time.AddSeconds(seconds);
        float distance = (float) Convert.ToDouble(inputDistance.text);
        int type = Int32.Parse(inputType.text);
        int reps = Int32.Parse(inputReps.text);
        //implement a way to search through the exercises to see if one has already been created
        PersonalRecords PR = new PersonalRecords();
        /*
        Search for an existing exercise for the sake of not making duplicate exercises 
        */
        
        // Commented out because user doesn't contain a definition for Exercises and Exercise class appears to be incomplete. - Jay
        User user = User.LoadUser();
        List<Exercise> exercises = user.Exercises; //create the list of exercises from user
        bool found = false;
        int exerciseIndex = -1;
        for(int i = 0; i < exercises.Count; i++)
        {
            if(exercises[i].getName() == inputExercise.text) //try to find an exercises that equals the text
            {
                found = true;
                exerciseIndex = i;
                i = exercises.Count;
            }
        }
        if(found) //add that exercise to the pr
        {
            PR.NewExercise(weight, exercises[exerciseIndex], time, distance, type, reps);
        }
        else //make new exercise
        {
        Exercise exercise = new Exercise();
        exercise.newExercise(inputExercise.text);
        PR.NewExercise(weight, exercise, time, distance, type, reps);
        }
        user.PRs.Add(PR);
        User.SaveUser();

        

        /*
        Overhaul of SO
        */
        //find the exercise SO, if it exists
        // Exercise exercise;
        // string newName = inputExercise.text;
        // exercise = ScriptableObject.CreateInstance<Exercise>();
        // exercise.newExercise(newName);
        // //if the exercise is found
        // if(GameManager.exerciseList.ExerciseSearch(exercise) != null) 
        // {
        //     exercise = GameManager.exerciseList.ExerciseSearch(exercise); //Add the exercise to exercise list
        // }
        // else 
        // { 
        //     //else create a new one
        //     exercise = ScriptableObject.CreateInstance<Exercise>();
        //     exercise.newExercise(newName);
        // }
        // GameManager.exerciseList.AddExerciseToList(exercise);
        // //create the asset
        // string directoryPathExercise = "Assets/Scripts/PRStuff/ExerciseFolder";
        // string assetPathExercise = $"{directoryPathExercise}/{DirectoryUtils.SanitizeToValidName(exercise.getName())}.asset";
        // if(!Directory.Exists(directoryPathExercise)) 
        // {
        //     Directory.CreateDirectory(directoryPathExercise);
        // }
        // // AssetDatabase causes compiler errors when building.
        // //AssetDatabase.CreateAsset(exercise, assetPathExercise);
        // Debug.Log("Creating Asset as" + assetPathExercise);
        // //save to directory
        // //AssetDatabase.SaveAssetIfDirty(exercise);
        // //AssetDatabase.SaveAssetIfDirty(GameManager.exerciseList);


        // //create the asset
        // PersonalRecords PR = ScriptableObject.CreateInstance<PersonalRecords>(); //create instance
        // PR.NewExercise(weight, exercise, time, distance, type, reps); //add values
        // GameManager.PRList.AddExercise(PR);
        // string directoryPathPR = "Assets/Scripts/PRStuff/PRFolder";
        // string assetPathPR = $"{directoryPathPR}/{DirectoryUtils.SanitizeToValidName(PR.exerciseName)}.asset";

        // if(!Directory.Exists(directoryPathPR)) 
        // {
        //     Directory.CreateDirectory(directoryPathPR); 
        // }
        // //AssetDatabase.CreateAsset(PR, assetPathPR);
        // Debug.Log("Creating Asset at" + assetPathPR);
        // //save to directory
        // //AssetDatabase.SaveAssetIfDirty(PR);
        // //AssetDatabase.SaveAssetIfDirty(GameManager.PRList);

       


        
    }
   

}
