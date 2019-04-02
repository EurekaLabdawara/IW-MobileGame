﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class Anima3DClick : MonoBehaviour
    {

        public enum CCompareType { Greater, Equal, Less }
        public enum CParameterType { Int, Float, Bool, Trigger }

        public bool isEnabled;
        public Animator TargetAnimator;
        public Mechanim3DClick TargetMechanimClick;
        bool isMoving;

        [System.Serializable]
        public class CAnimationState3D
        {
            [Header("Animation Settings")]
            public string StateNow;
            public string StateNext;
            public CParameterType ParameterType;
            public string ParameterName;
            public string PositiveValue;
            public string NegativeValue;
            public KeyCode TriggerKey;
            [Header("Sound Settings")]
            public bool usingSound;
            public AudioSource animaAudioSource;
            public AudioClip animaAudioClip;
        }

        public CAnimationState3D[] AnimationState3D;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                isMoving = TargetMechanimClick.GetIsMoving();

                for (int i = 0; i < AnimationState3D.Length; i++)
                {
                    if (Input.GetKey(AnimationState3D[i].TriggerKey))
                    {
                        isMoving = TargetMechanimClick.GetIsMoving();
                    }

                    if (isMoving)
                    {
                        if (AnimationState3D[i].ParameterType == CParameterType.Float)
                        {
                            float dummyvalue = float.Parse(AnimationState3D[i].PositiveValue);
                            TargetAnimator.SetFloat(AnimationState3D[i].ParameterName, dummyvalue);
                            ExecuteSound(i);
                        }
                        if (AnimationState3D[i].ParameterType == CParameterType.Int)
                        {
                            int dummyvalue = int.Parse(AnimationState3D[i].PositiveValue);
                            TargetAnimator.SetInteger(AnimationState3D[i].ParameterName, dummyvalue);
                            ExecuteSound(i);
                        }
                        if (AnimationState3D[i].ParameterType == CParameterType.Bool)
                        {
                            bool dummyvalue = bool.Parse(AnimationState3D[i].PositiveValue);
                            TargetAnimator.SetBool(AnimationState3D[i].ParameterName, dummyvalue);
                            ExecuteSound(i);
                        }
                        if (AnimationState3D[i].ParameterType == CParameterType.Trigger)
                        {
                            TargetAnimator.SetTrigger(AnimationState3D[i].ParameterName);
                            ExecuteSound(i);
                        }
                    }
                }
            }
        }

        void LateUpdate()
        {
            if (isEnabled)
            {
                for (int i = 0; i < AnimationState3D.Length; i++)
                {
                    if (!isMoving)
                    {
                        if (AnimationState3D[i].ParameterType == CParameterType.Float)
                        {
                            float dummyvalue = float.Parse(AnimationState3D[i].NegativeValue);
                            TargetAnimator.SetFloat(AnimationState3D[i].ParameterName, dummyvalue);
                            ExecuteSound(i, false);
                        }
                        if (AnimationState3D[i].ParameterType == CParameterType.Int)
                        {
                            int dummyvalue = int.Parse(AnimationState3D[i].NegativeValue);
                            TargetAnimator.SetInteger(AnimationState3D[i].ParameterName, dummyvalue);
                            ExecuteSound(i, false);
                        }
                        if (AnimationState3D[i].ParameterType == CParameterType.Bool)
                        {
                            bool dummyvalue = bool.Parse(AnimationState3D[i].NegativeValue);
                            TargetAnimator.SetBool(AnimationState3D[i].ParameterName, dummyvalue);
                            ExecuteSound(i, false);
                        }
                        if (AnimationState3D[i].ParameterType == CParameterType.Trigger)
                        {
                            TargetAnimator.SetTrigger(AnimationState3D[i].ParameterName);
                            ExecuteSound(i, false);
                        }

                    }
                }
            }
        }

        public void ForceStopAnima()
        {
            isMoving = false;
            for (int i = 0; i < AnimationState3D.Length; i++)
            {
                    if (AnimationState3D[i].ParameterType == CParameterType.Float)
                    {
                        float dummyvalue = float.Parse(AnimationState3D[i].NegativeValue);
                        TargetAnimator.SetFloat(AnimationState3D[i].ParameterName, dummyvalue);
                        ExecuteSound(i, false);
                    }
                    if (AnimationState3D[i].ParameterType == CParameterType.Int)
                    {
                        int dummyvalue = int.Parse(AnimationState3D[i].NegativeValue);
                        TargetAnimator.SetInteger(AnimationState3D[i].ParameterName, dummyvalue);
                        ExecuteSound(i, false);
                    }
                    if (AnimationState3D[i].ParameterType == CParameterType.Bool)
                    {
                        bool dummyvalue = bool.Parse(AnimationState3D[i].NegativeValue);
                        TargetAnimator.SetBool(AnimationState3D[i].ParameterName, dummyvalue);
                        ExecuteSound(i, false); 
                    }
            }
        }

        void Shutdown(bool aValue)
        {
            isEnabled = false;
        }

        void ExecuteSound(int index, bool plays = true)
        {
            if (AnimationState3D[index].usingSound)
            {
                if (!AnimationState3D[index].animaAudioSource.isPlaying && plays)
                {
                    AnimationState3D[index].animaAudioSource.clip = AnimationState3D[index].animaAudioClip;
                    AnimationState3D[index].animaAudioSource.Play();
                }
                else if (!plays)
                {
                    AnimationState3D[index].animaAudioSource.clip = AnimationState3D[index].animaAudioClip;
                    AnimationState3D[index].animaAudioSource.Stop();
                }
            }
        }

    }

}