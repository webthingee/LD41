using UnityEngine;

public abstract class TaskSystem : ScriptableObject 
{
    [Header("Base Settings")]
    public string title;
    [Multiline] public string description;
    public bool isInprogress;
    [SerializeField] private bool isComplete;

    public virtual bool IsComplete
    {
        get
        {
            return isComplete;
        }

        set
        {
            isComplete = value;
            CompletionStatusChanged(value);
        }
    }

    void OnDisable ()
    {
        ClearProps();
    }
    
    public virtual void ClearProps ()
    {
        isInprogress = false;
        isComplete = false;
    }

    public virtual void CompletionStatusChanged (bool _isComplete)
    {
        Debug.Log("Default Check : Completion Status = " + _isComplete);
    }
}