using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class CameraAutoTrack : MonoBehaviour
    {

        public enum CameraType { ZoomIn, ZoomOut, MoveLeft, MoveRight, MoveUp, MoveDown, RotateLeft, RotateRight }
        public CameraType cameraType;
        public GameObject ActiveCamera;
        public float Speed = 0.5f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (cameraType == CameraType.ZoomIn)
            {
                ActiveCamera.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            }
            if (cameraType == CameraType.ZoomOut)
            {
                ActiveCamera.transform.Translate(Vector3.back * Speed * Time.deltaTime);
            }
            if (cameraType == CameraType.ZoomOut)
            {
                ActiveCamera.transform.Translate(Vector3.back * Speed * Time.deltaTime);
            }
            if (cameraType == CameraType.MoveLeft)
            {
                ActiveCamera.transform.Translate(Vector3.left * Speed * Time.deltaTime);
            }
            if (cameraType == CameraType.MoveRight)
            {
                ActiveCamera.transform.Translate(Vector3.right * Speed * Time.deltaTime);
            }
            if (cameraType == CameraType.MoveUp)
            {
                ActiveCamera.transform.Translate(Vector3.up * Speed * Time.deltaTime);
            }
            if (cameraType == CameraType.MoveDown)
            {
                ActiveCamera.transform.Translate(Vector3.down * Speed * Time.deltaTime);
            }
            if (cameraType == CameraType.RotateLeft)
            {
                ActiveCamera.transform.Rotate(0, -Speed, 0);
            }
            if (cameraType == CameraType.RotateRight)
            {
                ActiveCamera.transform.Rotate(0, Speed, 0);
            }
        }
    }
}
