// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using System.Linq;

namespace AVR.Utils
{
    /// <summary>
    /// Singleton behaviour class, used for components that should only have one instance of the same inheritance hierarchy.
    /// This supports inheriting singleton class.
    /// <remarks>Singleton classes live on through scene transitions and will mark their 
    /// parent root GameObject with <see cref="Object.DontDestroyOnLoad"/></remarks>
    /// </summary>
    /// <typeparam name="T">The Singleton Type</typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        /// <summary>
        /// Returns the Singleton instance of the classes type.
        /// If no instance is found, then we search for an instance
        /// in the scene.
        /// If more than one instance is found, we throw an error and
        /// no instance is returned.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (!IsInitialized)
                {
                    //T[] objects = FindObjectsOfType<T>();
                    //if (objects.Length == 1)
                    //{
                    //    instance = objects[0];
                    //    DontDestroyOnLoad(instance.gameObject.transform.root.gameObject);
                    //}
                    //else if (objects.Length > 1)
                    //{
                    //    Debug.LogErrorFormat("Expected exactly 1 {0} but found {1}.", typeof(T).Name, objects.Length);
                    //}
                    Debug.LogError($"Component {typeof(T)} is not initialized");
                }
                return instance;
            }
        }


        public static void AssertIsInitialized()
        {
            Debug.Assert(IsInitialized, string.Format("The {0} singleton has not been initialized.", typeof(T).Name));
        }

        /// <summary>
        /// Returns whether the instance has been initialized or not.
        /// </summary>
        public static bool IsInitialized
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
        public static bool ConfirmInitialized()
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
                if (this.GetType() != instances[i].GetType())
                {

                    Debug.Log($"Removing {this.GetType()} != {instances[i].GetType()}");
                    instances.Remove(instances[i]);
                }
            }
            instance = instances[0];
            instances.Remove(instance);
            DontDestroyOnLoad(instance.gameObject);
            //Handling multiple components in the same gameobject
            foreach (var otherInstance in instances)
            {
                if (otherInstance != instance)
                {
                    if (Application.isEditor)
                    {
                        DestroyImmediate(otherInstance);
                    }
                    else
                    {
                        Destroy(otherInstance);
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
