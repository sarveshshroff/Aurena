using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System;
using System.IO;
public class Server : MonoBehaviour {

	public int port = 6321;
	public List<ServerClient> clients;
	public List<ServerClient> disconnectList; 
	private TcpListener server;
	private bool serverStarted;



	private void Start()
	{
		clients = new List<ServerClient> ();
		disconnectList = new List<ServerClient> ();
		try
		{
			server= new TcpListener(IPAddress.Any, port);
			server.Start();
			StartListening();
			serverStarted=true;
			Debug.Log("Server has been started on port "+ port.ToString());

		}
		catch(Exception e)
		{

			Debug.Log ("Server Error :" + e.Message);


		}
	}
	public void Update()
	{

		if (!serverStarted)
			return;
		foreach (ServerClient c in clients) 
		{
			//is the client still connected
			if (!isConnected (c.tcp)) {
				c.tcp.Close ();
				disconnectList.Add (c);
				continue;

			}
			else
			{

				NetworkStream s = c.tcp.GetStream ();
				if (s.DataAvailable) 
				{
					StreamReader reader = new StreamReader (s, true);
					string data =reader.ReadLine();
					if (data != null)
					{ 
						OnIncomingData (c,data);

					}

				}
			}

			// Check for messages from the client



		}
		for (int i = 0; i < disconnectList.Count - 1; i++) {

			Broadcast (disconnectList [i].clientName + "has disconnected", clients);

			clients.Remove (disconnectList [i]);
			disconnectList.RemoveAt (i);
		}



	}

	private void StartListening()
	{
		server.BeginAcceptTcpClient (AcceptTcpClient, server);
	}


	private bool isConnected(TcpClient c)
	{
		try
		{
			if(c!=null && c.Client!=null && c.Client.Connected)
			{
				if(c.Client.Poll(0,SelectMode.SelectRead))
				{

					return !(c.Client.Receive(new byte[1],SocketFlags.Peek)==0);

				}
				return true;

			}
			else
			{

				return false;
			}

		}
		catch
		{

			return false;
		}

	}

	private void AcceptTcpClient(IAsyncResult ar)
	{
		TcpListener listener = (TcpListener)ar.AsyncState;
		clients.Add (new ServerClient (listener.EndAcceptTcpClient (ar)));
		StartListening ();
		Broadcast ("%NAME", new List<ServerClient> (){ clients [clients.Count - 1] });
		//Broadcast (clients [clients.Count - 1].clientName + "has connected",clients);
		// send message to everyone,someone has connected

	}
	public void OnIncomingData(ServerClient c,string data)
	{  
		//if (data.Contains ("&NAME")) {
			//c.clientName = data.Split ('|') [1];
			//Broadcast (c.clientName + "has connected",clients);
			//return;
	//	}
		Broadcast (c.clientName+":"+   data, clients);
		//Broadcast ("%NAME",new List<ServerClient>(){clients[clients.Count-1]});
	}
	private void Broadcast(string data, List<ServerClient> cl)
	{
		foreach (ServerClient c in cl) {
			try{
				StreamWriter writer=new StreamWriter(c.tcp.GetStream());
				writer.WriteLine(data);
				writer.Flush();
			}
			catch {
				Debug.Log ("Write Error to client" + c.clientName);
			}
		}
	}


}

public class ServerClient
{
	public TcpClient tcp;
	public string clientName;

	public ServerClient(TcpClient clientSocket)
	{
		clientName = "Guest";
		tcp = clientSocket;
	}
}
