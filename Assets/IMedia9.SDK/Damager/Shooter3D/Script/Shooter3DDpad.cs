using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Shooter3DDpad : MonoBehaviour
    {

        bool isCooldown = false;

        public DPadActionButton TriggerButton;
        public GameObject Bullet3D;
        public GameObject BulletPosition3D;
        public int ExecuteDelay = 1;
        public int DestroyDelay = 5;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (TriggerButton.isActionButtonUp() && !isCooldown)
            {
                isCooldown = true;
                Invoke("Cooldown", 1);
                Invoke("ExecuteShooter", ExecuteDelay);
            }
        }

        void ExecuteShooter()
        {
            GameObject temp = GameObject.Instantiate(Bullet3D, BulletPosition3D.transform.position, BulletPosition3D.transform.rotation);
            Destroy(temp.gameObject, DestroyDelay);
        }

        void Cooldown()
        {
            isCooldown = false;
        }
    }

}