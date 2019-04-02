using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{
    public class GlobalIntVar : MonoBehaviour
    {

        public int CurrentValue;
        public bool SetMaxValue;
        public int MaxValue;
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

        public int GetCurrentValue()
        {
            return CurrentValue;
        }

        public void SetCurrentValue(int aValue)
        {
            CurrentValue = aValue;
        }

        public void AddToCurrentValue(int aValue)
        {
            CurrentValue += aValue;
        }

        public void SubstractFromCurrentValue(int aValue)
        {
            CurrentValue -= aValue;
        }

    }
}