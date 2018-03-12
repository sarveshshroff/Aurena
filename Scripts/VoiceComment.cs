using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceComment : MonoBehaviour {

	public Text textwatson;
	public Text textfield;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		string s = textwatson.text.ToString ();
		s = s.Split ('(') [0];
		textfield.text = s;
	}
}
