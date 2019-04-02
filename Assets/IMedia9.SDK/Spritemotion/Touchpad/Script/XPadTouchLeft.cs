/*
about this script:

this joystick can bet set to drag along with the finger on the screen or stay in a fixed position 
limits drag to the left-side half of the screen
sets the maximum distance the joystick handle can be relative to the center of this joystick (default is 4)
calculates and ouputs a normalized direction vector for another script to use in order to control movement of a game object (example, a player character or any desired game object)

    see the demo scene DualJoystickDemo or LeftJoystickDemo to see how the game objects for this joystick are setup:
    this script must be placed on a game object within a UI Canvas
    this script requires a UI image component to be on the game object (this is the background image of this joystick)
    this script requires a child game object that has a UI Image component on it for the handle of this joystick (this is the handle image of this joystick
    the required child handle image must be positioned and anchored to the center to the background image 
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace IMedia9
{

    public class XPadTouchLeft : MonoBehaviour
    {

        public Vector3 ButtonResult;
        public bool JumpResult;
        public GameObject ButtonLeft;
        public GameObject ButtonRight;
        public GameObject ButtonUp;
        public GameObject ButtonDown;
        public GameObject ButtonJump;
        Vector3 Trigger;
        bool TriggerJump;

        private void Start()
        {


        }

        void Update()
        {
            ButtonResult = Trigger;
            JumpResult = TriggerJump;
        }

        void LateUpdate()
        {
            if (JumpResult)
            {
                TriggerJump = false;
            }
        }

        public Vector3 GetInputDirection()
        {
            return ButtonResult;
        }

        public bool GetJumpStatus()
        {
            return TriggerJump;
        }


        public void ExecuteJump()
        {
            TriggerJump = true;
        }

        public void StopJump()
        {
            TriggerJump = false;
        }

        public bool IsJumpPadPressed()
        {
            return TriggerJump == true;
        }

        public bool IsLeftPadPressed()
        {
            return Trigger == Vector3.left;
        }

        public bool IsRightPadPressed()
        {
            return Trigger == Vector3.right;
        }

        public bool IsUpPadPressed()
        {
            return Trigger == Vector3.up;
        }

        public bool IsDownPadPressed()
        {
            return Trigger == Vector3.down;
        }


        public void GetVectorLeft()
        {
            Trigger = Vector3.left;
        }

        public void GetVectorRight()
        {
            Trigger = Vector3.right;
        }

        public void GetVectorUp()
        {
            Trigger = Vector3.up;
        }

        public void GetVectorDown()
        {
            Trigger = Vector3.down;
        }

        public void GetVectorZero()
        {
            Trigger = Vector3.zero;
        }


    }

}