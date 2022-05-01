using System;
using System.Threading.Tasks;
using UnityEngine;

public class WaitForTask : CustomYieldInstruction
{
    private readonly Task task;

    public WaitForTask(Task task)
    {
        this.task = task;
    }
    public override bool keepWaiting
    {
        get
        {
            if (!task.IsCompleted)
            {
                return true;
            }
            if (task.IsFaulted)
            {
                AggregateException exception = task.Exception;
                Debug.LogException(exception);
            }
            return false;
        }
    }
}
