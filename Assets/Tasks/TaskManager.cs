using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour 
{
    public TaskMaster taskMaster;

    void Awake ()
    {
        taskMaster.TaskMasterStart();
    }

}
