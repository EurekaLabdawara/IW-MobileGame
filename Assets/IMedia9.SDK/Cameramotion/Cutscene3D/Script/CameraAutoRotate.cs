using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class CameraAutoRotate : MonoBehaviour
    {

        public enum CameraType { RotateLeft, RotateRight }
        public CameraType cameraType;
        public float Speed = 5f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (cameraType == CameraType.RotateLeft)
            {
                transform.Rotate(0, Speed * Time.deltaTime, 0);
            }
            if (cameraType == CameraType.RotateRight)
            {
                transform.Rotate(0, -Speed * Time.deltaTime, 0);
            }
        }
    }
}