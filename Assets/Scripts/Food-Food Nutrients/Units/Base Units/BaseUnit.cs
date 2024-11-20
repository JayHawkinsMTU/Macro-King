using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Base Unit", menuName ="Food/Unit/Base Unit")]
public class BaseUnit : ScriptableObject, iUnit
{
    [SerializeField] string name;
    [SerializeField] string printName = "";
    [SerializeField] bool useUnitPowerinName;
    [SerializeField] UnitPower unitPower;


    [Tooltip("Only enter if smaller units exist example kg is base, but g exists")]
    [SerializeField] private bool useUnitFurtherDown = false;
    [SerializeField] private BaseUnit smallestUnit = null;
    protected Dictionary<iUnit, int> dict = null;


     string iUnit.Name()
    {
        if (useUnitPowerinName)
        {
            return unitPower.prefix + name;
        }
        return name;
    }

    public override string ToString()
    {
        if (printName != "")
        {
            return printName;
        }
        return name;
    }

    public virtual Dictionary<iUnit, int> BaseUnits()
    {
        if(dict != null) { return dict; }
        dict = new Dictionary<iUnit, int>();
        dict[this] = 1;
        return dict;
    }
    public Dictionary<iUnit, int> BaseUnits(Dictionary<iUnit, int> dict, int multiplicity)
    {
        if (dict.ContainsKey(this))
        {
            dict[this] += multiplicity;
        }
        else
        {
            dict[this] = multiplicity;
        }
        return dict;
    }

    [ContextMenu("Print Dict String")]
    public void PrintDictString()
    {
        Debug.Log(DictString());
    }

    public string DictString()
    {
        string s = "{\n";
        var d = BaseUnits();

        foreach (iUnit item in d.Keys)
        {
            s += $"{item}:{d[item]},\n";
        }
        s = s.Trim('\n').Trim(',');
        s += "\n";
        s += "}";
        return s;
    }

    public virtual bool isBaseUnit()
    {
        return true;
    }
    [ContextMenu("Clear Dict()")]
    public void ClearDict()
    {
        dict = null;
    }

    public static BaseUnit NullUnit
    {
        get => null;
    }

    public virtual float ConversionToBase()
    {
        return 1;
    }

    public bool isOfType(iUnit u)
    {
        Dictionary<iUnit, int> baseUnitsOf1 = BaseUnits();
        Dictionary<iUnit, int> baseUnitsOf2 = u.BaseUnits();

        foreach (KeyValuePair<iUnit,int> unit_multiplicity in baseUnitsOf1)
        {
            if (!baseUnitsOf2.ContainsKey(unit_multiplicity.Key)){
                return false;
            }
            int mult1 = unit_multiplicity.Value;
            int mult2 = baseUnitsOf2[unit_multiplicity.Key];
            if( mult1 != mult2)
            {
                return false;
            }
        }

        foreach (KeyValuePair<iUnit, int> unit_multiplicity in baseUnitsOf2)
        {
            if (!baseUnitsOf1.ContainsKey(unit_multiplicity.Key))
            {
                return false;
            }
            int mult1 = unit_multiplicity.Value;
            int mult2 = baseUnitsOf1[unit_multiplicity.Key];
            if (mult1 != mult2)
            {
                return false;
            }
        }
        return true;
    }
}
