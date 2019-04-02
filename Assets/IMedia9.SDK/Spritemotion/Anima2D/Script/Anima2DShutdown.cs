using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Anima2DShutdown : MonoBehaviour
    {

        public enum CCompareType { Greater, Equal, Less }
        public enum CParameterType { Int, Float, Bool, Trigger }

        public Animator TargetAnimator;

        [System.Serializable]
        public class CAnimationState2D
        {
            public string StateNow;
            public string StateNext;
            public CParameterType ParameterType;
            public string ParameterName;
            public string PositiveValue;
            public string NegativeValue;
        }

        public CAnimationState2D AnimationState2D;
        public bool DisabledInputWhenDeath;
        public Mechanim2DKeyboard InputKeyboard;
        public Mechanim2DXpad InputXPad;

        void Shutdown(bool aValue)
        {
            if (AnimationState2D.ParameterType == CParameterType.Float)
            {
                float dummyvalue = float.Parse(AnimationState2D.PositiveValue);
                TargetAnimator.SetFloat(AnimationState2D.ParameterName, dummyvalue);
            }
            if (AnimationState2D.ParameterType == CParameterType.Int)
            {
                int dummyvalue = int.Parse(AnimationState2D.PositiveValue);
                TargetAnimator.SetInteger(AnimationState2D.ParameterName, dummyvalue);
            }
            if (AnimationState2D.ParameterType == CParameterType.Bool)
            {
                bool dummyvalue = bool.Parse(AnimationState2D.PositiveValue);
                TargetAnimator.SetBool(AnimationState2D.ParameterName, dummyvalue);
            }
            if (AnimationState2D.ParameterType == CParameterType.Trigger)
            {
                TargetAnimator.SetTrigger(AnimationState2D.ParameterName);
            }

            if (DisabledInputWhenDeath)
            {
                if (InputKeyboard != null)
                {
                    InputKeyboard.enabled = false;
                }
                if (InputXPad != null)
                {
                    InputXPad.enabled = false;
                }
            }
        }
    }

}