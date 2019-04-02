using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPadActionButton : MonoBehaviour
{

    public int ClickStatus;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
    }

    public int GetActionButtonStatus()
    {
        return ClickStatus;
    }

    public bool isActionButtonClicked()
    {
        return ClickStatus == 1;
    }

    public void ActionButtonDown()
    {
        ClickStatus = 1;
        Debug.Log(ClickStatus);
    }

    public void ActionButtonUp()
    {
        ClickStatus = 0;
        Debug.Log(ClickStatus);
    }

    public bool isActionButtonDown()
    {
        return ClickStatus == 1;
    }

    public bool isActionButtonUp()
    {
        return ClickStatus == 0;
    }


}
