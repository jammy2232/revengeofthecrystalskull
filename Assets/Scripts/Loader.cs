using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class Loader : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		if (AirConsole.instance.IsAirConsoleUnityPluginReady() == true)
		{
			SceneManager.LoadScene ("mainLevel", LoadSceneMode.Single);
		}

	}
}
