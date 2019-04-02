using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{
    public class GlobalBoolVar : MonoBehaviour
    {

        public bool CurrentValue;

        public bool GetCurrentValue()
        {
            return CurrentValue;
        }

        public void SetCurrentValue(bool aValue)
        {
            CurrentValue = aValue;
        }
    }
}