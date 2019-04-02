using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class CanvasManager : MonoBehaviour
    {
        public bool AutoPlay;

        [System.Serializable]
        public class CCanvasScreen
        {
            public Canvas CanvasScreen;
            public int StartTime;
            public int Duration;
            [HideInInspector]
            public int FinishTime;
            [HideInInspector]
            public bool isPlaying;
            [HideInInspector]
            public bool isDone;

        }

        public Canvas DefaultCanvas;
        public CCanvasScreen[] CanvasScreen;
        int TimeCounter = 0;

        // Use this for initialization
        void Start()
        {
            if (DefaultCanvas != null)
            {
                for (int i = 0; i < CanvasScreen.Length; i++)
                {
                    CanvasScreen[i].CanvasScreen.gameObject.SetActive(false);
                    CanvasScreen[i].isPlaying = false;
                    CanvasScreen[i].isDone = false;
                    CanvasScreen[i].FinishTime = CanvasScreen[i].StartTime + CanvasScreen[i].Duration;
                }
                DefaultCanvas.gameObject.SetActive(true);
            }

            if (AutoPlay)
            {
                InvokeRepeating("RepeatTimer", 1, 1);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (AutoPlay)
            {
                for (int i = 0; i < CanvasScreen.Length; i++)
                {
                    if (CanvasScreen[i].StartTime == TimeCounter && !CanvasScreen[i].isPlaying)
                    {
                        CanvasScreen[i].isPlaying = true;
                        CanvasScreen[i].CanvasScreen.gameObject.SetActive(true);
                    }
                    if (CanvasScreen[i].FinishTime == TimeCounter && !CanvasScreen[i].isDone)
                    {
                        CanvasScreen[i].isDone = true;
                        CanvasScreen[i].CanvasScreen.gameObject.SetActive(false);
                    }
                }
            }
        }

        void RepeatTimer()
        {
            TimeCounter++;
        }

        void SetAllCanvasVisibility(bool aValue)
        {
            for (int i=0; i< CanvasScreen.Length; i++)
            {
                CanvasScreen[i].CanvasScreen.gameObject.SetActive(aValue);
            }
        }

        public void HideAllCanvas()
        {
            for (int i = 0; i < CanvasScreen.Length; i++)
            {
                CanvasScreen[i].CanvasScreen.gameObject.SetActive(false);
            }
        }

        public void ShowAllCanvas()
        {
            for (int i = 0; i < CanvasScreen.Length; i++)
            {
                CanvasScreen[i].CanvasScreen.gameObject.SetActive(true);
            }
        }

        public void ShowCanvas(Canvas ThisCanvas)
        {
            ThisCanvas.gameObject.SetActive(true);
        }

        public void HideCanvas(Canvas ThisCanvas)
        {
            ThisCanvas.gameObject.SetActive(false);
        }


    }

}