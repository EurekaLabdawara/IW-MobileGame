using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Mechanim2DXpad : MonoBehaviour
    {

        public enum CMovementType { VelocityDuoDirection, VelocityQuadDirection, VelocityAllDirection }

        public Rigidbody2D TargetController;
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
        Vector2 vSpeed = Vector2.zero;

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
                TargetController.gravityScale = gravity;
                contactFilter.useTriggers = false;
                contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
                contactFilter.useLayerMask = true;
            }
            if (MovementType == CMovementType.VelocityQuadDirection)
            {
                TargetController.gravityScale = 0;
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
                }
                horizontalMove = GetAxisHorizontal() * MoveSpeed;
            }

            if (MovementType == CMovementType.VelocityQuadDirection)
            {
                horizontalMove = GetAxisHorizontal() * MoveSpeed;
                verticalMove = GetAxisVertical() * MoveSpeed;
            }

        }

        void FixedUpdate()
        {
            if (MovementType == CMovementType.VelocityDuoDirection)
            {

                if (horizontalMove > 0)
                {
                    vSpeed = Vector2.right * MoveSpeed * Time.fixedDeltaTime;
                    FacingRight();
                    Movement(vSpeed, false);
                }
                else
                if (horizontalMove < 0)
                {
                    vSpeed = Vector2.left * MoveSpeed * Time.fixedDeltaTime;
                    FacingLeft();
                    Movement(vSpeed, false);
                }
                else
                {
                    vSpeed = Vector2.zero;
                }
                if (isJump && !isGround)
                {
                    vSpeed = Vector2.up * JumpSpeed * Time.fixedDeltaTime;
                    TargetController.position = TargetController.position + vSpeed;
                }
            }

            if (MovementType == CMovementType.VelocityQuadDirection)
            {
                Vector2 vSpeed = Vector2.zero;

                if (horizontalMove > 0)
                {
                    vSpeed = Vector2.right * MoveSpeed * Time.fixedDeltaTime;
                    TargetController.position = TargetController.position + vSpeed;
                }
                if (horizontalMove < 0)
                {
                    vSpeed = Vector2.left * MoveSpeed * Time.fixedDeltaTime;
                    TargetController.position = TargetController.position + vSpeed;
                }
                if (verticalMove > 0)
                {
                    vSpeed = Vector2.up * MoveSpeed * Time.fixedDeltaTime;
                    TargetController.position = TargetController.position + vSpeed;
                }
                if (verticalMove < 0)
                {
                    vSpeed = Vector2.down * MoveSpeed * Time.fixedDeltaTime;
                    TargetController.position = TargetController.position + vSpeed;
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

        void Movement(Vector2 move, bool yMovement)
        {
            float distance = move.magnitude;

            if (distance > minMoveDistance)
            {
                int count = TargetController.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
                hitBufferList.Clear();
                for (int i = 0; i < count; i++)
                {
                    hitBufferList.Add(hitBuffer[i]);
                }

                for (int i = 0; i < hitBufferList.Count; i++)
                {
                    Vector2 currentNormal = hitBufferList[i].normal;
                    if (currentNormal.y > minGroundNormalY)
                    {
                        grounded = true;
                        if (yMovement)
                        {
                            groundNormal = currentNormal;
                            currentNormal.x = 0;
                        }
                    }

                    float projection = Vector2.Dot(velocity, currentNormal);
                    if (projection < 0)
                    {
                        velocity = velocity - projection * currentNormal;
                    }

                    float modifiedDistance = hitBufferList[i].distance - shellRadius;
                    distance = modifiedDistance < distance ? modifiedDistance : distance;
                }


            }

            TargetController.position = TargetController.position + move.normalized * distance;
        }

        void FacingLeft()
        {
            Vector3 theScale = TargetController.transform.localScale;
            if (theScale.x > 0)
            {
                theScale.x *= -1;
            }
            TargetController.transform.localScale = theScale;
        }

        void FacingRight()
        {
            Vector3 theScale = TargetController.transform.localScale;
            if (theScale.x < 0)
            {
                theScale.x *= -1;
            }
            
            TargetController.transform.localScale = theScale;
        }

        void ComputeVelocity()
        {

            if (horizontalMove > 0)
            {
                vSpeed = Vector2.right * MoveSpeed * Time.fixedDeltaTime;
                FacingRight();
            }
            else
            if (horizontalMove < 0)
            {
                vSpeed = Vector2.left * MoveSpeed * Time.fixedDeltaTime;
                FacingLeft();
            }
            else
            {
                vSpeed = Vector2.zero;
            }

            if (LeftPad.IsJumpPadPressed() && grounded)
            {

                velocity.y = JumpSpeed;

            }
            else if (!LeftPad.IsJumpPadPressed())
            {
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * 0.5f;
                }
            }

            targetVelocity = vSpeed * MoveSpeed;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == GroundTag)
            {
                isGround = true;
                isJump = false;
            }
        }

    }
}
