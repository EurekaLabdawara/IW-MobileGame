using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{
    public class GlobalVar : MonoBehaviour
    {

        public enum CVariableType { intVar, floatVar, stringVar, boolVar };
        public CVariableType VariableType;
        public int intVariables;
        public float floatVariables;
        public string stringVariables;
        public bool boolVariables;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}