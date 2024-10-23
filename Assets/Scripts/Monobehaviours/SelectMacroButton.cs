using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMacroButton : SelectEnumButton
{
    public static SelectMacroButton selected;
    public NutritionGoal.Macros macro;
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
        NutritionGoalContainer.goal.macro = this.macro;
    }
}
