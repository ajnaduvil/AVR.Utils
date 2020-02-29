// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace AVR.Utils
{
    /// <summary>
    /// Singleton behaviour class, used for components that should only have one instance of the same inheritance hierarchy.
    /// This supports inheritance of the singleton class.
    /// <remarks>Singleton classes live on through scene transitions and will mark their 
    /// parent root GameObject with <see cref="Object.DontDestroyOnLoad"/></remarks>
    /// This implementation is modified form Microsoft Holotoolkit's singleton implementation
    /// </summary>
    /// <typeparam name="T">The Singleton Type</typeparam>
    public class InheritableSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private  T instance;

        /// <summary>
        /// Returns the Singleton instance of the classes type.
        /// If no instance is found, then we search for an instance
        /// in the scene.
        /// If more than one instance is found, we throw an error and
        /// no instance is returned.
        /// </summary>
        public  T Instance
        {
            get
            {
                if (!IsInitialized)
                {
                    Debug.LogError($"Component {typeof(T)} is not initialized");
                }
                return instance;
            }
        }


        public  void AssertIsInitialized()
        {
            Debug.Assert(IsInitialized, string.Format("The {0} singleton has not been initialized.", typeof(T).Name));
        }

        /// <summary>
        /// Returns whether the instance has been initialized or not.
        /// </summary>
        public  bool IsInitialized
        {
            get
            {
                return instance != null;
            }
        }

        /// <summary>
        /// Awake and OnEnable safe way to check if a Singleton is initialized.
        /// </summary>
        /// <returns>The value of the Singleton's IsInitialized property</returns>
        public  bool ConfirmInitialized()
        {
            T access = Instance;
            return IsInitialized;
        }

        /// <summary>
        /// Base Awake method that sets the Singleton's unique instance.
        /// Called by Unity when initializing a MonoBehaviour.
        /// Scripts that extend Singleton should be sure to call base.Awake() to ensure the
        /// static Instance reference is properly created.
        /// </summary>
        protected virtual void Awake()
        {
            var instances = FindObjectsOfType<T>().ToList();


            for (int i = 0; i < instances.Count; i++)
            {
                if (this.GetType() == instances[i].GetType())
                {
                    if (this.GetInstanceID() == instances[i].GetInstanceID())
                    {
                        instance = instances[i];
                    }
                    else
                    {
                        Debug.Log($"Destroying {this.GetInstanceID()} != {instances[i].GetInstanceID()}");
                        // instances.Remove(instances[i]);

                        if (Application.isEditor)
                        {
                            DestroyImmediate(instances[i]);
                        }
                        else
                        {
                            Destroy(instances[i]);
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Base OnDestroy method that destroys the Singleton's unique instance.
        /// Called by Unity when destroying a MonoBehaviour. Scripts that extend
        /// Singleton should be sure to call base.OnDestroy() to ensure the
        /// underlying static Instance reference is properly cleaned up.
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
    }
}
