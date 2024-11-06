using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTestScript : MonoBehaviour
{
    [SerializeField] BaseUnit UnitA;
    [SerializeField] BaseUnit UnitB;

    [SerializeField] FoodItem foodA;
    [SerializeField] float qty;
    [ContextMenu("Convert To Base")]
    public void ConverToBaseTest1()
    {
        string s = $"Converting UnitA {UnitA} to base Units: \n";
        float v = UnitA.ConversionToBase();
        s += $"{UnitA} Conversion factor = {v}\n";
        s += $"1 {UnitA}  : {v} {UnitA.DictString()}";
        Debug.Log(s);
    }

    [ContextMenu("UnitA:UnitB same base type?")]
    public void SameBaseTypeTest()
    {
        string s = $"{UnitA} = {UnitB}?\n";
        s += UnitValue.isSameBaseType(new UnitValue(0,UnitA), new UnitValue(0,UnitB)) + "\n";
        s += $"A:{UnitA} = {UnitA.DictString()}\n";
        s += $"B:{UnitB} = {UnitB.DictString()}\n";
        Debug.Log(s);
    }

}
