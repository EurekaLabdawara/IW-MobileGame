using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class AIAnima2D : MonoBehaviour
    {

        public enum CCompareType { Greater, Equal, Less }
        public enum CStateType { Moving, Attack }
        public enum CParameterType { Int, Float, Bool, Trigger }

        public bool isEnabled;
        public Animator TargetAnimator;

        [System.Serializable]
        public class CAnimationState2D
        {
            public CStateType StateType;
            public string StateNow;
            public string StateNext;
            public CParameterType ParameterType;
            public string ParameterName;
            public string PositiveValue;
            public string NegativeValue;
            public AIMechanim2D TriggerMechanim;
        }

        public CAnimationState2D[] AnimationState2D;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                for (int i = 0; i < AnimationState2D.Length; i++)
                {
                    if (AnimationState2D[i].TriggerMechanim.GetMovingStatus() && AnimationState2D[i].StateType == CStateType.Moving)
                    {
                        if (AnimationState2D[i].ParameterType == CParameterType.Float)
                        {
                            float dummyvalue = float.Parse(AnimationState2D[i].PositiveValue);
                            TargetAnimator.SetFloat(AnimationState2D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState2D[i].ParameterType == CParameterType.Int)
                        {
                            int dummyvalue = int.Parse(AnimationState2D[i].PositiveValue);
                            TargetAnimator.SetInteger(AnimationState2D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState2D[i].ParameterType == CParameterType.Bool)
                        {
                            bool dummyvalue = bool.Parse(AnimationState2D[i].PositiveValue);
                            TargetAnimator.SetBool(AnimationState2D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState2D[i].ParameterType == CParameterType.Trigger)
                        {
                            TargetAnimator.SetTrigger(AnimationState2D[i].ParameterName);
                        }

                    }

                    if (AnimationState2D[i].TriggerMechanim.GetAttackStatus() && AnimationState2D[i].StateType == CStateType.Attack)
                    {
                        if (AnimationState2D[i].ParameterType == CParameterType.Float)
                        {
                            float dummyvalue = float.Parse(AnimationState2D[i].PositiveValue);
                            TargetAnimator.SetFloat(AnimationState2D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState2D[i].ParameterType == CParameterType.Int)
                        {
                            int dummyvalue = int.Parse(AnimationState2D[i].PositiveValue);
                            TargetAnimator.SetInteger(AnimationState2D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState2D[i].ParameterType == CParameterType.Bool)
                        {
                            bool dummyvalue = bool.Parse(AnimationState2D[i].PositiveValue);
                            TargetAnimator.SetBool(AnimationState2D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState2D[i].ParameterType == CParameterType.Trigger)
                        {
                            TargetAnimator.SetTrigger(AnimationState2D[i].ParameterName);
                        }
                    }
                }
            }
        }

        void LateUpdate()
        {
            if (isEnabled)
            {
                for (int i = 0; i < AnimationState2D.Length; i++)
                {
                    if (!AnimationState2D[i].TriggerMechanim.GetMovingStatus() && AnimationState2D[i].StateType == CStateType.Moving)
                    {
                        if (AnimationState2D[i].ParameterType == CParameterType.Float)
                        {
                            float dummyvalue = float.Parse(AnimationState2D[i].NegativeValue);
                            TargetAnimator.SetFloat(AnimationState2D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState2D[i].ParameterType == CParameterType.Int)
                        {
                            int dummyvalue = int.Parse(AnimationState2D[i].NegativeValue);
                            TargetAnimator.SetInteger(AnimationState2D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState2D[i].ParameterType == CParameterType.Bool)
                        {
                            bool dummyvalue = bool.Parse(AnimationState2D[i].NegativeValue);
                            TargetAnimator.SetBool(AnimationState2D[i].ParameterName, dummyvalue);
                        }

                    }

                    if (!AnimationState2D[i].TriggerMechanim.GetAttackStatus() && AnimationState2D[i].StateType == CStateType.Attack)
                    {
                        if (AnimationState2D[i].ParameterType == CParameterType.Float)
                        {
                            float dummyvalue = float.Parse(AnimationState2D[i].NegativeValue);
                            TargetAnimator.SetFloat(AnimationState2D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState2D[i].ParameterType == CParameterType.Int)
                        {
                            int dummyvalue = int.Parse(AnimationState2D[i].NegativeValue);
                            TargetAnimator.SetInteger(AnimationState2D[i].ParameterName, dummyvalue);
                        }
                        if (AnimationState2D[i].ParameterType == CParameterType.Bool)
                        {
                            bool dummyvalue = bool.Parse(AnimationState2D[i].NegativeValue);
                            TargetAnimator.SetBool(AnimationState2D[i].ParameterName, dummyvalue);
                        }

                    }

                }
            }
        }

        void Shutdown(bool aValue)
        {
            isEnabled = false;
        }

    }

}