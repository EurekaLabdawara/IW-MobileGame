using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{
    public class CameraMouseController : MonoBehaviour
    {

        public GameObject TargetCamera;
        public bool AutoRotation;
        public KeyCode MouseButton;

        public float movementSpeed = 0.1f;
        public float rotationSpeed = 4f;
        public float smoothness = 0.85f;

        Vector3 targetPosition;

        [HideInInspector]
        public Quaternion targetRotation;

        public bool useTargetObject = false;
        public GameObject TargetObject;


        float targetRotationY;
        float targetRotationX;


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(MouseButton) && !AutoRotation)
            {
                Cursor.visible = false;
                targetRotationY += Input.GetAxis("Mouse X") * rotationSpeed;
                targetRotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
                targetRotation = Quaternion.Euler(targetRotationX, targetRotationY, 0.0f);
                TargetCamera.transform.rotation = Quaternion.Lerp(TargetCamera.transform.rotation, targetRotation, (1.0f - smoothness));
            }
            else if (AutoRotation)
            {
                Cursor.visible = false;
                targetRotationY += Input.GetAxis("Mouse X") * rotationSpeed;
                targetRotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
                targetRotation = Quaternion.Euler(targetRotationX, targetRotationY, 0.0f);
                TargetCamera.transform.rotation = Quaternion.Lerp(TargetCamera.transform.rotation, targetRotation, (1.0f - smoothness));
            }
            else
            {
                Cursor.visible = true;
            }

            if (useTargetObject)
            {
                if (!Input.GetKey(MouseButton))
                {
                    TargetCamera.transform.LookAt(TargetObject.transform);
                }
            }
        }
    }
}
