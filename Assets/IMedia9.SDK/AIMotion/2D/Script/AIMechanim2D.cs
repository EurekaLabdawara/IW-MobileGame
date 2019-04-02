using UnityEngine;
using System.Collections;

namespace IMedia9
{

    public class AIMechanim2D : MonoBehaviour
    {
        public Rigidbody2D AIController;
        public string PlayerTargetTag;
        public string GroundTag = "Ground";

        [Header("Range Settings")]
        public float SearchingRange = 100;
        public float AttackRange = 20;
        [Space(10)]

        [Header("Movement Settings")]
        public float MoveSpeed = 20;
        public float RotateSpeed = 5;
        public float jumpSpeed = 8.0F;
        public float gravity = 20.0F;
        private Vector3 moveDirection = Vector3.zero;
        [Space(10)]

        [Header("Patrol Settings")]
        public bool isPatrolEnabled;
        public GameObject PointBegin;
        public GameObject PointEnd;
        public float StopRadius = 10;
        [Space(10)]

        [Header("Range Attack")]
        public bool isRangedAttack;
        public int AttackDelay;
        public AIShooter2D AIShooter2D;
        bool isInvokeAttack = false;
        [Space(10)]

        [Header("Mechanim Monitoring")]
        public bool isAttack = false;
        public bool isMoving = false;
        public bool isPatrol = false;
        public bool isGrounded = false;
        bool isJump = false;
        Vector2 vSpeed;

        public float Distance;

        GameObject PlayerTargetObject;
        bool statusPatrolStart = true;

        void Start()
        {
            if (isPatrolEnabled) isPatrol = true;
        }

        void Update()
        {

            if (isGrounded)
            {
                PlayerTargetObject = GameObject.FindGameObjectWithTag(PlayerTargetTag);
                if (PlayerTargetObject != null)
                {
                    if (isOnSearchingRange())
                    {
                        isMoving = true;
                        isPatrol = false;

                        if (PlayerTargetObject.transform.position.x < AIController.transform.position.x)
                        {
                            vSpeed = Vector2.left * MoveSpeed * Time.fixedDeltaTime;
                            AIController.position = AIController.position + vSpeed;
                            Vector3 vScale = AIController.gameObject.transform.localScale;
                            if (vScale.x > 0) vScale.x *= -1;
                            AIController.gameObject.transform.localScale = vScale;
                        } else
                        if (PlayerTargetObject.transform.position.x > AIController.transform.position.x)
                        {
                            vSpeed = Vector2.right * MoveSpeed * Time.fixedDeltaTime;
                            AIController.position = AIController.position + vSpeed;
                            Vector3 vScale = AIController.gameObject.transform.localScale;
                            if (vScale.x < 0) vScale.x *= -1;
                            AIController.gameObject.transform.localScale = vScale;
                        }

                        //moveDirection = AIController.transform.forward;
                        //moveDirection *= MoveSpeed;
                        //moveDirection.y -= gravity * Time.deltaTime;
                        //AIController.Move(moveDirection * Time.deltaTime);
                    }
                    else
                    {
                        isMoving = false;
                        if (isPatrolEnabled) isPatrol = true;
                    }

                    if (isOnAttackRange())
                    {
                        isAttack = true;
                        if (isRangedAttack)
                        {
                            if (!isInvokeAttack)
                            {
                                isInvokeAttack = true;
                                InvokeRepeating("ExecAIShooting", AttackDelay, 1);
                            }
                        }
                        isPatrol = false;
                    }
                    else
                    {
                        isAttack = false;
                        isInvokeAttack = false;
                        CancelInvoke();
                        if (isPatrolEnabled) isPatrol = true;
                    }
                }

                if (!isMoving && !isAttack)
                {
                    if (isPatrolEnabled)
                    {
                        if (statusPatrolStart && isPatrol)
                        {
                            Distance = Vector3.Distance(AIController.transform.position, PointBegin.transform.position);
                            if (Distance < StopRadius)
                            {
                                statusPatrolStart = false;
                            }

                            if (AIController.transform.position.x > PointBegin.transform.position.x)
                            {
                                vSpeed = Vector2.left * MoveSpeed * Time.fixedDeltaTime;
                                AIController.position = AIController.position + vSpeed;
                                Vector3 vScale = AIController.gameObject.transform.localScale;
                                if (vScale.x > 0) vScale.x *= -1;
                                AIController.gameObject.transform.localScale = vScale;
                            }
                            else
                            if (AIController.transform.position.x < PointBegin.transform.position.x)
                            {
                                vSpeed = Vector2.right * MoveSpeed * Time.fixedDeltaTime;
                                AIController.position = AIController.position + vSpeed;
                                Vector3 vScale = AIController.gameObject.transform.localScale;
                                if (vScale.x < 0) vScale.x *= -1;
                                AIController.gameObject.transform.localScale = vScale;
                            }

                        }
                        else
                        if (!statusPatrolStart && isPatrol)
                        {
                            Distance = Vector3.Distance(AIController.transform.position, PointEnd.transform.position);
                            if (Distance < StopRadius)
                            {
                                statusPatrolStart = true;
                            }

                            if (AIController.transform.position.x > PointEnd.transform.position.x)
                            {
                                vSpeed = Vector2.left * MoveSpeed * Time.fixedDeltaTime;
                                AIController.position = AIController.position + vSpeed;
                                Vector3 vScale = AIController.gameObject.transform.localScale;
                                if (vScale.x > 0) vScale.x *= -1;
                                AIController.gameObject.transform.localScale = vScale;
                            }
                            else
                            if (AIController.transform.position.x < PointEnd.transform.position.x)
                            {
                                vSpeed = Vector2.right * MoveSpeed * Time.fixedDeltaTime;
                                AIController.position = AIController.position + vSpeed;
                                Vector3 vScale = AIController.gameObject.transform.localScale;
                                if (vScale.x < 0) vScale.x *= -1;
                                AIController.gameObject.transform.localScale = vScale;
                            }
                        }

                        //moveDirection = AIController.transform.forward;
                        //moveDirection *= MoveSpeed;
                        //moveDirection.y -= gravity * Time.deltaTime;
                        //AIController.Move(moveDirection * Time.deltaTime);
                    }
                }
            }
            else
            {
                moveDirection.y -= gravity * Time.deltaTime;
                
                //AIController.Move(moveDirection * Time.deltaTime);
            }
        }

        bool isOnSearchingRange()
        {
            bool result = false;

            if (PlayerTargetObject != null)
            {
                result = (Vector3.Distance(AIController.transform.position, PlayerTargetObject.transform.position) < SearchingRange) &&
                         (Vector3.Distance(AIController.transform.position, PlayerTargetObject.transform.position) > AttackRange);

            }

            return result;
        }

        bool isOnAttackRange()
        {
            bool result = false;

            if (PlayerTargetObject != null)
            {
                result = (Vector3.Distance(AIController.transform.position, PlayerTargetObject.transform.position) < SearchingRange) &&
                         (Vector3.Distance(AIController.transform.position, PlayerTargetObject.transform.position) < AttackRange);
            }

            return result;
        }

        public bool GetMovingStatus()
        {
            return isMoving || isPatrol;
        }

        public bool GetAttackStatus()
        {
            return isAttack;
        }

        public void ExecAIShooting()
        {

            if (PlayerTargetObject.transform.position.x < AIController.transform.position.x)
            {
                Vector3 vScale = AIController.gameObject.transform.localScale;
                if (vScale.x > 0) vScale.x *= -1;
                AIController.gameObject.transform.localScale = vScale;
            }
            else
            if (PlayerTargetObject.transform.position.x > AIController.transform.position.x)
            {
                Vector3 vScale = AIController.gameObject.transform.localScale;
                if (vScale.x < 0) vScale.x *= -1;
                AIController.gameObject.transform.localScale = vScale;
            }

            AIShooter2D.ExecShooter();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == GroundTag)
            {
                isGrounded = true;
                isJump = false;
            }
        }

    }
}