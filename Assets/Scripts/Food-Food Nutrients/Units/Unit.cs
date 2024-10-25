using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Unit", menuName ="Food/Unit/Unit")]
public class Unit : BaseUnit
{
    [SerializeField] List<BaseUnit> baseUnits;
    [SerializeField] List<int> multiplicities;
    [SerializeField] double conversionToBase;
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

}
