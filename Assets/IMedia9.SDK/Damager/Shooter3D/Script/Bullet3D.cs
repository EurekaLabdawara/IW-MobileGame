using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Bullet3D : MonoBehaviour
    {

        public float BulletSpeed = 10;
        public AudioSource AudioSFX;

        [Header("Sound Settings")]
        public bool usingStartSound;
        public AudioClip StartSound;
        public bool usingInBetweenSound;
        public AudioClip InBetweenSound;
        public bool usingFinishSound;
        public AudioClip FinishSound;

        [Header("SFX Settings")]
        public bool usingStartSFX;
        public GameObject StartSFX;
        public bool usingInBetweenSFX;
        public GameObject InBetweenSFX;
        public bool usingFinishSFX;
        public GameObject FinishSFX;
        [Space(10)]

        [Header("Target Settings")]
        public string[] TargetTag;

        // Use this for initialization
        void Start()
        {
            if (usingStartSound)
            {
                AudioSFX.clip = StartSound;
                AudioSFX.Play();
            }
            if (usingStartSFX)
            {
                GameObject temp = GameObject.Instantiate(StartSFX, this.transform.position, this.transform.rotation);
                Destroy(temp, 10);
            }
            if (usingInBetweenSFX)
            {
                InBetweenSFX.SetActive(true);
            }
            else
            {
                if (InBetweenSFX != null) InBetweenSFX.SetActive(false);
            }

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);

            if (usingInBetweenSound)
            {
                AudioSFX.clip = InBetweenSound;
                AudioSFX.Play();
            }
            if (usingInBetweenSFX)
            {
                InBetweenSFX.transform.position = this.transform.position;
            }

        }

        void OnTriggerEnter(Collider collider)
        {
            Debug.Log("Hit: " + collider.gameObject.tag);
            bool isHit = false;
            for (int i = 0; i< TargetTag.Length; i++)
            {
                if (TargetTag[i] == collider.gameObject.tag)
                {
                    isHit = true;
                }
            }
            if (isHit)
            {
                if (usingFinishSound)
                {
                    AudioSFX.clip = FinishSound;
                    AudioSFX.Play();
                }
                if (usingFinishSFX)
                {
                    GameObject temp = GameObject.Instantiate(FinishSFX, this.transform.position, this.transform.rotation);
                    Destroy(temp, 10);
                }
                this.GetComponent<Renderer>().enabled = false;
                Destroy(this.gameObject, 5);
            }
        }
    }

}