using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AVR.Utils
{
    /// <summary>
    /// Scales the target object
    /// </summary>
    public class ObjectScaler : MonoBehaviour
    {
        public GameObject target;
        private Vector3 scale;

        #region Properties
        /// <summary>
        /// Use the property to instanly apply the scale
        /// </summary>
        public Vector3 Scale { get => scale; set => ApplyScale(value); }
        #endregion

        private void Start()
        {
            ApplyScale(Scale);
        }

        private void ApplyScale(Vector3 newScale)
        {
            target.transform.localScale = newScale;
            scale = newScale;
        }
    }
}
