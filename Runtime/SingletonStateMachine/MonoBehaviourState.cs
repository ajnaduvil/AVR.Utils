using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AVR.Utils.Extensions;
namespace AVR.Utils.StateMachines
{
    public abstract class MonoBehaviourState : InheritableSingleton<MonoBehaviourState>
    {
        /// <summary>
        /// Gameobjects to be set actvated on state enter
        /// </summary>
        public GameObject[] objectsTobeEnabled;
        /// <summary>
        /// GameObjects to be de activated on state enter
        /// </summary>
        public GameObject[] objectsTobeDisabled;

        /// <summary>
        /// Components to be enabled on state enter
        /// </summary>
        public Behaviour[] enableComponents;
        /// <summary>
        /// componets to be disabled on state enter
        /// </summary>
        public Behaviour[] disableComponents;

        public virtual void OnEnter()
        {
            objectsTobeEnabled.ActivateAll(true);
            objectsTobeDisabled.ActivateAll(false);
            enableComponents.EnableAll(true);
            disableComponents.EnableAll(false);
        }

        public virtual void OnExit()
        {
            objectsTobeEnabled.ActivateAll(false);
            objectsTobeDisabled.ActivateAll(true);
            enableComponents.EnableAll(false);
            disableComponents.EnableAll(true);
        }
    }
}
