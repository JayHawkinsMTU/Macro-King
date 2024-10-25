using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Unit Manager", menuName = "Food/Unit/Unit Manager")]
public class UnitManager : ScriptableObject
{
    [SerializeField] private List<BaseUnit> units; // Drag and drop your units here in the editor.

    // Dictionary for quick lookups.
    private Dictionary<string, BaseUnit> unitLookup;

    private void OnEnable()
    {
        // Initialize the lookup dictionary on startup.
        unitLookup = units.ToDictionary(unit => unit.ToString().ToLower(), unit => unit);
    }

    /// <summary>
    /// Parses a string and returns the matching BaseUnit.
    /// </summary>
    public static BaseUnit UnitParse(string unitName, UnitManager um = null)
    {
        // Get an instance of a unit manager if one does not exist
        if(um == null)
        {
            um = GameManager.unitManager;
        }

        if (string.IsNullOrEmpty(unitName))
        {
            Debug.LogError("Unit name cannot be null or empty.");
            return null;
        }

        // Perform case-insensitive lookup.
        if (um.unitLookup.TryGetValue(unitName.ToLower(), out BaseUnit unit))
        {
            return unit;
        }
        else
        {
            Debug.LogWarning($"Unit '{unitName}' not found.");
            return null;
        }
    }
    [ContextMenu("Test UnitParse(kg)")]
    public void testUnitParse1()
    {
        UnitParse("kg")?.PrintDictString();

    }

    [ContextMenu("Test UnitParse(kJ)")]
    public void testUnitParse2()
    {
        UnitParse("kJ")?.PrintDictString();
    }
}
