using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class AIShooter3D : MonoBehaviour
    {

        public GameObject Bullet3D;
        public GameObject BulletPosition3D;
        public int DestroyDelay = 5;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ExecShooter()
        {
            GameObject temp = GameObject.Instantiate(Bullet3D, BulletPosition3D.transform.position, BulletPosition3D.transform.rotation);
            Destroy(temp.gameObject, DestroyDelay);
        }
    }

}