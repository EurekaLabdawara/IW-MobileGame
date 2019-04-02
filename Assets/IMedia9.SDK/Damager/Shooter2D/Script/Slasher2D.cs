using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Slasher2D : MonoBehaviour
    {

        public KeyCode TriggerKey;
        public GameObject PlayerObject;
        public GameObject Blade2D;
        public GameObject BladePosition2D;
        public int DestroyDelay = 5;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(TriggerKey))
            {
                GameObject temp = GameObject.Instantiate(Blade2D, BladePosition2D.transform.position, BladePosition2D.transform.rotation);
                temp.transform.localScale = PlayerObject.transform.localScale;
                temp.GetComponent<Blade2D>().ExecuteShooting(PlayerObject.transform.localScale.x);
                Destroy(temp.gameObject, DestroyDelay);
            }
        }
    }

}