using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IMedia9
{
    public class DisplayHealthSprite : MonoBehaviour
    {

        public enum CVariableType { intVar, floatVar, stringVar, boolVar };
        public CVariableType VariableType;
        public GlobalIntVar IntVariables;
        public GlobalFloatVar FloatVariables;
        public GlobalStringVar StringVariables;
        public GlobalBoolVar BoolVariables;
        public Slider DisplaySlider;
        public GameObject PlayerObject;
        public GameObject MainCanvas;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            switch (VariableType)
            {
                case CVariableType.intVar:
                    DisplaySlider.value = IntVariables.GetCurrentValue();
                    break;
                case CVariableType.floatVar:
                    DisplaySlider.value = Mathf.RoundToInt(FloatVariables.GetCurrentValue());
                    break;
            }
            if (DisplaySlider.value <= 0)
            {
                DisplaySlider.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                DisplaySlider.transform.GetChild(1).gameObject.SetActive(true);
            }
            if (PlayerObject.transform.localScale.x > 0)
            {
                Vector3 temp = this.transform.localScale;
                if (temp.x > 0) temp.x *= -1;
                this.transform.localScale = temp;
            }
            if (PlayerObject.transform.localScale.x < 0)
            {
                Vector3 temp = this.transform.localScale;
                if (temp.x < 0) temp.x *= -1;
                this.transform.localScale = temp;
            }
        }
    }
}