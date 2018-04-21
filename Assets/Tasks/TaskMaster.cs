using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Tasks/Task Master")]
public class TaskMaster : TaskSystem 
{
    [Header("Task Master Specific")]
    [Tooltip("This is the Active Task.")]
    [ShowOnly] public Task activeTask;
    
    [Header("Attach Tasks")]
    public List<Task> TaskList = new List<Task>();

    [Header("On Start Task")]
    public GameObject introCutScene;
    [Multiline] public string introCutSceneText;
    public UnityEvent introCutSceneEvent;
    public UnityEvent startMissionEvent;

    [Header("On Complete Task")]
    public GameObject outroCutScene;
    [Multiline] public string outroCutSceneText;
    public UnityEvent outroCutSceneEvent;
    public UnityEvent completedMissionEvent;

    #region Start Up Tasks
    void OnEnable ()
    {
        if (title != null)
            RegisterOnSubTask ();
    }

    void RegisterOnSubTask ()
    {
        foreach (Task st in TaskList)
        {
            st.taskMaster = this;
        }
    }
    
    public override void ClearProps ()
    {
        base.ClearProps();
        activeTask = null;
    }
    #endregion

    #region Helpers
    public Task GetActiveTask ()
    {
        foreach (Task _task in TaskList)
        {
            if (_task.isInprogress)
            {
                activeTask = _task;
                return _task;
            }
        }
        return null;
    }
    #endregion

    public void TaskMasterStart ()
    {
        isInprogress = true;
        
        if (introCutScene) { 
            introCutSceneEvent.Invoke(); 
        }
        else
        {
            ActivateNextTask();
        }
    }

    public void ActivateNextTask ()
    {
        foreach (Task _task in TaskList)
        {
            if (!_task.isInprogress && !_task.IsComplete)
            {
                Debug.Log(_task.title + " is now Active");
                _task.isInprogress = true;
                activeTask = _task;
                CheckTaskCompletion();
                return;
            }
        }
        
        Debug.Log("All Tasks are Complete");
        TaskMasterEnd();
    }
    
    // Check during startup if the Task is already complete
    public void CheckTaskCompletion ()
    {
        if (isInprogress && activeTask.IsComplete)
        {
            activeTask.IsComplete = true;
            activeTask.isInprogress = false;
            activeTask.CompleteTask();
        }
        else
        {
            activeTask.StartTask();
        }
    }

    public void TaskMasterEnd ()
    {
        IsComplete = true;
        isInprogress = false;
        
        if (outroCutScene) { 
            outroCutSceneEvent.Invoke(); 
        }
        else
        {
            Debug.Log("Mission Complete");
        }
    }
}
