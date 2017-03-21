using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiButton : MonoBehaviour
{
	
	private float flashTimer = 0.0f;
	private bool colourSelect;

	private Material button;
	private Color currentColour;

	private bool pressed = false;

	// Use this for initialization
	void Start () {

		button = GetComponent<MeshRenderer> ().material;
		button.SetColor ("_EmissionColor", Color.black);
		currentColour = Color.red;
	}


	// Update is called once per frame
	void Update () 
	{

		flashTimer += Time.deltaTime;

		if (flashTimer > 0.5f)
		{
			colourSelect = !colourSelect;

			if (colourSelect == true)
			{
				button.SetColor ("_EmissionColor", currentColour);
			} 
			else
			{		
				button.SetColor ("_EmissionColor", Color.black);
			}
				
			flashTimer = 0.0f;

		}
	
	}


	void OnTriggerEnter(Collider other)
	{

	if (other.tag == "Player")
		{
			currentColour = Color.green;
			pressed = true;
		}
	}


	public bool IsPressed()
	{
		return pressed;
	}

}