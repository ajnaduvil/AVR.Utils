using System;
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

        /// <summary>
        /// Switches the state to the new state
        /// </summary>
        /// <param name="newState"></param>
        public void SwitchState(MonoBehaviourState newState)
        {
            if (currentState == newState)
            {
                Debug.LogWarning("Trying to switch to the current state");
                return;
            }

            if (newState == null)
            {
                throw new ArgumentNullException("Cannot switch to a null state");
            }
            if (currentState != null)
            {
                currentState.OnExit();
            }
            previousState = currentState;
            currentState = newState;
            currentState.OnEnter();
        }
    }
}