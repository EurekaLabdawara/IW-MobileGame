/*
about this script: 

if a joystick is not set to stay in a fixed position
 for the left joystick, this script makes it appear and disappear within the left-side half of the screen where the screen was touched 
 for the right joystick, this script makes it appear and  disappear within the right-side half of the screen where the screen was touched 

if a joystick is set to stay in a fixed position
 for the left joystick, this script makes it appear and disappear if the user touches within the area of its background image (even if it is not currently visible)
 for the right joystick, this script makes it appear and disappear if the user touches within the area of its background image (even if it is not currently visible)
 
this script also keeps one or both joysticks always visible

modified by: Roedavan
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace IMedia9
{

    public class XPadTouchController : MonoBehaviour
    {
        [System.Serializable]
        public class CXPadTouchLeft
        {
            public bool isEnabled = false;
            public bool showPadbackkground = true;
            public bool showHorizontalButton = true;
            public bool showVerticalButton = true;
            public bool showJumpButton = true;
            public GameObject LeftJoystick; 
        }
        public CXPadTouchLeft XPadTouchLeftJoystick;

        private Image XPadTouchLeftHandleImage; // handle (knob) image of the left joystick
        private XPadTouchLeft XPadTouchLeft; // script component attached to the left joystick's background image
        private int leftSideFingerID = 0; // unique finger id for touches on the left-side half of the screen

       void Start()
        {
            if (XPadTouchLeftJoystick.isEnabled)
            {
                XPadTouchLeftJoystick.LeftJoystick.GetComponent<XPadTouchLeft>().ButtonLeft.SetActive(false);
                XPadTouchLeftJoystick.LeftJoystick.GetComponent<XPadTouchLeft>().ButtonRight.SetActive(false);
                XPadTouchLeftJoystick.LeftJoystick.GetComponent<XPadTouchLeft>().ButtonUp.SetActive(false);
                XPadTouchLeftJoystick.LeftJoystick.GetComponent<XPadTouchLeft>().ButtonDown.SetActive(false);
                XPadTouchLeftJoystick.LeftJoystick.GetComponent<XPadTouchLeft>().ButtonJump.SetActive(false);
                XPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().enabled = false;

                if (XPadTouchLeftJoystick.showPadbackkground)
                {
                    XPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().enabled = true;
                }

                if (XPadTouchLeftJoystick.showHorizontalButton)
                {
                    XPadTouchLeftJoystick.LeftJoystick.GetComponent<XPadTouchLeft>().ButtonLeft.SetActive(true);
                    XPadTouchLeftJoystick.LeftJoystick.GetComponent<XPadTouchLeft>().ButtonRight.SetActive(true);
                }

                if (XPadTouchLeftJoystick.showVerticalButton)
                {
                    XPadTouchLeftJoystick.LeftJoystick.GetComponent<XPadTouchLeft>().ButtonUp.SetActive(true);
                    XPadTouchLeftJoystick.LeftJoystick.GetComponent<XPadTouchLeft>().ButtonDown.SetActive(true);
                }
                if (XPadTouchLeftJoystick.showJumpButton)
                {
                    XPadTouchLeftJoystick.LeftJoystick.GetComponent<XPadTouchLeft>().ButtonJump.SetActive(true);
                }
            }
        }

        void Update()
        {
            // can move code from FixedUpdate() to Update() if your controlled object does not use physics
            // can move code from Update() to FixedUpdate() if your controlled object does use physics
            // can see which one works best for your project
        }

        void FixedUpdate()
        {

        }
    }

}