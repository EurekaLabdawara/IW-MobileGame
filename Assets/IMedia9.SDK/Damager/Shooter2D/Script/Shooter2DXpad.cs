using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Shooter2DXpad : MonoBehaviour
    {

        public XPadActionButton TriggerButton;
        public GameObject PlayerObject;
        public GameObject Bullet2D;
        public GameObject BulletPosition2D;
        public int DestroyDelay = 5;
        bool isCooldown = false;
        public bool useDelay = false;
        public int Delay = 1;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (TriggerButton.isActionButtonDown() && !isCooldown)
            {
                isCooldown = true;
                Invoke("Cooldown", 1);
                if (useDelay)
                {
                    Invoke("ExecuteDelay", Delay);
                } else
                {
                    GameObject temp = GameObject.Instantiate(Bullet2D, BulletPosition2D.transform.position, BulletPosition2D.transform.rotation);
                    temp.transform.localScale = PlayerObject.transform.localScale;
                    temp.GetComponent<Bullet2D>().ExecuteShooting(PlayerObject.transform.localScale.x);
                    Destroy(temp.gameObject, DestroyDelay);
                }
            }
        }

        void Cooldown()
        {
            isCooldown = false;
        }

        void ExecuteDelay()
        {
            GameObject temp = GameObject.Instantiate(Bullet2D, BulletPosition2D.transform.position, BulletPosition2D.transform.rotation);
            temp.transform.localScale = PlayerObject.transform.localScale;
            temp.GetComponent<Bullet2D>().ExecuteShooting(PlayerObject.transform.localScale.x);
            Destroy(temp.gameObject, DestroyDelay);
        }

    }

}