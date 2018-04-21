using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "Tasks/Task")]
public class Task : TaskSystem 
{   
    [Header("Task Specific")]
    [Tooltip("This Task is a child of this Task Master.")]
    [ShowOnly] public TaskMaster taskMaster;

    [Header("Attach SubTasks")]
    public List<SubTask> SubTaskList = new List<SubTask>();

    [Header("On Start Task")]
    public GameObject introCutScene;
    [Multiline] public string introCutSceneText;
    public UnityEvent introCutSceneEvent;
    UnityEvent startTaskEvent;

    [Header("On Complete Task")]
    public GameObject outroCutScene;
    [Multiline] public string outroCutSceneText;
    public UnityEvent outroCutSceneEvent;
    UnityEvent completedTaskEvent;

    void OnEnable()
    {
        if (title != null)
            RegisterOnSubTask ();
    }

    void RegisterOnSubTask ()
    {
        foreach (SubTask st in SubTaskList)
        {
            st.task = this;
        }
    }

    public void StartTask ()
    {
        if (introCutScene) { 
            introCutSceneEvent.Invoke(); 
        }
        else
        {
            Debug.Log("Right Before Task " + title + " is Activated");
        }
    }

    public bool CompletionCheck ()
    {
        // iterate through the subtasks to see if any are not done.
        foreach (SubTask _st in SubTaskList)
        {
            if (!_st.IsComplete)
            {
                Debug.Log("SubTask Completeed, Task " + title + " Not Complete");
                IsComplete = false;
                return false; // if one is not done, bail out of function
            }
        }
        // all subtasks are complete
        Debug.Log("SubTasks Complete, Task " + title + " Complete");
        IsComplete = true;
        taskMaster.CheckTaskCompletion();
        return true;
    }

    public void CompleteTask ()
    {
        if (outroCutScene) { 
            outroCutSceneEvent.Invoke(); 
        }
        else
        {
            Debug.Log("Right After Task " + title + " Has Been Completed");
            taskMaster.ActivateNextTask();
        }
    }
}
