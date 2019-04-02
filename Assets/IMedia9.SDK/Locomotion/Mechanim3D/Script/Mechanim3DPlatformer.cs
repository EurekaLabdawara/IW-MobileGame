using UnityEngine;
using System.Collections;

namespace IMedia9
{

    public class Mechanim3DPlatformer : MonoBehaviour
    {
        public enum CMovementType { Platformer, TetraDirection, OctaDirection }

        public CharacterController TargetController;
        public CMovementType MovementType;

        [Header("Input Settings")]
        public KeyCode UpKey = KeyCode.UpArrow;
        public KeyCode DownKey = KeyCode.DownArrow;
        public KeyCode LeftKey = KeyCode.LeftArrow;
        public KeyCode RightKey = KeyCode.RightArrow;
        public KeyCode JumpKey;
        public KeyCode ShiftKey;
        public float Speed = 20;
        [Space(10)]

        [Header("Movement Settings")]
        public float jumpSpeed = 8.0F;
        public float gravity = 20.0F;
        public bool followDirection;
        public GameObject VisualObject;
        private Vector3 moveDirection = Vector3.zero;

        void Update()
        {
            if (MovementType == CMovementType.Platformer)
            {

                if (TargetController.isGrounded)
                {
                    moveDirection = new Vector3(0, 0, GetAxisHorizontal());
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= Speed;
                    if (Input.GetKey(JumpKey))
                        moveDirection.y = jumpSpeed;

                }
                moveDirection.y -= gravity * Time.deltaTime;
                TargetController.Move(moveDirection * Time.deltaTime);
            }
            else if (MovementType == CMovementType.TetraDirection)
            {
                moveDirection = Vector3.zero;
                if (GetAxisHorizontal() != 0)
                {
                    if (GetAxisHorizontal() > 0)
                    {
                        moveDirection = new Vector3(0, 0, GetAxisHorizontal());
                        moveDirection = transform.TransformDirection(moveDirection);
                        moveDirection *= Speed;
                        if (followDirection) VisualObject.transform.localEulerAngles = new Vector3(0, 0, 0);
                    }
                    else
                    if (GetAxisHorizontal() < 0)
                    {
                        moveDirection = new Vector3(0, 0, GetAxisHorizontal());
                        moveDirection = transform.TransformDirection(moveDirection);
                        moveDirection *= Speed;
                        if (followDirection) VisualObject.transform.localEulerAngles = new Vector3(0, 180, 0);
                    }
                }
                else if (GetAxisVertical() != 0)
                {
                    if (GetAxisVertical() > 0)
                    {
                        moveDirection = new Vector3(0, GetAxisVertical(), 0);
                        moveDirection *= Speed;
                        if (followDirection) VisualObject.transform.localEulerAngles = new Vector3(0, 270, 0);
                    }
                    else
                    if (GetAxisVertical() < 0)
                    {
                        moveDirection = new Vector3(0, GetAxisVertical(), 0);
                        moveDirection *= Speed;
                        if (followDirection) VisualObject.transform.localEulerAngles = new Vector3(0, 270, 0);
                    }
                }

                TargetController.Move(moveDirection * Time.deltaTime);
            }
            else if (MovementType == CMovementType.OctaDirection)
            {
                moveDirection = new Vector3(0, GetAxisVertical(), GetAxisHorizontal());
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= Speed;
                TargetController.Move(moveDirection * Time.deltaTime);

                if (followDirection)
                {
                    VisualObject.transform.LookAt(VisualObject.transform.position + moveDirection);
                }

            }

        }

        float GetAxisHorizontal()
        {
            float result = 0;
            if (Input.GetKey(LeftKey))
            {
                result = -1;
            }
            if (Input.GetKey(RightKey))
            {
                result = 1;
            }
            return result;
        }

        float GetAxisVertical()
        {
            float result = 0;
            if (Input.GetKey(UpKey))
            {
                result = 1;
            }
            if (Input.GetKey(DownKey))
            {
                result = -1;
            }
            return result;
        }

    }
}