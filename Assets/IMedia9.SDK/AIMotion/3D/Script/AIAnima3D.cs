using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class AIAnima3D : MonoBehaviour
    {

        public enum CCompareType { Greater, Equal, Less }
        public enum CParameterType { Int, Float, Bool, Trigger }

        public bool isEnabled;
        public Animator TargetAnimator;

        [System.Serializable]
        public class CMovingState3D
        {
            public string StateNow;
            public string StateNext;
            public CParameterType ParameterType;
            public string ParameterName;
            public string PositiveValue;
            public string NegativeValue;
            public AIMechanim3D TriggerMechanim;
        }

        public CMovingState3D[] MovingState3D;
        public CMovingState3D[] AttackState3D;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                for (int i = 0; i < MovingState3D.Length; i++)
                {
                        if (MovingState3D[i].TriggerMechanim.GetMovingStatus())
                        {
                            if (MovingState3D[i].ParameterType == CParameterType.Float)
                            {
                                float dummyvalue = float.Parse(MovingState3D[i].PositiveValue);
                                TargetAnimator.SetFloat(MovingState3D[i].ParameterName, dummyvalue);
                            }
                            if (MovingState3D[i].ParameterType == CParameterType.Int)
                            {
                                int dummyvalue = int.Parse(MovingState3D[i].PositiveValue);
                                TargetAnimator.SetInteger(MovingState3D[i].ParameterName, dummyvalue);
                            }
                            if (MovingState3D[i].ParameterType == CParameterType.Bool)
                            {
                                bool dummyvalue = bool.Parse(MovingState3D[i].PositiveValue);
                                TargetAnimator.SetBool(MovingState3D[i].ParameterName, dummyvalue);
                            }
                            if (MovingState3D[i].ParameterType == CParameterType.Trigger)
                            {
                                TargetAnimator.SetTrigger(MovingState3D[i].ParameterName);
                            }
                        }
                }

                for (int i = 0; i < AttackState3D.Length; i++)
                {
                    if (AttackState3D[i].TriggerMechanim.GetAttackStatus())
                    {
                        if (AttackState3D[i].ParameterType == CParameterType.Float)
                        {
                            float dummyvalue = float.Parse(AttackState3D[i].PositiveValue);
                            TargetAnimator.SetFloat(AttackState3D[i].ParameterName, dummyvalue);
                        }
                        if (AttackState3D[i].ParameterType == CParameterType.Int)
                        {
                            int dummyvalue = int.Parse(AttackState3D[i].PositiveValue);
                            TargetAnimator.SetInteger(AttackState3D[i].ParameterName, dummyvalue);
                        }
                        if (AttackState3D[i].ParameterType == CParameterType.Bool)
                        {
                            bool dummyvalue = bool.Parse(AttackState3D[i].PositiveValue);
                            TargetAnimator.SetBool(AttackState3D[i].ParameterName, dummyvalue);
                        }
                        if (AttackState3D[i].ParameterType == CParameterType.Trigger)
                        {
                            TargetAnimator.SetTrigger(AttackState3D[i].ParameterName);
                        }
                    }
                }
            }
        }

        void LateUpdate()
        {
            if (isEnabled)
            {
                for (int i = 0; i < MovingState3D.Length; i++)
                {
                        if (!MovingState3D[i].TriggerMechanim.GetMovingStatus())
                        {
                            if (MovingState3D[i].ParameterType == CParameterType.Float)
                            {
                                float dummyvalue = float.Parse(MovingState3D[i].NegativeValue);
                                TargetAnimator.SetFloat(MovingState3D[i].ParameterName, dummyvalue);
                            }
                            if (MovingState3D[i].ParameterType == CParameterType.Int)
                            {
                                int dummyvalue = int.Parse(MovingState3D[i].NegativeValue);
                                TargetAnimator.SetInteger(MovingState3D[i].ParameterName, dummyvalue);
                            }
                            if (MovingState3D[i].ParameterType == CParameterType.Bool)
                            {
                                bool dummyvalue = bool.Parse(MovingState3D[i].NegativeValue);
                                TargetAnimator.SetBool(MovingState3D[i].ParameterName, dummyvalue);
                            }
                            if (MovingState3D[i].ParameterType == CParameterType.Trigger)
                            {
                                TargetAnimator.SetTrigger(MovingState3D[i].ParameterName);
                            }

                        }

                }

                for (int i = 0; i < AttackState3D.Length; i++)
                {
                    if (!AttackState3D[i].TriggerMechanim.GetAttackStatus())
                    {
                        if (AttackState3D[i].ParameterType == CParameterType.Float)
                        {
                            float dummyvalue = float.Parse(AttackState3D[i].NegativeValue);
                            TargetAnimator.SetFloat(AttackState3D[i].ParameterName, dummyvalue);
                        }
                        if (AttackState3D[i].ParameterType == CParameterType.Int)
                        {
                            int dummyvalue = int.Parse(AttackState3D[i].NegativeValue);
                            TargetAnimator.SetInteger(AttackState3D[i].ParameterName, dummyvalue);
                        }
                        if (AttackState3D[i].ParameterType == CParameterType.Bool)
                        {
                            bool dummyvalue = bool.Parse(AttackState3D[i].NegativeValue);
                            TargetAnimator.SetBool(AttackState3D[i].ParameterName, dummyvalue);
                        }
                    }

                }
            }
        }

        void Shutdown(bool aValue)
        {
            Debug.Log("AIAnima3D: Receive Message Shutdown");
            isEnabled = false;
        }

    }

}