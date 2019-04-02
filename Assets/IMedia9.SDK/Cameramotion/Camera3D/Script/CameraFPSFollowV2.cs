// Smooth Follow from Standard Assets
// Converted to C# because I fucking hate UnityScript and it's inexistant C# interoperability
// If you have C# code and you want to edit SmoothFollow's vars ingame, use this instead.
// Modified By: Roedavan ~ Adding a little bit multiple camera function
using UnityEngine;
using System.Collections;

namespace IMedia9
{
    public class CameraFPSFollowV2 : MonoBehaviour
    {
        public GameObject TargetCamera;
        public GameObject TargetObject;
        public KeyCode MouseButton;

        public float distance = 10.0f;
        public float height = 5.0f;
        public float heightDamping = 2.0f;
        public float rotationDamping = 3.0f;
        public float movementSpeed = 0.1f;
        public float rotationSpeed = 4f;
        public float smoothness = 0.85f;

        public Quaternion targetRotation;
        float targetRotationY;
        float targetRotationX;

        void LateUpdate()
        {
            if (!TargetObject) return;

            float wantedRotationAngle = TargetObject.transform.eulerAngles.y;
            float wantedHeight = TargetObject.transform.position.y + height;

            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;

            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            if (Input.GetKey(MouseButton))
            {
                Cursor.visible = false;
                targetRotationY += Input.GetAxis("Mouse X") * rotationSpeed;
                targetRotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
                targetRotation = Quaternion.Euler(targetRotationX, targetRotationY, 0.0f);

                TargetCamera.transform.position = new Vector3(TargetObject.transform.position.x, currentHeight, TargetObject.transform.position.z);
                TargetCamera.transform.rotation = Quaternion.Lerp(TargetCamera.transform.rotation, targetRotation, (1.0f - smoothness));
                TargetCamera.transform.position -= currentRotation * Vector3.forward * distance;

            }
            else
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                distance = distance / 2f;
                height = height / 2f;
            }
            else
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                distance = distance * 2f;
                height = height * 2f;
            }
            else
            {
                transform.position = TargetObject.transform.position;
                transform.position -= currentRotation * Vector3.forward * distance;

                transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
                transform.LookAt(TargetObject.transform);
                Cursor.visible = true;
            }


        }
    }
}