using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class DPadActionButton : MonoBehaviour
    {

        public int ClickStatus;
        public int DownStatus;

        // Use this for initialization
        void Start()
        {
            DownStatus = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void LateUpdate()
        {
            if (ClickStatus == 1)
            {
                ClickStatus = 0;
            }
        }

        public int GetActionButtonStatus()
        {
            return ClickStatus;
        }

        public bool isActionButtonClicked()
        {
            return ClickStatus == 1;
        }

        public void ActionButtonDown()
        {
            ClickStatus = 0;
            DownStatus = 1;
            Debug.Log(ClickStatus + " " + DownStatus);
        }

        public void ActionButtonUp()
        {
            ClickStatus = 1;
            DownStatus = 0;
            Debug.Log(ClickStatus);
        }

        public bool isActionButtonDown()
        {
            return ClickStatus == 0;
        }

        public bool isActionButtonUp()
        {
            return ClickStatus == 1;
        }

        public bool isButtonStatusDown()
        {
            return DownStatus == 1;
        }

        public bool isButtonStatusUp()
        {
            return DownStatus == 0;
        }


    }
}
