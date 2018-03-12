using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioScript : MonoBehaviour {

	public GameObject cube;
	public AudioSource au;
	public VideoPlayer vid;



	void Start () {

		au = GetComponent<AudioSource> ();
		vid = GetComponent<VideoPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AudioPlay()
	{
		
			au.Play ();
			vid.Play ();
	

			
		}

	public void AudioStop()
	{
		
			au.Stop ();
			vid.Stop ();



	}

}
