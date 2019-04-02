using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Blade2D : MonoBehaviour
    {

        public float BladeOffset = 10;
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
                StartShooting = false;
                transform.Translate(Vector3.right * BladeOffset * Time.deltaTime);
            }
            else if (Direction < 0 && StartShooting)
            {
                StartShooting = false;
                transform.Translate(Vector3.left * BladeOffset * Time.deltaTime);
            }
        }

        public void ExecuteShooting(float Val)
        {
            Direction = Val;
            StartShooting = true;
        }
    }
}
