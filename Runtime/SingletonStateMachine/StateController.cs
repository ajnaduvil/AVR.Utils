using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AVR.Utils.StateMachines
{
    public class StateController : Singleton<StateController>
    {
        public MonoBehaviourState currentState;
        private MonoBehaviourState previousState;

        //The StartState can be specified here
        public MonoBehaviourState startState;

        // Use this for initialization
        void Start()
        {
            if (startState != null)
            {
                SwitchState(startState);
            }
        }

        public void SwitchState(MonoBehaviourState newState)
        {

            if (newState == null)
            {
                Debug.LogError("State argument passed is null");
            }
            if (currentState != null)
            {
                currentState.OnExit();
            }
            previousState = currentState;
            currentState = newState;
            currentState.OnEnter();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}