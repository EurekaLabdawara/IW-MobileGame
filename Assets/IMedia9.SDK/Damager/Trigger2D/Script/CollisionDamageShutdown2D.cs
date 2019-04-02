using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{
    public class CollisionDamageShutdown2D : MonoBehaviour
    {

        public bool isEnabled;
        public bool isDebugTest;

        public GameObject TargetObject;
        public GlobalFloatVar FloatVariable;

        // Use this for initialization
        void Start()
        {
            if (isDebugTest)
            {
                SendShutdown();
            }
        }

        // Update is called once per frame
        void Update()
        {

            if (FloatVariable.GetCurrentValue() <= 0)
            {
                SendShutdown();
            }
        }

        public void SendShutdown()
        {
            TargetObject.SendMessage("Shutdown", true, SendMessageOptions.DontRequireReceiver);
            Debug.Log("Send Shutdown To: " + TargetObject.name);
        }
    }
}