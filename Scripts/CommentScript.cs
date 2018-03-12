using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentScript : MonoBehaviour {


	public Text textfield;
	//public Text postingField;
	public Text t;
	string s="";
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddFeedback()
	{
		s = textfield.text.ToString ();
		s = s.Split ('(') [0];
		Text go = Instantiate (t) as Text;
		t.text = s;
	}

}
