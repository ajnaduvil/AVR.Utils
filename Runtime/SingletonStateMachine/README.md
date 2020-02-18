# Singleton State Machine
A simple Monobehaviour based state machine

### Usage
1. Add `StateController.cs` to a an empty `GameObject`. This will serve as the state manager.
2. To create custom state, create subclasses from 'MonobehaviourState.cs` class
3. Add the state classes to empty `GameObject`s as components.
4. Set the `startState` property of the `StateController` with the reference of the state component to be set as start state.


### Example Code

- Creating a custom state
```C#
using AVR.Utils.StateMachines;

public class CustomState : MonoBehaviourState
{
    public override void OnEnter()
    {
        base.OnEnter();
        // Write state on enter code here
    }

    public override void OnExit()
    {
        base.OnExit();
        // Write state on exit code here
    }
}
```
