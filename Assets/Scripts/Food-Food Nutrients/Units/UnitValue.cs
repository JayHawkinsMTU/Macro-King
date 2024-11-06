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

    public static UnitValue operator *(float a, UnitValue b) => new UnitValue(a * b.value, b.unit);

    // TODO: Implement
    public static UnitValue operator *(UnitValue a, UnitValue b)
    {
        float newVal = a.value * b.value;
        iUnit newUnit = a.unit;
        iUnit unitA = a.unit;
        iUnit unitB = b.unit;

        float conversionofAtoBase = 1;
        float conversionofBtoBase = 1;

        return null;
    }


    // TODO: Implement
    public static UnitValue operator /(UnitValue a, UnitValue b)
    {

        return null;
    }




}
