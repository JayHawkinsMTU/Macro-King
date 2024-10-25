using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnitValue
{
    private iUnit unit;
    private float value;
    static UnitValue nullUnitValue;
    public UnitValue(float value, iUnit unit)
    {
        this.value = value;
        this.unit = unit;
    }
    public UnitValue(float value, string unit)
    {
        this.value = value;
        this.unit = UnitManager.UnitParse(unit);
    }

    public override string ToString()
    {
        string Unit = (unit == null) ? "-" : unit.Name();
        return $"{value:.1} {Unit}";
    }

    public static UnitValue NullUnitValue
    {
        get
        {
            if (nullUnitValue != null) { return nullUnitValue; }
            nullUnitValue = new UnitValue(0, BaseUnit.NullUnit);
            return nullUnitValue;
        }   
    }
}
