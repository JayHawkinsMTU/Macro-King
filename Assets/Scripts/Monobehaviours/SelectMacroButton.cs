using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMacroButton : SelectEnumButton
{
    public static SelectMacroButton selected;
    public NutritionGoal.Macro macro;
    public override void SetSelected()
    {
        backdrop.color = selectedColor;
        selected = this;
    }

    public override void Deselect()
    {
        if(selected != null) selected.backdrop.color = unselectedColor;
    }
    public override void SetEnum()
    {
        if(NutritionGoal.instance == null) return;
        NutritionGoal.instance.macro = this.macro;
    }
}
