using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideScroll : MonoBehaviour {

	public Image Guide1;
	public Image Guide2;
	public Image Guide3;
	void Start () {
		Guide1.enabled = true;
		Guide2.enabled = false;
		Guide3.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Next()
	{
		if(Guide1.enabled)
			{
			Guide1.enabled = false;
			Guide2.enabled = true;

			//Guide2.SetActive (true);
		}
		else if (Guide2.enabled) {
			Guide2.enabled = false;
			Guide3.enabled = true;
		}
		else if (Guide3.enabled) {
			Guide3.enabled = false;
			Guide1.enabled = true;
		}
	}
}
