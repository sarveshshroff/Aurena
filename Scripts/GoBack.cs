using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoBack : MonoBehaviour {

	public Canvas c;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CanvasDeactivator()
	{
		c.enabled = false;
	}
}
