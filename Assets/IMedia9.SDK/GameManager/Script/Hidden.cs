using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden : MonoBehaviour {

    public GUIStyle mySkin;
    public bool isEnabled = true;
    int index = 0;

	// Use this for initialization
	void Start () {
        InvokeRepeating("ForceDisable", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ForceDisabled()
    {
        index++;
        if (index > 6)
        {
            isEnabled = false;
        }
    }

    void OnGUI()
    {
        if (isEnabled)
        {
            GUI.Button(new Rect(5, 5, 160, 30), "", mySkin);
        }
    }
}
