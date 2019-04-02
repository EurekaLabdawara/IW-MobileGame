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

    public class DPadTouchController : MonoBehaviour
    {
        [System.Serializable]
        public class CDPadTouchLeft
        {
            public bool isEnabled = false;
            public bool isAlwaysVisible = false; // value from left joystick that determines if the left joystick should be always visible or not
            public bool isFixedPosition = false;
            public GameObject LeftJoystick; // background image of the left joystick (the joystick's handle (knob) is a child of this image and moves along with it)
        }
        public CDPadTouchLeft DPadTouchLeftJoystick;

        private Image DPadTouchLeftHandleImage; // handle (knob) image of the left joystick
        private DPadTouchLeft DPadTouchLeft; // script component attached to the left joystick's background image
        private int leftSideFingerID = 0; // unique finger id for touches on the left-side half of the screen

        [System.Serializable]
        public class CDPadTouchRight
        {
            public bool isEnabled = false;
            public bool isAlwaysVisible = false; // value from right joystick that determines if the right joystick should be always visible or not
            public bool isFixedPosition = false;
            public GameObject RightJoystick; // background image of the right joystick (the joystick's handle (knob) is a child of this image and moves along with it)
        }
        public CDPadTouchRight DPadTouchRightJoystick;

        private Image DPadTouchRightHandleImage; // handle (knob) image of the right joystick
        private DPadTouchRight DPadTouchRight; // script component attached to the right joystick's background image
        private int rightSideFingerID = 0; // unique finger id for touches on the right-side half of the screen

        void Start()
        {

            if (DPadTouchLeftJoystick.LeftJoystick.GetComponent<DPadTouchLeft>() == null)
            {
                Debug.LogError("There is no DPadTouchLeft script attached to the Left Joystick game object.");
            }
            else
            {
                DPadTouchLeft = DPadTouchLeftJoystick.LeftJoystick.GetComponent<DPadTouchLeft>(); // gets the left joystick script
                DPadTouchLeft.joystickStaysInFixedPosition = DPadTouchLeftJoystick.isFixedPosition;
                DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().enabled = DPadTouchLeftJoystick.isAlwaysVisible; // sets left joystick background image to be always visible or not
            }

            if (DPadTouchLeft.transform.GetChild(0).GetComponent<Image>() == null)
            {
                Debug.LogError("There is no left joystick handle image attached to this script.");
            }
            else
            {
                DPadTouchLeftHandleImage = DPadTouchLeft.transform.GetChild(0).GetComponent<Image>(); // gets the handle (knob) image of the left joystick
                DPadTouchLeftHandleImage.enabled = DPadTouchLeftJoystick.isAlwaysVisible; // sets left joystick handle (knob) image to be always visible or not
            }


            if (DPadTouchRightJoystick.RightJoystick.GetComponent<DPadTouchRight>() == null)
            {
                Debug.LogError("There is no DPadTouchRight script attached to Right Joystick game object.");
            }
            else
            {
                DPadTouchRight = DPadTouchRightJoystick.RightJoystick.GetComponent<DPadTouchRight>(); // gets the right joystick script
                DPadTouchRight.joystickStaysInFixedPosition = DPadTouchRightJoystick.isFixedPosition;
                DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().enabled = DPadTouchRightJoystick.isAlwaysVisible; // sets right joystick background image to be always visible or not
            }

            if (DPadTouchRight.transform.GetChild(0).GetComponent<Image>() == null)
            {
                Debug.LogError("There is no right joystick handle attached to this script.");
            }
            else
            {
                DPadTouchRightHandleImage = DPadTouchRight.transform.GetChild(0).GetComponent<Image>(); // gets the handle (knob) image of the right joystick
                DPadTouchRightHandleImage.enabled = DPadTouchRightJoystick.isAlwaysVisible; // sets right joystick handle (knob) image to be always visible or not
            }

            if (!DPadTouchLeftJoystick.isEnabled)
            {
                DPadTouchLeftJoystick.LeftJoystick.SetActive(false);
            }
            if (!DPadTouchRightJoystick.isEnabled)
            {
                DPadTouchRightJoystick.RightJoystick.SetActive(false);
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
            // if the screen has been touched
            if (Input.touchCount > 0)
            {
                Touch[] myTouches = Input.touches; // gets all the touches and stores them in an array

                // loops through all the current touches
                for (int i = 0; i < Input.touchCount; i++)
                {
                    // if this touch just started (finger is down for the first time), for this particular touch 
                    if (myTouches[i].phase == TouchPhase.Began)
                    {
                        // if this touch is on the left-side half of screen
                        if (myTouches[i].position.x < Screen.width / 2)
                        {
                            leftSideFingerID = myTouches[i].fingerId; // stores the unique id for this touch that happened on the left-side half of the screen

                            // if the left joystick will drag with any touch (left joystick is not set to stay in a fixed position)
                            if (DPadTouchLeftJoystick.isEnabled)
                            {
                                if (DPadTouchLeft.joystickStaysInFixedPosition == false)
                                {
                                    var currentPosition = DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.position; // gets the current position of the left joystick
                                    currentPosition.x = myTouches[i].position.x + DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.sizeDelta.x / 2; // calculates the x position of the left joystick to where the screen was touched
                                    currentPosition.y = myTouches[i].position.y - DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.sizeDelta.y / 2; // calculates the y position of the left joystick to where the screen was touched

                                    // keeps the left joystick on the left-side half of the screen
                                    currentPosition.x = Mathf.Clamp(currentPosition.x, 0 + DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.sizeDelta.x, Screen.width / 2);
                                    currentPosition.y = Mathf.Clamp(currentPosition.y, 0, Screen.height - DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.sizeDelta.y);

                                    DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.position = currentPosition; // sets the position of the left joystick to where the screen was touched (limited to the left half of the screen)

                                    // enables left joystick on touch
                                    DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().enabled = true;
                                    DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.GetChild(0).GetComponent<Image>().enabled = true;
                                }
                                else
                                {
                                    // left joystick stays fixed, does not set position of left joystick on touch

                                    // if the touch happens within the fixed area of the left joystick's background image within the x coordinate
                                    if ((myTouches[i].position.x <= DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.position.x) && (myTouches[i].position.x >= (DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.position.x - DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.sizeDelta.x)))
                                    {
                                        // and the touch also happens within the left joystick's background image y coordinate
                                        if ((myTouches[i].position.y >= DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.position.y) && (myTouches[i].position.y <= (DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.position.y + DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.sizeDelta.y)))
                                        {
                                            // makes the left joystick appear 
                                            DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().enabled = true;
                                            DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().rectTransform.GetChild(0).GetComponent<Image>().enabled = true;
                                        }
                                    }
                                }
                            }
                        }

                        // if this touch is on the right-side half of screen
                        if (myTouches[i].position.x > Screen.width / 2)
                        {
                            rightSideFingerID = myTouches[i].fingerId; // stores the unique id for this touch that happened on the right-side half of the screen

                            // if the right joystick will drag with any touch
                            if (DPadTouchRightJoystick.isEnabled)
                            {
                                if (DPadTouchRight.joystickStaysInFixedPosition == false)
                                {
                                    var currentPosition = DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.position; // gets the current position of the right joystick
                                    currentPosition.x = myTouches[i].position.x + DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.sizeDelta.x / 2; // calculates the x position of the right joystick to where the screen was touched
                                    currentPosition.y = myTouches[i].position.y - DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.sizeDelta.y / 2; // calculates the y position of the right joystick to where the screen was touched

                                    // keep the right joystick on the right-side half of the screen
                                    currentPosition.x = Mathf.Clamp(currentPosition.x, Screen.width / 2 + DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.sizeDelta.x, Screen.width);
                                    currentPosition.y = Mathf.Clamp(currentPosition.y, 0, Screen.height - DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.sizeDelta.y);

                                    DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.position = currentPosition; // sets the position of the right joystick to where the screen was touched (limited to the right half of the screen)

                                    // enables right joystick on touch
                                    DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().enabled = true;
                                    DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.GetChild(0).GetComponent<Image>().enabled = true;
                                }
                                else
                                {
                                    // right joystick stays fixed, does not set position of right joystick on touch

                                    // if the touch happens within the fixed area of the right joystick's background image within the x coordinate
                                    if ((myTouches[i].position.x <= DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.position.x) && (myTouches[i].position.x >= (DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.position.x - DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.sizeDelta.x)))
                                    {
                                        // and the touch also happens within the right joystick's background image y coordinate
                                        if ((myTouches[i].position.y >= DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.position.y) && (myTouches[i].position.y <= (DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.position.y + DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.sizeDelta.y)))
                                        {
                                            // makes the right joystick appear
                                            DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().enabled = true;
                                            DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().rectTransform.GetChild(0).GetComponent<Image>().enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // if this touch has ended (finger is up and now off of the screen), for this particular touch 
                    if (myTouches[i].phase == TouchPhase.Ended)
                    {
                        // if this touch is the touch that began on the left half of the screen
                        if (myTouches[i].fingerId == leftSideFingerID)
                        {
                            // makes the left joystick disappear or stay visible
                            DPadTouchLeftJoystick.LeftJoystick.GetComponent<Image>().enabled = DPadTouchLeftJoystick.isAlwaysVisible;
                            DPadTouchLeftHandleImage.enabled = DPadTouchLeftJoystick.isAlwaysVisible;
                        }

                        // if this touch is the touch that began on the right half of the screen
                        if (myTouches[i].fingerId == rightSideFingerID)
                        {
                            // makes the right joystick disappear or stay visible
                            DPadTouchRightJoystick.RightJoystick.GetComponent<Image>().enabled = DPadTouchRightJoystick.isAlwaysVisible;
                            DPadTouchRightHandleImage.enabled = DPadTouchRightJoystick.isAlwaysVisible;
                        }
                    }
                }
            }
        }
    }

}