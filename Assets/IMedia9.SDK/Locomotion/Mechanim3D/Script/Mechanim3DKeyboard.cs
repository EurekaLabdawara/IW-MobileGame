using UnityEngine;
using System.Collections;

namespace IMedia9
{

    public class Mechanim3DKeyboard : MonoBehaviour
    {
        public enum CMovementType { SingleDirection, AllDirection, OctaDirection}

        public CharacterController TargetController;
        public CMovementType MovementType;

        [Header("Input Settings")]
        public KeyCode UpKey = KeyCode.UpArrow;
        public KeyCode DownKey = KeyCode.DownArrow;
        public KeyCode LeftKey = KeyCode.LeftArrow;
        public KeyCode RightKey = KeyCode.RightArrow;
        public KeyCode JumpKey;
        public KeyCode ShiftKey;
        [Space(10)]

        [Header("Movement Settings")]
        public float MoveSpeed = 200;
        public float RotateSpeed = 5;
        public float jumpSpeed = 8.0F;
        public float gravity = 20.0F;
        private Vector3 moveDirection = Vector3.zero;

        void Update()
        {
            if (MovementType == CMovementType.SingleDirection)
            {
                
                if (TargetController.isGrounded)
                {
                    moveDirection = new Vector3(GetAxisHorizontal(), 0, GetAxisVertical());
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= MoveSpeed;
                    if (Input.GetKey(JumpKey))
                        moveDirection.y = jumpSpeed;

                }
                moveDirection.y -= gravity * Time.deltaTime;
                TargetController.Move(moveDirection * Time.deltaTime);
            } else if (MovementType == CMovementType.AllDirection)
            {
                if (TargetController.isGrounded)
                {
                    moveDirection = new Vector3(GetAxisHorizontal(), 0, GetAxisVertical());
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= MoveSpeed;

                    if (Input.GetKey(LeftKey))
                    {
                        transform.Rotate(0, -RotateSpeed, 0);
                    }
                    if (Input.GetKey(RightKey))
                    {
                        transform.Rotate(0, RotateSpeed, 0);
                    }

                    if (Input.GetKey(JumpKey))
                    moveDirection.y = jumpSpeed;

                }
                 moveDirection.y -= gravity * Time.deltaTime;
                TargetController.Move(moveDirection * Time.deltaTime);
            }
            else if (MovementType == CMovementType.OctaDirection)
            {
                if (TargetController.isGrounded)
                {
                    if (Input.GetKey(UpKey) && Input.GetKey(RightKey))
                    {
                        this.transform.localEulerAngles = new Vector3(0, 45, 0);
                        moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                        TargetController.Move(moveDirection);
                    }
                    else
                    if (Input.GetKey(UpKey) && Input.GetKey(LeftKey))
                    {
                        this.transform.localEulerAngles = new Vector3(0, 315, 0);
                        moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                        TargetController.Move(moveDirection);
                    }
                    else
                    if (Input.GetKey(DownKey) && Input.GetKey(RightKey))
                    {
                        this.transform.localEulerAngles = new Vector3(0, 135, 0);
                        moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                        TargetController.Move(moveDirection);
                    }
                    else
                    if (Input.GetKey(DownKey) && Input.GetKey(LeftKey))
                    {
                        this.transform.localEulerAngles = new Vector3(0, 225, 0);
                        moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                        TargetController.Move(moveDirection);
                    }
                    else
                    if (Input.GetKey(UpKey))
                    {
                        this.transform.localEulerAngles = new Vector3(0, 0, 0);
                        moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                        TargetController.Move(moveDirection);
                    } else
                    if (Input.GetKey(DownKey))
                    {
                        this.transform.localEulerAngles = new Vector3(0, 180, 0);
                        moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                        TargetController.Move(moveDirection);
                    }
                    else
                    if (Input.GetKey(LeftKey))
                    {
                        this.transform.localEulerAngles = new Vector3(0, 270, 0);
                        moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                        TargetController.Move(moveDirection);
                    }
                    else
                    if (Input.GetKey(RightKey))
                    {
                        this.transform.localEulerAngles = new Vector3(0, 90, 0);
                        moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                        TargetController.Move(moveDirection);
                    }
                    
                    
                    if (Input.GetKeyUp(UpKey) || Input.GetKeyUp(DownKey) || Input.GetKeyUp(LeftKey) || Input.GetKeyUp(RightKey))
                    {
                        moveDirection = Vector3.zero;
                    }
                    if (Input.GetKey(JumpKey))
                        moveDirection.y = jumpSpeed;

                }
                moveDirection.y -= gravity * Time.deltaTime;
                TargetController.Move(moveDirection);
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