using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IMedia9
{
    public class DisplayWinLoseCondition : MonoBehaviour
    {
        public enum CConditionType { WinCondition, LoseCondition };
        public enum CVariableType { intVar, floatVar, stringVar, boolVar };
        public CConditionType ConditionType;
        public CVariableType VariableType;
        public GlobalIntVar IntVariables;
        public int IntValue;
        public GlobalFloatVar FloatVariables;
        public float FloatValue;
        public GlobalStringVar StringVariables;
        public string StringValue;
        public GlobalBoolVar BoolVariables;
        public bool BoolValue;
        public int DelayExecute;

        [Header("Canvas Dialog")]
        public Canvas CanvasDialog;

        // Use this for initialization
        void Start()
        {
            CanvasDialog.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (ConditionType == CConditionType.WinCondition) {
                if (VariableType == CVariableType.floatVar) {
                    if (FloatVariables.CurrentValue == FloatValue) {
                        ExecuteWin();
                    }
                }
                if (VariableType == CVariableType.boolVar)
                {
                    if (BoolVariables.CurrentValue == BoolValue)
                    {
                        ExecuteWin();
                    }
                }
                if (VariableType == CVariableType.intVar)
                {
                    if (IntVariables.CurrentValue == IntValue)
                    {
                        ExecuteWin();
                    }
                }
                if (VariableType == CVariableType.stringVar)
                {
                    if (StringVariables.CurrentValue == StringValue)
                    {
                        ExecuteWin();
                    }
                }
            }
            if (ConditionType == CConditionType.LoseCondition)
            {
                if (VariableType == CVariableType.floatVar)
                {
                    if (FloatVariables.CurrentValue == FloatValue)
                    {
                        ExecuteWin();
                    }
                }
                if (VariableType == CVariableType.boolVar)
                {
                    if (BoolVariables.CurrentValue == BoolValue)
                    {
                        ExecuteWin();
                    }
                }
                if (VariableType == CVariableType.intVar)
                {
                    if (IntVariables.CurrentValue == IntValue)
                    {
                        ExecuteWin();
                    }
                }
                if (VariableType == CVariableType.stringVar)
                {
                    if (StringVariables.CurrentValue == StringValue)
                    {
                        ExecuteWin();
                    }
                }
            }
        }

        void ExecuteWin() {
            Invoke("ExecuteWins", DelayExecute);
        }

        void ExecuteLose()
        {
            Invoke("ExecuteLoses", DelayExecute);
        }

        void ExecuteWins()
        {
            Time.timeScale = 0;
            CanvasDialog.gameObject.SetActive(true);
        }

        void ExecuteLoses()
        {
            Time.timeScale = 0;
            CanvasDialog.gameObject.SetActive(true);
        }


    }
}
