using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Mechanim3DXpad : MonoBehaviour
    {

        public enum CMovementType { VelocityDuoDirection, VelocityQuadDirection }

        public CharacterController TargetController;
        public CMovementType MovementType;

        [Header("Input Settings")]
        public XPadTouchLeft LeftPad;
        [Space(10)]

        [Header("Movement Settings")]
        public float MoveSpeed = 200;
        public float RotateSpeed = 5;
        public float JumpSpeed = 8.0F;
        public float gravity = 20.0F;
        public string GroundTag = "Ground";
        private Vector3 moveDirection = Vector3.zero;

        float horizontalMove;
        float verticalMove;
        bool isJump;
        bool isGround;
        float accjumpSpeed;
        float rotateVector = 9;

        //-- Physics
        float minGroundNormalY = .65f;
        float gravityModifier = 1f;

        protected Vector2 targetVelocity;
        protected bool grounded;
        protected Vector2 groundNormal;
        protected Vector2 velocity;
        protected ContactFilter2D contactFilter;
        protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
        protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);
        protected const float minMoveDistance = 0.001f;
        protected const float shellRadius = 0.01f;

        // Use this for initialization
        void Start()
        {
            isJump = false;
            if (MovementType == CMovementType.VelocityDuoDirection)
            {
                contactFilter.useTriggers = false;
                contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
                contactFilter.useLayerMask = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (MovementType == CMovementType.VelocityDuoDirection)
            {
                if (LeftPad.IsJumpPadPressed() && isGround)
                {
                    isGround = false;
                    isJump = true;
                    accjumpSpeed = JumpSpeed;
                    moveDirection.y = JumpSpeed;
                }
                horizontalMove = GetAxisHorizontal() * MoveSpeed;

                moveDirection.y -= gravity * Time.deltaTime;
                TargetController.Move(moveDirection * Time.deltaTime);
            }

            if (MovementType == CMovementType.VelocityQuadDirection)
            {
                horizontalMove = GetAxisHorizontal() * MoveSpeed;
                verticalMove = GetAxisVertical() * MoveSpeed;

                moveDirection.y -= gravity * Time.deltaTime;
                TargetController.Move(moveDirection * Time.deltaTime);
            }

            isGround = TargetController.isGrounded;
        }

        void FixedUpdate()
        {
            if (MovementType == CMovementType.VelocityDuoDirection)
            {

                if (horizontalMove > 0)
                {
                    this.transform.localEulerAngles = new Vector3(0, 0, 0);
                    moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                    TargetController.Move(moveDirection);
                }
                else
                if (horizontalMove < 0)
                {
                    this.transform.localEulerAngles = new Vector3(0, -180, 0);
                    moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                    TargetController.Move(moveDirection);
                }
                else
                {
                    moveDirection = Vector3.zero;
                }
                if (isJump && !isGround)
                {
                    moveDirection.y -= gravity * Time.deltaTime;
                }
            }

            if (MovementType == CMovementType.VelocityQuadDirection)
            {

                if (horizontalMove > 0)
                {
                    this.transform.localEulerAngles = new Vector3(0, 0, 0);
                    moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                    TargetController.Move(moveDirection);
                } else
                if (horizontalMove < 0)
                {
                    this.transform.localEulerAngles = new Vector3(0, -180, 0);
                    moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                    TargetController.Move(moveDirection);
                } else
                if (verticalMove > 0)
                {
                    this.transform.localEulerAngles = new Vector3(0, -90, 0);
                    moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                    TargetController.Move(moveDirection);
                } else
                if (verticalMove < 0)
                {
                    this.transform.localEulerAngles = new Vector3(0, 90, 0);
                    moveDirection = transform.forward * MoveSpeed * Time.deltaTime;
                    TargetController.Move(moveDirection);
                } else
                {
                    moveDirection = Vector3.zero;
                }

            }

        }

        void JumpFalse()
        {
            isJump = false;
        }

        float GetAxisHorizontal()
        {
            float result = 0;
            if (LeftPad.IsLeftPadPressed())
            {
                result = -1;
            }
            if (LeftPad.IsRightPadPressed())
            {
                result = 1;
            }
            return result;
        }

        float GetAxisVertical()
        {
            float result = 0;
            if (LeftPad.IsUpPadPressed())
            {
                result = 1;
            }
            if (LeftPad.IsDownPadPressed())
            {
                result = -1;
            }
            return result;
        }

    }
}
