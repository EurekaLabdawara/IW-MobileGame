using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{
    public class GlobalStringVar : MonoBehaviour
    {

        public string CurrentValue;

        public string GetCurrentValue()
        {
            return CurrentValue;
        }

        public void SetCurrentValue(string aValue)
        {
            CurrentValue = aValue;
        }

        public void AddToCurrentValue(string aValue)
        {
            CurrentValue += aValue;
        }

    }

}