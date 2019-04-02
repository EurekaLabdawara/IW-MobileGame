using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{
    public class GlobalFloatVar : MonoBehaviour
    {

        public float CurrentValue;

        [Header("Constraint Settings")]
        public bool SetMaxValue;
        public float MaxValue;
        public bool SetMinValue;
        public int MinValue;

        void Update()
        {
            if (SetMaxValue)
            {
                if (CurrentValue > MaxValue)
                {
                    CurrentValue = MaxValue;
                }
            }
            if (SetMinValue)
            {
                if (CurrentValue < MinValue)
                {
                    CurrentValue = MinValue;
                }
            }
        }

        public float GetCurrentValue()
        {
            return CurrentValue;
        }

        public void SetCurrentValue(float aValue)
        {
            CurrentValue = aValue;
        }

        public void AddToCurrentValue(float aValue)
        {
            CurrentValue += aValue;
        }

        public void SubToCurrentValue(float aValue)
        {
            CurrentValue -= aValue;
        }


    }
}