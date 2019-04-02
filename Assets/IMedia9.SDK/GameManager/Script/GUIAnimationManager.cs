    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIAnimationManager : MonoBehaviour {

    public bool AutoPlay;
    public GUIAnimFREE[] AnimatedGUI; 

	// Use this for initialization
	void Start () {
        if (AutoPlay)
        {
            if (AnimatedGUI.Length > 0)
            {
                for (int i = 0; i < AnimatedGUI.Length; i++)
                {
                    if (AnimatedGUI[i] != null)
                    GUIAnimSystemFREE.Instance.PlayInAnims(AnimatedGUI[i].transform, true);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayInAnimation(GUIAnimFREE ThisObject)
    {
        GUIAnimSystemFREE.Instance.PlayInAnims(ThisObject.transform, true);
    }

    public void PlayOutAnimation(GUIAnimFREE ThisObject)
    {
        GUIAnimSystemFREE.Instance.PlayInAnims(ThisObject.transform, true);
    }

}
