
# Coroutine Invoker
`CoroutineInvoker` class enables invoking a coroutine from a non-Monobehaviour class. It adds a runtime game object with invoker script attached using which the non-Monobehaviour classes can invoke coroutines.

### Usage
1. **Invoking a coroutine from a non-Monobehaviour class**
```C#
using AVR.Utils;
using System.Collections;
using UnityEngine;

// A non-Monobehaviour class
public class CoroutineInvokerTest 
{
    /// <summary>
    /// A sample Coroutine that waits for a particular amount of time
    /// </summary>
    /// <param name="waitTime"> Wait time in secons</param>
    /// <returns></returns>
    IEnumerator WaitCoroutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log($"Waited for {waitTime} Seconds");
    }

    public void StartWaiting()
    {
        // Invoking coroutine WaitCoroutine from a non monobehaviour class function
        CoroutineInvoker.Invoke(WaitCoroutine(2));
    }
}
```
2. **Stopping an coroutine that was invoked** : `Coroutine.Invoke(IEnumerator methodName)` method returns a `Coroutine` reference. This can be used to stop the Coroutine execution by using `CoroutineInvoker.Stop(coroutine)` method.
```C# 
	var waitCoroutine = CoroutineInvoker.Invoke(WaitCoroutine(2));
	CoroutineInvoker.Stop(waitCoroutine);
 ```
3. **Stop All Coroutines that are being invoked by CoroutineInvoker**
```C#
	CoroutineInvoker.StopAll()
```
