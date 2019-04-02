using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{
    public class Anima3DDestroy : MonoBehaviour
    {
        public GlobalFloatVar FloatVar;
        public int DestroyObjectDelay;
        bool isTrigger = false;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (FloatVar.CurrentValue <= 0 && !isTrigger)
            {
                isTrigger = true;
                Invoke("DestroyObject", DestroyObjectDelay);
            }
        }

        void DestroyObject()
        {
            Destroy(this.gameObject);
        }
    }

}