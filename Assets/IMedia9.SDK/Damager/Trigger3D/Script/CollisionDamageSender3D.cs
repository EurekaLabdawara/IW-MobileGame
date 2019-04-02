using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class CollisionDamageSender3D : MonoBehaviour
    {
        public enum COperator { AddValue, SetValue, SubValue }
        public COperator DamageOperator;
        public float DamageValue;
        public string DamageSenderTag;
        public bool DestroyAfterCollision;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}