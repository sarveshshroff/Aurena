using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnim : MonoBehaviour {

	public Animator anim;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}


	public void CamAnimation()
	{
		anim.Play ("CamRot");
	}
	public void CamBacck()
	{
		anim.Play ("CamBack");
	}
}
