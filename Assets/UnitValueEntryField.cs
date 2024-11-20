using System.Collections;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Linq;
using TMPro;
using System.Collections.Generic;
// Brandon Mitchell-Kiss
public class UnitValueEntryField : MonoBehaviour
{
    [SerializeField] TMP_InputField valueEntryBar;
    [SerializeField] TMP_Dropdown dropDownEntry;

    [SerializeField] BaseUnit unitType;
    private void Start()
    {
        SetDropdownOptions();
    }
    public UnitValue Get()
    {
        UnitValue uv = new UnitValue(GetValue(), GetUnit());
        return uv;
    }
    public iUnit GetUnit()
    {
        iUnit u = UnitManager.UnitParse(dropDownEntry.itemText.text);
        return u;
    }

    public float GetValue()
    {
        float v = float.Parse(valueEntryBar.text);
        return v;
    }
    public void OnUnitChange()
    {
        SetDropdownOptions();
    }

    public void OnValueChange()
    {

    }

    public void SetDropdownOptions()
    {
        if(unitType == null) { return; }
        dropDownEntry.ClearOptions();


        List<iUnit> options_units = GameManager.unitManager.GetUnitsOfType(unitType);
        List<string> options = new();
        foreach (var u in options_units)
        {
            options.Add(u.ToString());
        }
        dropDownEntry.AddOptions(options);
    }

#if UNITY_EDITOR
    [ContextMenu("GetUnit()")]
    public void printGetUnit()
    {
        Debug.Log(GetUnit());
    }

    [ContextMenu("GetValue()")]
    public void printGetValue()
    {
        Debug.Log(GetValue());
    }

    [ContextMenu("GetUnitValue()")]
    public void printGetUnitValue()
    {
        Debug.Log(Get());
    }
#endif 
}
