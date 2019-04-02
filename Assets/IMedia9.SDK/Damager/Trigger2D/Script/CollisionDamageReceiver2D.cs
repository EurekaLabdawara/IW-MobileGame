using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{
    public class CollisionDamageReceiver2D : MonoBehaviour
    {
        public enum COperator { AddValue, SetValue, SubValue }
        public string SenderTagName;

        [Header("Global Variable")]
        public bool isEnabled;
        public GlobalFloatVar FloatVariable;
        [Space(10)]

        [Header("Monitoring Value")]
        public float DamageReceived;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnCollisionEnter2D(Collision2D collision)
        {
                if (collision.gameObject.tag == SenderTagName)
                {
                    GameObject temp = GameObject.Find(collision.gameObject.name);

                    float temp_Damage = temp.GetComponent<TriggerDamageSender2D>().DamageValue;
                    bool temp_destroy = temp.GetComponent<TriggerDamageSender2D>().DestroyAfterCollision;
                    COperator temp_operator = (COperator)temp.GetComponent<TriggerDamageSender2D>().DamageOperator;
                    DamageReceived = temp_Damage;
                    if (isEnabled)
                    {
                        if (temp_operator == COperator.AddValue)
                        {
                            FloatVariable.AddToCurrentValue(DamageReceived);
                            DamageReceived = 0;
                        }
                        if (temp_operator == COperator.SetValue)
                        {
                            FloatVariable.SetCurrentValue(DamageReceived);
                            DamageReceived = 0;
                        }
                        if (temp_operator == COperator.SubValue)
                        {
                            FloatVariable.SubToCurrentValue(DamageReceived);
                            DamageReceived = 0;
                        }
                        if (temp_destroy)
                        {
                            Destroy(temp, 1);
                        }
                    }
                }
        }

        public float GetDamageReceived()
        {
            float result = DamageReceived;
            DamageReceived = 0;
            return result;
        }
    }

}