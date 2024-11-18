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
        iUnit u = UnitManager.UnitParse(dropDownEntry.itemText.text);
        float v = float.Parse(valueEntryBar.text);
        UnitValue uv = new UnitValue(v, u);
        return uv;
    }

    public void OnUnitChange()
    {

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
}
