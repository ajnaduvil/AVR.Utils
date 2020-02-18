using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AVR.Utils
{
    /// <summary>
    /// This class enables invoking a coroutine from a non-Monobehaviour class
    /// Adds a runtime game object with invoker script attached using which the non-Monobehaviour classes can invoke coroutines
    /// </summary>
    public class CoroutineInvoker : Singleton<CoroutineInvoker>
    {
        /// <summary>
        /// Dictionary that keeps track of function references of coroutines that are being invoked at the moment
        /// </summary>
        private Dictionary<IEnumerator, Coroutine> functionReferenceDict;

        #region Monobehaviour Methods
        protected override void Awake()
        {
            base.Awake();
            // Initialize the function reference dictionary
            functionReferenceDict = new Dictionary<IEnumerator, Coroutine>();
            gameObject.name = $"[Runtime] {nameof(CoroutineInvoker)}";

        }
        #endregion

        #region CoroutineInvoker Methods

        /// <summary>
        /// Invokes a coroutine
        /// </summary>
        /// <param name="routine"><see cref="IEnumerator"/> to be invoked</param>
        /// <returns>
        /// The <see cref="Coroutine" /> reference object
        /// </returns>
        public static Coroutine Invoke(IEnumerator routine)
        {
            var coroutineRef = Instance.StartCoroutine(routine);
            Instance.functionReferenceDict.Add(routine, coroutineRef);
            Instance.StartCoroutine(TrackRoutine(coroutineRef));
            return coroutineRef;
        }

        /// <summary>
        /// Stops a particular coroutine
        /// </summary>
        /// <param name="routine"></param>
        public static void Stop(Coroutine routine = null)
        {
            if (routine == null) return;

            Instance.StopCoroutine(routine);
            if (Instance.functionReferenceDict.ContainsValue(routine))
            {
                var key = Instance.functionReferenceDict.FirstOrDefault(x => x.Value == routine).Key;
                if (key != null)
                    Instance.functionReferenceDict.Remove(key);
            }
        }

        /// <summary>
        /// Stops a particular coroutine
        /// </summary>
        /// <param name="routine">The <see cref="IEnumerator"/> to be invoked</param>
        public static void Stop(IEnumerator routine = null)
        {
            if (routine == null) return;

            Instance.StopCoroutine(routine);
            if (Instance.functionReferenceDict.ContainsKey(routine))
            {
                Instance.functionReferenceDict.Remove(routine);
            }
        }

        /// <summary>
        /// Stops all coroutines currently being invoked by the <see cref="CoroutineInvoker"/>
        /// </summary>
        public static void StopAll()
        {
            foreach (var item in Instance.functionReferenceDict)
            {
                var coroutine = item.Value;
                if (coroutine != null)
                    Instance.StopCoroutine(item.Value);
            }
        }

        /// <summary>
        /// Tracks the coroutine and removes it from the <see cref="functionReferenceDict"/>
        /// </summary>
        /// <param name="routine"></param>
        /// <returns></returns>
        private static IEnumerator TrackRoutine(Coroutine routine)
        {
            yield return routine;
            if (Instance.functionReferenceDict.ContainsValue(routine))
            {
                var key = Instance.functionReferenceDict.FirstOrDefault(x => x.Value == routine).Key;
                if (key != null)
                {
                    Instance.functionReferenceDict.Remove(key);
                }
            }
        }

        #endregion

    }
}