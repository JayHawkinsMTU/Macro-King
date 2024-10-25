using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitValue 
{
    private iUnit unit;
    private float value;
    public UnitValue(float value, iUnit unit)
    {
        this.value = value;
        this.unit = unit;
    }
    public UnitValue(float value, string unit)
    {
        this.value = value;
        this.unit = GameManager.unitManager.UnitParse(unit);
    }
}
