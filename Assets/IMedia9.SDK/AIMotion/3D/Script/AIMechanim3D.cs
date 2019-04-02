using UnityEngine;
using System.Collections;

namespace IMedia9
{

    public class AIMechanim3D : MonoBehaviour
    {
        public bool isEnabled;
        public CharacterController AIController;
        public string PlayerTargetTag;

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
        public bool freezeX;
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
        public AIShooter3D Shooter3D;
        bool isInvokeAttack = false;
        [Space(10)]

        [Header("Mechanim Monitoring")]
        public bool isAttack = false;
        public bool isMoving = false;
        public bool isPatrol = false;
        public bool isGrounded = false;
        public float Distance;

        GameObject PlayerTargetObject;
        bool statusPatrolStart = true;

        void Start()
        {
            if (isPatrolEnabled) isPatrol = true;
        }

        void Update()
        {
            if (isEnabled)
            {
                isGrounded = AIController.isGrounded;
                if (AIController.isGrounded)
                {
                    PlayerTargetObject = GameObject.FindGameObjectWithTag(PlayerTargetTag);
                    if (PlayerTargetObject != null)
                    {
                        if (isOnSearchingRange())
                        {
                            isMoving = true;
                            isPatrol = false;

                            AIController.transform.LookAt(PlayerTargetObject.transform);

                            moveDirection = AIController.transform.forward;
                            moveDirection *= MoveSpeed;
                            moveDirection.y -= gravity * Time.deltaTime;
                            AIController.Move(moveDirection * Time.deltaTime);
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
                                AIController.transform.LookAt(PointBegin.transform);
                                Distance = Vector3.Distance(AIController.transform.position, PointBegin.transform.position);
                                if (Distance < StopRadius)
                                {
                                    statusPatrolStart = false;
                                }
                            }
                            else
                            if (!statusPatrolStart && isPatrol)
                            {
                                AIController.transform.LookAt(PointEnd.transform);
                                Distance = Vector3.Distance(AIController.transform.position, PointEnd.transform.position);
                                if (Distance < StopRadius)
                                {
                                    statusPatrolStart = true;
                                }
                            }
                            moveDirection = AIController.transform.forward;
                            moveDirection *= MoveSpeed;
                            moveDirection.y -= gravity * Time.deltaTime;
                            AIController.Move(moveDirection * Time.deltaTime);
                        }
                    }
                }
                else
                {
                    moveDirection.y -= gravity * Time.deltaTime;
                    AIController.Move(moveDirection * Time.deltaTime);
                }

                if (freezeX)
                {
                    AIController.transform.localEulerAngles = new Vector3(0, AIController.transform.localEulerAngles.y, AIController.transform.localEulerAngles.z);
                }
            }
        }

        bool isOnSearchingRange()
        {
            bool result = false;

            if (PlayerTargetObject != null)
            {
                Distance = Vector3.Distance(AIController.transform.position, PlayerTargetObject.transform.position);
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
            Shooter3D.ExecShooter();
        }

        void Shutdown(bool aValue)
        {
            Debug.Log("AIMechanim3D: Receive Message Shutdown");
            isEnabled = false;
        }

    }
}