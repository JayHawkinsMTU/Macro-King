using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Food/Unit/Unit")]
public class Unit : BaseUnit
{
    [SerializeField] List<BaseUnit> baseUnits;
    [SerializeField] List<int> multiplicities;
    [SerializeField] protected float conversionToBase;
    public override Dictionary<iUnit, int> BaseUnits()
    {
        if (dict != null)
        {
            return dict;
        }
        dict = new Dictionary<iUnit, int>();

        for (int i = 0; i < baseUnits.Count; i++)
        {
            iUnit currentUnit = baseUnits[i];
            int multiplicity = multiplicities[i];
            if (currentUnit.isBaseUnit())
            {
                // if the current unit is a base unit, add their multiplicites to the dictionary
                dict = currentUnit.BaseUnits(dict, multiplicity);
            }
            else
            {
                // If the current unit is not a base unit, recursively gather its base units.
                Dictionary<iUnit, int> innerDict = currentUnit.BaseUnits();
                foreach (var kvp in innerDict)
                {
                    if (dict.ContainsKey(kvp.Key))
                    {
                        dict[kvp.Key] += kvp.Value * multiplicity;
                    }
                    else
                    {
                        dict[kvp.Key] = kvp.Value * multiplicity;
                    }
                }
            }
        }

        return dict;
    }


    public override bool isBaseUnit()
    {
        return false;
    }

    public override float ConversionToBase()
    {
        float ctb = conversionToBase;
        if (isBaseUnit())
        {
            return ctb;
        }
        else
        {
            for (int i = 0; i < baseUnits.Count; i++)
            {
                iUnit currentUnit = baseUnits[i];
                int multiplicity = multiplicities[i];
                for (int j = 0; j < Mathf.Abs(multiplicity); j++)
                {
                    if (multiplicity > 0)
                    {
                        ctb *= currentUnit.ConversionToBase();
                    }
                    else if (multiplicity == 0)
                    {
                        // ctb *=1
                    }
                    else // multiplicity < 1
                    {
                        ctb /= currentUnit.ConversionToBase();
                    }
                }
            }
            return ctb;
        }
    }

    [ContextMenu("Convert To Base")]
    public void ConversionToBaseTest()
    {
        string s = $"Converting {this} to base Units: \n";
        float v = ConversionToBase();
        s += $"{this} Conversion factor = {v}\n";
        s += $"1 {this}  : {v} {DictString()}";
        Debug.Log(s);
    }
}
