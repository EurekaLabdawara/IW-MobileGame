using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Slasher2DXpad : MonoBehaviour
    {

        public XPadActionButton TriggerButton;
        public GameObject PlayerObject;
        public GameObject Blade2D;
        public GameObject BladePosition2D;
        public int DestroyDelay = 5;
        bool isCooldown = false;

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
            }

        }

        void Cooldown()
        {
            isCooldown = false;

            GameObject temp = GameObject.Instantiate(Blade2D, BladePosition2D.transform.position, BladePosition2D.transform.rotation);
            temp.transform.localScale = PlayerObject.transform.localScale;
            temp.GetComponent<Blade2D>().ExecuteShooting(PlayerObject.transform.localScale.x);
            Destroy(temp.gameObject, DestroyDelay);
        }
    }

}