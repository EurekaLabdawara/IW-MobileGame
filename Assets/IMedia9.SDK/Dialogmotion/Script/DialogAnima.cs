using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAnima : MonoBehaviour {

    public enum CAnimaType { PlayIn, PlayOut }
    public CAnimaType AnimaType;

	// Use this for initialization
	void Start () {
        if (AnimaType == CAnimaType.PlayIn)
        {
            GUIAnimSystemFREE.Instance.PlayInAnims(this.transform, true);
        } else
        {
            GUIAnimSystemFREE.Instance.PlayOutAnims(this.transform, true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
