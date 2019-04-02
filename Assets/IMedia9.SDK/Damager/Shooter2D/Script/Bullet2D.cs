using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Bullet2D : MonoBehaviour
    {

        public float BulletSpeed = 10;
        float Direction;
        bool StartShooting = false;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Direction > 0 && StartShooting)
            {
                transform.Translate(Vector3.right * BulletSpeed * Time.deltaTime);
            }
            else if (Direction < 0 && StartShooting)
            {
                transform.Translate(Vector3.left * BulletSpeed * Time.deltaTime);
            }
        }

        public void ExecuteShooting(float Val)
        {
            Direction = Val;
            StartShooting = true;
        }
    }
}
