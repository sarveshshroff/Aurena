using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using UnityEngine.UI;


public class Client : MonoBehaviour {

	private bool socketReady = false;
	private TcpClient socket;
	private NetworkStream stream;
	private StreamWriter writer;
	public StreamReader reader; 
	public string clientName;
	public GameObject ChatContainer;
	public GameObject messagePrefab;

	public void ConnectToServer()
	{
		if (socketReady)
			return;

		string host = "127.0.0.1";
		int port = 6321;

		string h;
		int p;
		h = GameObject.Find ("HostInput").GetComponent<InputField> ().text;
		if (h != "")
			host = h;

		int.TryParse (GameObject.Find ("PortInput").GetComponent<InputField> ().text, out p);
		if (p != 0)
			port = p;

		try
		{
			socket=new TcpClient(host,port);
			stream=socket.GetStream();
			writer=new StreamWriter(stream);
			reader=new StreamReader(stream);
			socketReady=true;
		}
		catch{
			Debug.Log ("SocketError:" );
		}


	}


	private void Update()
	{
		if (socketReady) {
			if (stream.DataAvailable) {
				string data = reader.ReadLine ();
				if (data != null)
					OnIncomingData (data);

			}
		}
	}


	private void OnIncomingData(string data)
	{
		if (data == "%NAME") {
			Send ("&NAME" + clientName);
			return;
		}

		GameObject go= Instantiate (messagePrefab, ChatContainer.transform) as GameObject;
		go.GetComponentInChildren<Text> ().text = data;
	}

	private void Send(string data)
	{
		if (!socketReady) 
			return;

		writer.WriteLine (data);
		writer.Flush ();
	}

	public void OnSendButton()
	{
		string message = GameObject.Find ("SendInput").GetComponent<InputField> ().text;
		Send (message);
	}

	private void closeSocket()
	{
		if (!socketReady)
			return;
		writer.Close ();
		reader.Close ();	
		socket.Close ();
		socketReady = false;


	}

	private void OnApplicationQuit()
	{
		closeSocket ();
	}

	private void onDisable()
	{
		closeSocket ();
	}
}
