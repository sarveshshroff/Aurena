using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechWebBrowse : MonoBehaviour {

	public Text textField;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Browse()
	{
		string dom="";
		string s = textField.text.ToString ();
		dom = s.Split ('(') [0];

		Application.OpenURL ("https://www.youtube.com/results?search_query=" + dom);


	}
}
