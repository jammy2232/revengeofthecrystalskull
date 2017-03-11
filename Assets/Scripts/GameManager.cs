using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private ConduitController[] conduits;
	private ExhaustPort[] exhausts;
	private CrystalSkull skull;
	private StartEndArea startEnd;
	private Button[] conduitButtons;
	private ExhaustDeactivate[] exhaustButtons;
	private missleLauncher[] launchers;

	private Text gameTimerText;
	private float gameTimer = 0.0f;

	private bool EspaceState = false;


	// Use this for initialization
	void Start ()
	{

		conduits = FindObjectsOfType<ConduitController> ();
		exhausts = FindObjectsOfType<ExhaustPort> ();
		launchers = FindObjectsOfType<missleLauncher> ();
		skull = FindObjectOfType<CrystalSkull> ();
		startEnd = FindObjectOfType<StartEndArea> ();
		conduitButtons = FindObjectsOfType<Button> ();
		exhaustButtons = FindObjectsOfType<ExhaustDeactivate> ();

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

		int milliseconds = (int)((Time.timeSinceLevelLoad*100)%100);
		int seconds = (int)(Time.timeSinceLevelLoad%60); // seconds
		int minutes = (int)((Time.timeSinceLevelLoad/60.0f)%60); // minutes
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

	}

	void OpenAllAndRun()
	{

		for(int i = 0; i < conduits.Length; i++)
		{
			conduits [i].OpenAll ();
		}

		for(int i = 0; i < exhausts.Length; i++)
		{
			exhausts [i].turnExhaustOff();
		}

		for(int i = 0; i < launchers.Length; i++)
		{
			launchers [i].enabled = false;
		}

		for(int i = 0; i < conduitButtons.Length; i++)
		{
			conduitButtons [i].GoGreen ();
		}

		for(int i = 0; i < exhaustButtons.Length; i++)
		{
			exhaustButtons [i].GoGreen ();
		}
			
	}

}
