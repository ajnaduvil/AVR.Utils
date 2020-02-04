using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AVR.Utils.Extensions
{
    public static class ComponentExtensions
    {
        public static void ActivateAll(this GameObject[] gameObjects, bool flag)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.SetActive(flag);
            }
        }

        public static void EnableAll(this Behaviour[] components, bool flag)
        {
            foreach (var component in components)
            {
                component.enabled = flag;
            }
        }
    }
}
