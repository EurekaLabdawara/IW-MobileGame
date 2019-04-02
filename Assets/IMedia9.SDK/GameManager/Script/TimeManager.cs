using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExecutePause()
    {
        Time.timeScale = 0;
    }

    public void ExecutePlay()
    {
        Time.timeScale = 1;
    }

}
