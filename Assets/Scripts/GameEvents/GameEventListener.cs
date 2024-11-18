using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [Tooltip("The event to register with.")]
    public GameEvent gameEvent;

    [Tooltip("The response to invoke when the event is raised.")]
    public UnityEvent response;

    private void OnEnable()
    {
        // Register this listener with the event
        if (gameEvent != null)
        {
            gameEvent.RegisterListener(this);
        }
    }

    private void OnDisable()
    {
        // Unregister this listener from the event
        if (gameEvent != null)
        {
            gameEvent.UnregisterListener(this);
        }
    }

    // This method is called when the GameEvent is raised
    public void OnEventRaised()
    {
        if (response != null)
        {
            response.Invoke();
        }
    }
}
