using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;


public class PRGoalFormat: MonoBehaviour
{
    public PersonalRecords pr = null;
    public ChangeSceneButton csb;
    public TMP_Text prTitle;
    public TMP_Text prDetails;
    void Start()
    {
        if(pr == null)
        {
            return;
        }

    }
}