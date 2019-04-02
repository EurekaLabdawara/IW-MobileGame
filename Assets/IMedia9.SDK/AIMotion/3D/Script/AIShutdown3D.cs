using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class AIShutdown3D : MonoBehaviour
    {

        public enum CCompareType { Greater, Equal, Less }
        public enum CParameterType { Int, Float, Bool, Trigger }

        public Animator TargetAnimator;

        [System.Serializable]
        public class CAnimationState3D
        {
            public string StateNow;
            public string StateNext;
            public CParameterType ParameterType;
            public string ParameterName;
            public string PositiveValue;
            public string NegativeValue;
        }

        public AIMechanim3D DisabledMechanim;
        public AIAnima3D DisabledAnima;
        public AIShooter3D DisabledShooter3D;
        public int DestroyObjectDelay; 
        public CAnimationState3D AnimationState3D;
        
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                this.GetComponent<AIAnima3D>().enabled = false;
            }
        }

        void Shutdown(bool aValue)
        {
            Debug.Log("AIShutdown3D: Receive Message Shutdown");
            if (DisabledShooter3D != null) DisabledShooter3D.gameObject.SetActive(false);
            if (DisabledMechanim != null) this.GetComponent<AIMechanim3D>().enabled = false;
            if (DisabledAnima != null) this.GetComponent<AIAnima3D>().enabled = false;

            if (AnimationState3D.ParameterType == CParameterType.Float)
            {
                float dummyvalue = float.Parse(AnimationState3D.PositiveValue);
                TargetAnimator.SetFloat(AnimationState3D.ParameterName, dummyvalue);
            }
            if (AnimationState3D.ParameterType == CParameterType.Int)
            {
                int dummyvalue = int.Parse(AnimationState3D.PositiveValue);
                TargetAnimator.SetInteger(AnimationState3D.ParameterName, dummyvalue);
            }
            if (AnimationState3D.ParameterType == CParameterType.Bool)
            {
                bool dummyvalue = bool.Parse(AnimationState3D.PositiveValue);
                TargetAnimator.SetBool(AnimationState3D.ParameterName, dummyvalue);
            }
            if (AnimationState3D.ParameterType == CParameterType.Trigger)
            {
                TargetAnimator.SetTrigger(AnimationState3D.ParameterName);
            }

            Invoke("DestroyObject", DestroyObjectDelay);
        }

        void DestroyObject()
        {
            Destroy(this.gameObject);
        }
    }

}