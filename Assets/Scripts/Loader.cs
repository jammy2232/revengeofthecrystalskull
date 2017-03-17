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
		loading.text = "Loading!!";
	}

	// Update is called once per frame
	void Update () {

		if (AirConsole.instance.IsAirConsoleUnityPluginReady() == true)
		{
			loading.text = "";
			FindObjectOfType<CameraFollow> ().enabled = true;
			FindObjectOfType<AirConsoleLogic> ().enabled = true;
			this.enabled = false;
		}

	}
}
