using System.Collections;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Linq;
using TMPro;
using System.Collections.Generic;

public class UnitValueEntryField : MonoBehaviour
{
    [SerializeField] TMP_InputField valueEntryBar;
    [SerializeField] TMP_Dropdown dropDownEntry;
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

    }
}
