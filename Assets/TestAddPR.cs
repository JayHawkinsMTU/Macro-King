using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddPR : MonoBehaviour
{
    [SerializeField] PersonalRecords reference = null;
    [SerializeField] PersonalRecords newPersonalRecord = null;
    void Start()
    {
        var newPR = Instantiate<PersonalRecords>(reference);
        newPersonalRecord = newPR;
    }



}
