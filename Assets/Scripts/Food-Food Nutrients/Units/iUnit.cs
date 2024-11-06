using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iUnit 
{
    public string Name();
    public Dictionary<iUnit, int> BaseUnits();
    public Dictionary<iUnit, int> BaseUnits(Dictionary<iUnit, int> dict, int multiplicity);
    public bool isBaseUnit();

    public float ConversionToBase();
}
