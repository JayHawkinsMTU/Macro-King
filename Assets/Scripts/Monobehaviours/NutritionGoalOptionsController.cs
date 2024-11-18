using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NutritionGoalOptionsController : MonoBehaviour
{
    public TMP_Text header;
    public TMP_InputField valueDisp;
    public GameObject newOptions;
    public GameObject editOptions;
    public SelectMacroButton[] macroButtons;
    public SelectConditionButton[] conditionButtons;
    void Start()
    {
        // If null, create new goal.
        if(NutritionGoal.instance == null)
        {
            NutritionGoal.instance = new();
            newOptions.SetActive(true);
        }
        else 
        {
            editOptions.SetActive(true);
            header.text = "EDIT GOAL";
            valueDisp.text = NutritionGoal.instance.value.ToString();
            foreach(SelectMacroButton smb in macroButtons)
            {
                if(smb.macro == NutritionGoal.instance.macro)
                {
                    smb.Select();
                    break;
                }
            }
            foreach(SelectConditionButton scb in conditionButtons)
            {
                if(scb.cond == NutritionGoal.instance.condition)
                {
                    scb.Select();
                    break;
                }
            }
        }
    }
}
