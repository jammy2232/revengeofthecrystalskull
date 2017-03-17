using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class AirConsoleLogic : MonoBehaviour {

	public int numberOfPlayers;

	private bool[] thrusters;

#if !DISABLE_AIRCONSOLE 

	void Awake () 
	{
		DontDestroyOnLoad(this);
		
		AirConsole.instance.onMessage += OnMessage;
		AirConsole.instance.onConnect += OnConnect;
		AirConsole.instance.onDisconnect += OnDisconnect;

	}

	void Start()
	{
		
		thrusters = new bool[numberOfPlayers]; // Setting up a bool array with the numnber of players required

		if (AirConsole.instance.GetControllerDeviceIds ().Count < numberOfPlayers)
		{
			FindObjectOfType<GameManager> ().Pause (true);
		} 
		else
		{
			FindObjectOfType<GameManager> ().Pause (false);
		}

	}
		

	/// <summary>
	/// We start the game if 4 players are connected and the game is not already running (activePlayers == null).
	/// 
	/// NOTE: We store the controller device_ids of the active players. We do not hardcode player device_ids 1 and 2,
	///       because the two controllers that are connected can have other device_ids e.g. 3 and 7.
	///       For more information read: http://developers.airconsole.com/#/guides/device_ids_and_states
	/// 
	/// </summary>
	/// <param name="device_id">The device_id that connected</param>


	void OnConnect (int device_id)
	{
		//if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0) {

		if (AirConsole.instance.GetControllerDeviceIds ().Count < numberOfPlayers)
		{
			GameManagerPause(true);
		} 
		else 
		{
			GameManagerPause(false);
			StartGame ();
		}

		//}
	}



	/// <summary>
	/// If the game is running and one of the active players leaves, we reset the game.
	/// </summary>
	/// <param name="device_id">The device_id that has left.</param>



	void OnDisconnect (int device_id)
	{
		int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber (device_id);

		if (active_player != -1)
		{
			if (AirConsole.instance.GetControllerDeviceIds ().Count >= numberOfPlayers) 
			{
				GameManagerPause(false);
				StartGame ();
			}
			else 
			{
				GameManagerPause(true);
				AirConsole.instance.SetActivePlayers (0);
			}
		}
	}

	/// <summary>
	/// We check which one of the active players wants to move.
	/// </summary>
	/// <param name="from">From.</param>
	/// <param name="data">Data.</param>


	void OnMessage (int device_id, JToken data)
	{
		int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber (device_id);

		if (active_player != -1) // Check it's a valid player?
		{
			thrusters[active_player] = (bool)data["move"];
		}
	}


	void StartGame () 
	{
		AirConsole.instance.SetActivePlayers ();
	}


	public bool[] GetThrusters() 
	{
		return thrusters;
	}


	void OnDestroy () 
	{
		// unregister airconsole events on scene change
		if (AirConsole.instance != null) 
		{
			AirConsole.instance.onMessage -= OnMessage;
		}
	}

	void GameManagerPause(bool pause)
	{
		GameManager game = FindObjectOfType<GameManager>();

		if(game != null)
		{
			game.Pause(pause);
		}
	}

	public bool AirConsoleReady ()
	{
		return AirConsole.instance.GetControllerDeviceIds ().Count >= numberOfPlayers;
	}



#endif



}
