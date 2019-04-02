using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Mechanim3DDefault : MonoBehaviour
    {

        public enum CMovementType { SingleDirection, QuadDirection, OctaDirection }
        public CharacterController TargetController;
        public CMovementType MovementType;
        public KeyCode UpKey = KeyCode.UpArrow;
        public KeyCode DownKey = KeyCode.DownArrow;
        public KeyCode LeftKey = KeyCode.LeftArrow;
        public KeyCode RightKey = KeyCode.RightArrow;
        public KeyCode ShiftKey;
        public float Speed = 200;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (MovementType == CMovementType.SingleDirection)
            {
                if (Input.GetKey(UpKey))
                {
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }
                if (Input.GetKey(DownKey))
                {
                    TargetController.SimpleMove(-transform.forward * Speed * Time.deltaTime);
                }
                if (Input.GetKey(LeftKey))
                {
                    transform.Rotate(0, -1, 0);
                }
                if (Input.GetKey(RightKey))
                {
                    transform.Rotate(0, 1, 0);
                }
            }
            if (MovementType == CMovementType.QuadDirection)
            {
                if (Input.GetKey(UpKey))
                {
                    this.transform.localEulerAngles = new Vector3(0, 0, 0);
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }
                if (Input.GetKey(DownKey))
                {
                    this.transform.localEulerAngles = new Vector3(0, 180, 0);
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }
                if (Input.GetKey(LeftKey))
                {
                    this.transform.localEulerAngles = new Vector3(0, 270, 0);
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }
                if (Input.GetKey(RightKey))
                {
                    this.transform.localEulerAngles = new Vector3(0, 90, 0);
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }
            }
            if (MovementType == CMovementType.OctaDirection)
            {
                if (Input.GetKey(UpKey) && Input.GetKey(RightKey))
                {
                    this.transform.localEulerAngles = new Vector3(0, 45, 0);
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }
                else if (Input.GetKey(UpKey) && Input.GetKey(LeftKey))
                {
                    this.transform.localEulerAngles = new Vector3(0, 315, 0);
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }
                else if (Input.GetKey(DownKey) && Input.GetKey(RightKey))
                {
                    this.transform.localEulerAngles = new Vector3(0, 135, 0);
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }
                else if (Input.GetKey(DownKey) && Input.GetKey(LeftKey))
                {
                    this.transform.localEulerAngles = new Vector3(0, 225, 0);
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }
                else if (Input.GetKey(UpKey))
                {
                    this.transform.localEulerAngles = new Vector3(0, 0, 0);
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }
                else if(Input.GetKey(DownKey))
                {
                    this.transform.localEulerAngles = new Vector3(0, 180, 0);
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }
                else if(Input.GetKey(LeftKey))
                {
                    this.transform.localEulerAngles = new Vector3(0, 270, 0);
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }
                else if(Input.GetKey(RightKey))
                {
                    this.transform.localEulerAngles = new Vector3(0, 90, 0);
                    TargetController.SimpleMove(transform.forward * Speed * Time.deltaTime);
                }

            }
        }
    }
}