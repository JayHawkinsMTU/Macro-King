using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectConditionButton : SelectEnumButton
{
    public static SelectConditionButton selected;
    public NutritionGoal.Condition cond;
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
        NutritionGoal.instance.condition = this.cond;
    }
}
