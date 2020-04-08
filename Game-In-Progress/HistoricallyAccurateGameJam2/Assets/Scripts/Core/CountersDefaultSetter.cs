using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HAGJ2.Core
{
    public class CountersDefaultSetter : MonoBehaviour
    {
        [SerializeField] IntVariable valueToSet = null;
        [SerializeField] int defaultValue = 0;

        private void Awake() 
        {
            valueToSet.SetValue(defaultValue);
        }
    }
}
