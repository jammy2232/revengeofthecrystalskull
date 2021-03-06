﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerConduitButton : MonoBehaviour {

	public TimerConduitController conduitToBeControlled;
	public float timeReq = 10.0f;

	private float timer = 0.0f;
	private bool flash;
	private bool colourSelect;
	private bool lockout = false;
	private Material button;
	private Color currentColour;


	// Use this for initialization
	void Start () {

		button = GetComponent<MeshRenderer> ().material;
		button.SetColor ("_EmissionColor", Color.black);
		currentColour = Color.red;

	}


	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (timer > 0.5f)
		{
			colourSelect = !colourSelect;
			flash = true;
			timer = 0.0f;
		}

		if (flash == true)
		{
			if (colourSelect == true)
			{
				button.SetColor ("_EmissionColor", currentColour);
			} else
			{		
				button.SetColor ("_EmissionColor", Color.black);
			}

			flash = false;
	
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			DoorsOnTime (10);
			currentColour = Color.green;
		}
	}


	public void DoorsOnTime(int timeRequired)
	{
		timeReq = timeRequired;
		if (lockout == false) 
		{
			lockout = true;
			StartCoroutine ("DoorTimer");
		}
	}


	public void GoGreen() 
	{
		currentColour = Color.green;
	}


	IEnumerator DoorTimer() // Trigger to open a door in a set time (as specified above)
	{
		
		conduitToBeControlled.OpenEnt ();
		yield return new WaitForSeconds (timeReq);

		conduitToBeControlled.CloseEnt ();
		currentColour = Color.red;
		conduitToBeControlled.OpenExt ();

		yield return new WaitForSeconds (timeReq);

		conduitToBeControlled.CloseExt ();

		lockout = false;

	}

}
