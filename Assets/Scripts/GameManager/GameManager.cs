using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class GameManager : MonoBehaviour {

	public Text uiText;

	AirConsoleLogic airConsole;
	private TimerConduitController[] timerConduits;
	private ExhaustPort[] exhausts;
	private CrystalSkull skull;
	private StartEndArea startEnd;
	private TimerConduitButton[] timeConduitButtons; // Add a script to stop coroutines for all these 
	private ExhaustButton[] exhaustButtons;// Add a script to stop coroutines.
	private missleLauncher[] launchers;
	private IntakeFan[] fans;
	private timedPort[] timedports;
	private GameObject[] pauseList;

	private Text gameTimerText;
	private float gameTimer = 0.0f;

	private bool EspaceState = false;
	private bool pause;

	string temp = "";
	private bool quit = false;

	// Use this for initialization
	void Start ()
	{

		GetObjectReferences ();

		pauseList = FindObjectsOfType<GameObject> ();

		Pause (true);

		// getting the game timer - is there a more efficient way. 
		Text[] temp = FindObjectsOfType<Text>();
		for (int i = 0; i < temp.Length; i++) 
		{
			if (temp [i].name == "GameTimer") {
				gameTimerText = temp [i];
			}
		}
	}

	// Update is called once per frame
	void Update () {

		if (pause == false) {
			gameTimer += Time.deltaTime;
		}

		int milliseconds = (int)((gameTimer*100)%100);
		int seconds = (int)(gameTimer%60); // seconds
		int minutes = (int)((gameTimer/60.0f)%60); // minutes
		gameTimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
			
		if (skull.collected == true && startEnd.playerPresent == true)
		{
			// End State
			SceneManager.LoadScene("EndGame");

		}

		if (skull.collected == true && EspaceState == false)
		{
			OpenAllAndRun ();
			EspaceState = true;
		}

		if (airConsole.AirConsoleReady () && pause == false && quit == false)
		{
			uiText.text = "";
		}
		else if (quit == false)
		{
			uiText.text = "WAITING FOR MORE PLAYERS!";
		}


		if(Input.GetKeyUp(KeyCode.Escape) == true && quit == false)
		{
			temp = uiText.text; 
			uiText.text = "PRESS ESC AGAIN TO QUIT OR SPACE TO CONTINUE";
			quit = true;
			Pause (true);
		}

		if(Input.GetKeyDown(KeyCode.Escape) == true && quit == true)
		{
			SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
		}

		if(Input.GetKeyDown(KeyCode.Space) == true && quit == true)
		{
			quit = false;
			uiText.text = temp;

			if (AirConsole.instance.GetControllerDeviceIds ().Count >= airConsole.numberOfPlayers)
			{
				Pause (false);
			}

		}

	}

	void OpenAllAndRun()
	{

		for(int i = 0; i < timerConduits.Length; i++)
		{
			timerConduits [i].OpenAll ();
		}

		for(int i = 0; i < exhausts.Length; i++)
		{
			exhausts [i].turnExhaustOff();
		}

		for(int i = 0; i < launchers.Length; i++)
		{
			launchers [i].enabled = false;
		}

		for(int i = 0; i < timeConduitButtons.Length; i++)
		{
			timeConduitButtons [i].StopAllCoroutines ();
			timeConduitButtons [i].GoGreen ();
		}

		for(int i = 0; i < exhaustButtons.Length; i++)
		{
			exhaustButtons [i].StopAllCoroutines ();
			exhaustButtons [i].GoGreen ();
		}

		for(int i = 0; i < timedports.Length; i++)
		{
			timedports [i].EndGameState ();
		}
			
	}

	public void Pause(bool mpause)
	{

		pause = mpause;

		for (int i = 0; i < pauseList.Length; i++)
		{
			if (pauseList [i] == null) {
				Debug.Log("iPosition" + i);
			}
			if (pauseList [i].tag != "GAMEMANAGER" && pauseList [i].tag != "UI" && pauseList[i].tag != "MainCamera")
			{
				pauseList [i].SetActive (!pause);
			}
		}


	}

	private void GetObjectReferences()
	{
		airConsole = FindObjectOfType<AirConsoleLogic>();
		timerConduits = FindObjectsOfType<TimerConduitController> ();
		exhausts = FindObjectsOfType<ExhaustPort> ();
		launchers = FindObjectsOfType<missleLauncher> ();
		skull = FindObjectOfType<CrystalSkull> ();
		startEnd = FindObjectOfType<StartEndArea> ();
		timeConduitButtons = FindObjectsOfType<TimerConduitButton> ();
		exhaustButtons = FindObjectsOfType<ExhaustButton> ();
		fans = FindObjectsOfType<IntakeFan> ();
		timedports = FindObjectsOfType < timedPort> ();
	}


}
