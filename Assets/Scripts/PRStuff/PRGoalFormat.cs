using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
/*
This class will format an entry for the add personal record scene
*/

public class PRGoalFormat: MonoBehaviour
{
    public PersonalRecords pr = null;
    public TMP_Text prTitle;
    public TMP_Text prDetails;
    void Start()
    {
        if(pr == null)
        {
            return;
        }
        else
        {
            //figure out what kind of exercise it is
            int type = pr.Type; //1 for distance and 0 for rep based exercise
            //get the name of the exercise 
            string eName = pr.exerciseName;
            //convert the details of the pr into strings
            string weight = pr.Weight.ToString();
            string distance = pr.Distance.ToString();
            string reps = pr.Reps.ToString();
            int s = pr.getTime() % 60;
            int m = pr.getTime() / 60;
            int h = m / 60;
            if(m == 60)
            {
                m = 0;
            }
            string seconds = s.ToString();
            string minutes = m.ToString();
            string hours = h.ToString();
            
            prTitle.text = $"{eName}";
            if(type == 1) 
            {
                prDetails.text = $"{distance} miles, {hours}:{minutes}:{seconds} long";
            }
            else if(type == 0)
            {
                prDetails.text = $"{weight} lbs, {reps} reps, {hours}:{minutes}:{seconds}, long";
            }
            else
            {
                prDetails.text = "INVALID TYPE";
            }
            

        }
        

    }
}