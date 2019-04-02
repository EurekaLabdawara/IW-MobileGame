using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace IMedia9
{

    public class LevelManager : MonoBehaviour
    {

        public enum CLoadingType { DelayOnly, ClickOnly, CollisionOnly, DelayAndLoading, ClickAndLoading, CollisionAndLoading }
        public enum CCollisionType { OnCollision, OnTrigger }
        public CLoadingType LoadingType;
        public string NextSceneName;
        public int WaitSecond = 10;
        public bool WithLoadingScreen;
        public int NextSceneIndex;
        public CCollisionType CollisionType;
        public string ObjectTag;

        // Use this for initialization
        void Start()
        {
            if (LoadingType == CLoadingType.DelayOnly)
            {
                WithLoadingScreen = false;
                Invoke("NextSceneWithDelay", WaitSecond);
            } 
            if (LoadingType == CLoadingType.DelayAndLoading)
            {
                WithLoadingScreen = true;
                Invoke("NextSceneWithDelay", WaitSecond);
            }
            if (LoadingType == CLoadingType.ClickOnly)
            {
                WithLoadingScreen = false;
            }
            if (LoadingType == CLoadingType.ClickAndLoading)
            {
                WithLoadingScreen = true;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        void NextSceneWithDelay()
        {
            if (WithLoadingScreen)
            {
                LevelManager.LoadScene(NextSceneIndex);
            }
            else
            {
                SceneManager.LoadScene(NextSceneName);

            }
        }

        public void NextSceneWithClick()
        {
            if (WithLoadingScreen)
            {
                LevelManager.LoadScene(NextSceneIndex);
            }
            else
            {
                SceneManager.LoadScene(NextSceneName);
            }
        }

        public void GoToSceneName(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }

        public void GoToSceneIndex(int SceneIndex)
        {
            PlayerPrefs.SetInt(LoadingManager.NextSceneIndex, SceneIndex);
            Debug.Log("Save NextScene Index: " + SceneIndex.ToString());
            LevelManager.LoadScene(SceneIndex);
        }

        void OnTriggerEnter(Collider collider)
        {
            if (LoadingType == CLoadingType.CollisionAndLoading)
            {
                WithLoadingScreen = true;
            }

            if (LoadingType == CLoadingType.CollisionOnly || LoadingType == CLoadingType.CollisionAndLoading)
            {
                if (CollisionType == CCollisionType.OnTrigger)
                {
                    if (collider.gameObject.tag == ObjectTag)
                    {
                        if (WithLoadingScreen)
                        {
                            LevelManager.LoadScene(NextSceneIndex);
                        }
                        else
                        {
                            SceneManager.LoadScene(NextSceneName);
                        }

                    }
                }
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (LoadingType == CLoadingType.CollisionAndLoading)
            {
                WithLoadingScreen = true;
            }

            if (LoadingType == CLoadingType.CollisionOnly || LoadingType == CLoadingType.CollisionAndLoading)
            {
                if (CollisionType == CCollisionType.OnCollision)
                {
                    if (collision.gameObject.tag == ObjectTag)
                    {
                        if (WithLoadingScreen)
                        {
                            LevelManager.LoadScene(NextSceneIndex);
                        }
                        else
                        {
                            SceneManager.LoadScene(NextSceneName);
                        }
                    }
                }
            }
        }

        public static void LoadScene(int scene_index)
        {
            PlayerPrefs.SetInt(LoadingManager.NextSceneIndex, scene_index);
            Debug.Log("Save NextScene Index: " + scene_index.ToString());
            SceneManager.LoadScene("Scene00.LoadingScreen");
        }

    }

}