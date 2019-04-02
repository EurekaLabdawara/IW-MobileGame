using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IMedia9
{

    public class DPadCanvasSkill : MonoBehaviour
    {

        public GameObject TargetObject;
        public GameObject CanvasSkill;
        public DPadActionButton ActionButton;
        public DPadTouchRight RightJoystick;
        private Vector3 RightJoystickInput;
        float xMovementRightJoystick, zMovementRightJoystick;
        float rotationSpeed = 8;
        public bool isDebug = false;

        // Use this for initialization
        void Awake()
        {
            
        }

        // Use this for initialization
        void Start()
        {
            CanvasSkill.SetActive(false);
        }

        void Update()
        {
            if (isDebug) Debug.Log(ActionButton.isButtonStatusDown());   
            if (ActionButton.isButtonStatusDown())
            {
                CanvasSkill.SetActive(true);
            }
            else
            {
                CanvasSkill.SetActive(false);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {

            RightJoystickInput = RightJoystick.GetInputDirection();
            float xMovementRightJoystick = RightJoystickInput.x; // The horizontal movement from joystick 02
            float zMovementRightJoystick = RightJoystickInput.y; // The vertical movement from joystick 02

            //== RIGHT ROTATION BEGIN
            //TargetObject.transform.Translate(xMovementRightJoystick * touchSensitivity, zMovementRightJoystick * touchSensitivity, 0);

            float tempAngle = Mathf.Atan2(zMovementRightJoystick, xMovementRightJoystick);
            xMovementRightJoystick *= Mathf.Abs(Mathf.Cos(tempAngle));
            zMovementRightJoystick *= Mathf.Abs(Mathf.Sin(tempAngle));

            // calculate the player's direction based on angle

            RightJoystickInput = new Vector3(xMovementRightJoystick, 0, zMovementRightJoystick);
            RightJoystickInput = transform.TransformDirection(RightJoystickInput);

            // rotate the player to face the direction of input
            Vector3 temp = transform.position;
            temp.x += xMovementRightJoystick;
            temp.z += zMovementRightJoystick;
            Vector3 lookDirection = temp - transform.position;
            if (lookDirection != Vector3.zero)
            {
                TargetObject.transform.localRotation = Quaternion.Slerp(TargetObject.transform.localRotation, Quaternion.LookRotation(lookDirection), rotationSpeed * Time.deltaTime);
            }

            //== RIGHT ROTATION END

            
        }
    }

}
