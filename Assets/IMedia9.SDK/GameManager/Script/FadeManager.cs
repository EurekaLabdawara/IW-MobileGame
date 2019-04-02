using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{

    public class FadeManager : MonoBehaviour
    {
        public enum CFadeType { FadeIn, FadeOut, FadeInOut };
        public CFadeType FadeType;
        public GameObject MainImage;
        public CanvasGroup MainCanvasGroup;
        public float InOutDelay;

        // Use this for initialization
        void Start()
        {
            if (FadeType == CFadeType.FadeOut)
            {
                MainCanvasGroup.alpha = 0;
                MainImage.SetActive(true);
            }
            if (FadeType == CFadeType.FadeIn)
            {
                MainCanvasGroup.alpha = 1;
                MainImage.SetActive(true);
            }
            if (FadeType == CFadeType.FadeInOut)
            {
                MainCanvasGroup.alpha = 1;
                MainImage.SetActive(true);
            }
            FadeMe();
        }

        void FadeMe()
        {
            StartCoroutine(ExecuteFade());
        }

        // Update is called once per frame
        void Update()
        {
        }

        IEnumerator ExecuteFade()
        {
            if (FadeType == CFadeType.FadeOut)
            {
                while (MainCanvasGroup.alpha < 1)
                {
                    MainCanvasGroup.alpha += Time.deltaTime / 2;
                    yield return null;
                }
                if (MainCanvasGroup.alpha > 0)
                {
                    MainImage.SetActive(true);
                }
            }
            if (FadeType == CFadeType.FadeIn)
            {
                while (MainCanvasGroup.alpha > 0)
                {
                    MainCanvasGroup.alpha -= Time.deltaTime / 2;
                    yield return null;
                }
                if (MainCanvasGroup.alpha <= 0)
                {
                    MainImage.SetActive(false);
                }
            }
            if (FadeType == CFadeType.FadeInOut)
            {
                while (MainCanvasGroup.alpha > 0)
                {
                    MainCanvasGroup.alpha -= Time.deltaTime / 2;
                    yield return null;
                }

                yield return new WaitForSeconds(InOutDelay);

                while (MainCanvasGroup.alpha < 1)
                {
                    MainCanvasGroup.alpha += Time.deltaTime / 2;
                    yield return null;
                }
            }

            yield return null;
        }
    }

}