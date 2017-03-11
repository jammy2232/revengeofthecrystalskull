using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private ConduitController[] conduits;
	private ExhaustPort[] exhausts;
	private CrystalSkull skull;
	private StartEndArea startEnd;
	private Button[] conduitButtons;
	private ExhaustDeactivate[] exhaustButtons;
	private missleLauncher[] launchers;

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

	}
	
	// Update is called once per frame
	void Update () {

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
