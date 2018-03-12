using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasActivator : MonoBehaviour {

	public Canvas c;
	public GameObject b;
	void Start () {
		c.enabled = false;
		b.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActivateCanvas()
	{
		c.enabled = true;
		b.SetActive( true);
	}
}
