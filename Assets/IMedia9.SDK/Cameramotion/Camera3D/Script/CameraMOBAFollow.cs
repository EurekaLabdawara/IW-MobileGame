using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMOBAFollow : MonoBehaviour {

    public GameObject TargetCamera;
    public GameObject TargetObject;
    Vector3 targetDistance;

	// Use this for initialization
	void Start () {
        targetDistance = TargetCamera.transform.position - TargetObject.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        TargetCamera.transform.position = TargetObject.transform.position + targetDistance;

    }
}
