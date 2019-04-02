using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IMedia9
{
    public class GlobalScore : MonoBehaviour
    {
        public bool isEnabled;
        public int CurrentScore;
        public string ScorePrefix;
        public Text ScoreText;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                ScoreText.text = ScorePrefix + CurrentScore.ToString();
            }
        }
    }
}
