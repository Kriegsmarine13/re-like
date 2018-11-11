using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallText : MonoBehaviour {
    public string objectDescription;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RenderText()
    {
        var textArea = new Rect(0, 0, Screen.width, Screen.height);
        GUI.Label(textArea, objectDescription);
    }
}
