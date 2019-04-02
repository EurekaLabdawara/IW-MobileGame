using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class AIShooter2D : MonoBehaviour
    {

        public GameObject PlayerObject;
        public GameObject Bullet2D;
        public GameObject BulletPosition2D;
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
            GameObject temp = GameObject.Instantiate(Bullet2D, BulletPosition2D.transform.position, BulletPosition2D.transform.rotation);
            temp.GetComponent<AIBullet2D>().ExecuteShooting(PlayerObject.transform.localScale.x);
            Destroy(temp.gameObject, DestroyDelay);
        }
    }

}