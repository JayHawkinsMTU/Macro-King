using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectEnumButton : MonoBehaviour
{
    public Image backdrop;
    public Color unselectedColor = Color.white;
    public Color selectedColor = Color.white;
    // Whether or not this is the first assumed enum
    public bool defaultEnum = false;

    private void Start()
    {
        backdrop = GetComponent<Image>();
        if(defaultEnum) Select();
    }
    public void Select()
    {
        // Deselect previously selected button
        Deselect();
        // Mark this button as selected and change enum data
        SetSelected();
        SetEnum();
    }
    public virtual void SetSelected()
    {
        Debug.LogError(gameObject.name + "Is using the generic SelectEnumButton class");
    }

    public virtual void Deselect()
    {
        Debug.LogError(gameObject.name + "Is using the generic SelectEnumButton class");
        backdrop.color = unselectedColor;
    }

    public virtual void SetEnum()
    {
        Debug.LogError(gameObject.name + "Is using the generic SelectEnumButton class");
    }
}
