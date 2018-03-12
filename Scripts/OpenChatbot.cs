using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChatbot : MonoBehaviour {

	public GameObject panel;
	public Text textField;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void openup()
	{
		panel.SetActive (true);
		textField.enabled = true;
	}
}
