using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitValue
{
    private iUnit unit;
    private float value;

    static UnitValue nullUnitValue;

    public float Value { get => value; }
    public iUnit Unit { get => Unit; }
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
        return $"{value} {Unit}";
    }
    public static UnitValue ConvertTo(UnitValue u, iUnit newU)
    {
        float a = u.unit.ConversionToBase();
        float b = newU.ConversionToBase();
        return new UnitValue(u.value * a / b, newU);
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
    public static UnitValue operator +(UnitValue a, UnitValue b)
    {
        iUnit unitA = a.unit;
        iUnit unitB = b.unit;

        float conversionofAToBase = unitA.ConversionToBase();
        float conversionofBToBase = unitB.ConversionToBase();

        float newVal = (a.value * conversionofAToBase) + (b.value * conversionofBToBase);
        
        return new UnitValue(newVal/conversionofAToBase, unitA);
    }

    public static UnitValue operator -(UnitValue a, UnitValue b)
    {
        iUnit unitA = a.unit;
        iUnit unitB = b.unit;

        float conversionofAToBase = unitA.ConversionToBase();
        float conversionofBToBase = unitB.ConversionToBase();

        float newVal = (a.value * conversionofAToBase) - (b.value * conversionofBToBase);

        return new UnitValue(newVal / conversionofAToBase, unitA);
    }

    public static UnitValue operator /(UnitValue a, UnitValue b)
    {
        iUnit unitA = a.unit;
        iUnit unitB = b.unit;

        float conversionofAToBase = unitA.ConversionToBase();
        float conversionofBToBase = unitB.ConversionToBase();

        float newVal = (a.value * conversionofAToBase) / (b.value * conversionofBToBase);

        return new UnitValue(newVal / conversionofAToBase, BaseUnit.NullUnit);
    }

    public static bool isSameBaseType(UnitValue a, UnitValue b)
    {
        var adict = a.unit.BaseUnits();
        var bdict = b.unit.BaseUnits();
        foreach (var unit_mult in adict)
        {
            if (!bdict.ContainsKey(unit_mult.Key))
            {
                return false;
            }
            if(bdict[unit_mult.Key] != unit_mult.Value)
            {
                return false;
            }
        }
        return true;
    }


}
