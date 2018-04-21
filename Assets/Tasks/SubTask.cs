using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Tasks/SubTask")]
public class SubTask : TaskSystem 
{
    [Header("SubTask Specific")]
    [Tooltip("This SubTask is a child of this Task.")]
    [ShowOnly] public Task task;

    public override void CompletionStatusChanged (bool _isComplete)
    {
        string msg = _isComplete ? "Complete" : "Not Complete";
        Debug.Log("SubTask " + title + ", is " + msg);
        task.CompletionCheck();
    }
}
