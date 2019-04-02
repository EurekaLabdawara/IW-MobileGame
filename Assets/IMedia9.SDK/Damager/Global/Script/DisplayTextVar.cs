using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IMedia9
{
    public class DisplayTextVar : MonoBehaviour
    {

        public enum CVariableType { intVar, floatVar, stringVar, boolVar };
        public CVariableType VariableType;
        public GlobalIntVar intVariables;
        public GlobalFloatVar floatVariables;
        public GlobalStringVar stringVariables;
        public GlobalBoolVar boolVariables;
        public Text DisplayText;

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
                    DisplayText.text = intVariables.GetCurrentValue().ToString();
                    break;
                case CVariableType.floatVar:
                    DisplayText.text = floatVariables.GetCurrentValue().ToString();
                    break;
                case CVariableType.stringVar:
                    DisplayText.text = stringVariables.GetCurrentValue();
                    break;
                case CVariableType.boolVar:
                    DisplayText.text = boolVariables.GetCurrentValue().ToString();
                    break;
            }

        }
    }

}