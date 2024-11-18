using UnityEngine;

public abstract class BaseVariable<T> : ScriptableObject
{
    [SerializeField] private T value;
    [SerializeField] private T prevValue;
    [SerializeField] GameEvent OnChange;
    
    public T Value
    {
        get => value;
        set {
            this.prevValue = this.value;
            this.value = value;
            OnChange?.Raise();
        }
    }

}
