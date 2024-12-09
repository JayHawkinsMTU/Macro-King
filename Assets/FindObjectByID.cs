using UnityEditor;
using UnityEngine;

public static class FindObjectByIdentifier
{
    [MenuItem("Tools/Find Object by Local File Identifier")]
    public static void FindObject()
    {
        int identifier = 309109848;
        foreach (var obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.GetInstanceID() == identifier)
            {
                Debug.Log($"Found object: {obj.name} with Instance ID {identifier}");
                break;
            }
        }
    }
}
