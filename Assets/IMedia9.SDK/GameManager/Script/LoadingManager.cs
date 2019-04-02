using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace IMedia9
{
    public class LoadingManager : MonoBehaviour
    {

        public static string NextSceneIndex = "NextSceneIndex";
        int scene;
        public GameObject LoadingBar;
        Slider loadbar;

        // Use this for initialization
        void Start()
        {
            loadbar = LoadingBar.GetComponent<Slider>();
            scene = PlayerPrefs.GetInt(LoadingManager.NextSceneIndex);
            Debug.Log("Load NextScene Index: " + scene.ToString());
            if (scene != 0)
            {
                StartCoroutine(LoadNewScene());
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator LoadNewScene()
        {

            yield return new WaitForSeconds(1);

            AsyncOperation async = SceneManager.LoadSceneAsync(scene);

            while (!async.isDone)
            {
    
                yield return null;
            }

        }

    }
}