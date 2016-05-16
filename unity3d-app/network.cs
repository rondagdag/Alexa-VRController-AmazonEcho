using UnityEngine;
using System.Collections;
using SocketIO;

public class network : MonoBehaviour {

	private SocketIOComponent socket;
	private string message;
	private GameObject player;
	public void Start() 
	{
		Debug.Log("connecting");

		player = GameObject.FindGameObjectWithTag ("Player");
		socket = GetComponent<SocketIOComponent>();

		socket.On("open", OnConnected);
		socket.On("new message", OnNewMessage);
		
		socket.Connect();

	}

	public void OnConnected(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);

		var j = new JSONObject(JSONObject.Type.STRING);
		j.str = "VR";
		socket.Emit ("add user",j);
	}

	public void OnNewMessage(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] New Message received: " + e.name + " " + e.data);
		var username = e.data["username"].str;
		Debug.Log (username);
		if (username == "alexa") {
			message = e.data["message"].str.ToLower();

			Debug.Log ("Message:" + message);

			switch (message) {
			case "barber shop":
				player.transform.position = new Vector3 (-37.8199f, 5f, 50.13747f);
				break;
			case "hardware store":
				player.transform.position = new Vector3 (39.82712f, 5f, 71.91634f);
				break;
			case "coffee shop":
				player.transform.position = new Vector3 (22.9177f, 5f, 29.13976f);
				break;
			case "gym":
				player.transform.position = new Vector3 (20.57586f, 5f, 14.77492f);
				break;
			}
		}
	}
}
