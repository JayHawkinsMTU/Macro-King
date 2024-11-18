using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameEvent", menuName = "Events/GameEvent")]
public class GameEvent : ScriptableObject
{
    // List of listeners that are currently registered to this event
    private readonly List<GameEventListener> listeners = new List<GameEventListener>();

    // Call this method to raise the event
    public void Raise()
    {
        // Notify all listeners
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    // Register a listener to the event
    public void RegisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    // Unregister a listener from the event
    public void UnregisterListener(GameEventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }
}
