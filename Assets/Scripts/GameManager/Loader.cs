using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;


public class Loader : MonoBehaviour {

	public Text loading;

	void Awake()
	{
		loading.text = "Loading!!"; // Set the text to assume the loading position
	}

	// Update is called once per frame
	void Update () {

		if (AirConsole.instance.IsAirConsoleUnityPluginReady() == true) // If the Air Console Server is Online
		{

			// Disable the text
			loading.text = "";

			// Special case if the game is started and 4 players are ready (This code needs revision as it references the Air Console API)

			if (AirConsole.instance.GetControllerDeviceIds ().Count >= FindObjectOfType<AirConsoleLogic>().numberOfPlayers)
			{
				FindObjectOfType<GameManager> ().Pause (false);
			}

			// Destroy the loader it's no longer required.
			Destroy(this);

		}

	}
}
