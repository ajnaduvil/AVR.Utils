using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AVR.Utils
{
    /// <summary>
    /// Scales the target object. If target set to null, the transform of the gameobject on which the script is attached will 
    /// be taken.
    /// </summary>
    public class ObjectScaler : MonoBehaviour
    {
        public Transform target;
        private Vector3 scale;

        #region Properties
        /// <summary>
        /// Use the property to instanly apply the scale
        /// </summary>
        public Vector3 Scale { get => scale; set => ApplyScale(value); }
        #endregion

        private void Start()
        {
            if (target == null)
            {
                target = gameObject.transform;
            }
            ApplyScale(Scale);
        }

        private void ApplyScale(Vector3 newScale)
        {
            target.localScale = newScale;
            scale = newScale;
        }

        public void ResetScale()
        {
            Scale = Vector3.one;
        }
    }
}
