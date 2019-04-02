using UnityEngine;
using System.Collections;

namespace IMedia9
{

    public class CameraManualTrack : MonoBehaviour
    {
        public GameObject TargetCamera;
        public KeyCode Left = KeyCode.LeftArrow, AltLeft = KeyCode.A;
        public KeyCode Right = KeyCode.RightArrow, AltRight = KeyCode.D;
        public KeyCode Forward = KeyCode.UpArrow, AltForward = KeyCode.W;
        public KeyCode Back = KeyCode.DownArrow, AltBack = KeyCode.S;
        public KeyCode Up = KeyCode.PageUp, AltUp = KeyCode.Q;
        public KeyCode Down = KeyCode.PageDown, AltDown = KeyCode.E;
        public KeyCode MouseButton;

        public float movementSpeed = 0.1f;
        public float rotationSpeed = 4f;
        public float smoothness = 0.85f;

        Vector3 targetPosition;

        public Quaternion targetRotation;
        float targetRotationY;
        float targetRotationX;

        // Use this for initialization
        void Start()
        {
            targetPosition = TargetCamera.transform.position;
            targetRotation = TargetCamera.transform.rotation;
            targetRotationY = TargetCamera.transform.localRotation.eulerAngles.y;
            targetRotationX = TargetCamera.transform.localRotation.eulerAngles.x;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(Forward) || Input.GetKey(AltForward) || Input.GetAxis("Mouse ScrollWheel") > 0f)
                targetPosition += TargetCamera.transform.forward * movementSpeed;
            if (Input.GetKey(Left) || Input.GetKey(AltLeft))
                targetPosition -= TargetCamera.transform.right * movementSpeed;
            if (Input.GetKey(Back) || Input.GetKey(AltBack) || Input.GetAxis("Mouse ScrollWheel") < 0f)
                targetPosition -= TargetCamera.transform.forward * movementSpeed;
            if (Input.GetKey(Right) || Input.GetKey(AltRight))
                targetPosition += TargetCamera.transform.right * movementSpeed;
            if (Input.GetKey(Up) || Input.GetKey(AltUp))
                targetPosition -= TargetCamera.transform.up * movementSpeed;
            if (Input.GetKey(Down) || Input.GetKey(AltDown))
                targetPosition += TargetCamera.transform.up * movementSpeed;

            if (Input.GetKey(MouseButton))
            {
                Cursor.visible = false;
                targetRotationY += Input.GetAxis("Mouse X") * rotationSpeed;
                targetRotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
                targetRotation = Quaternion.Euler(targetRotationX, targetRotationY, 0.0f);
            }
            else
                Cursor.visible = true;

            TargetCamera.transform.position = Vector3.Lerp(TargetCamera.transform.position, targetPosition, (1.0f - smoothness));
            TargetCamera.transform.rotation = Quaternion.Lerp(TargetCamera.transform.rotation, targetRotation, (1.0f - smoothness));
        }
    }
}
