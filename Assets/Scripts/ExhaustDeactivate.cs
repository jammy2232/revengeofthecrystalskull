using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustDeactivate : MonoBehaviour {

		public ExhaustPort exhaustPortToBeControlled;
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


		void OnTriggerEnter()
		{
			currentColour = Color.green;
		if (lockout == false) 
		{
			lockout = true;
			StartCoroutine ("DisableExhaust");
		}
		}	

		public void GoGreen()
		{
			currentColour = Color.green;
		}

		IEnumerator DisableExhaust() // example trigger 
		{
		exhaustPortToBeControlled.turnExhaustOff ();
		yield return new WaitForSeconds (timeReq);
		exhaustPortToBeControlled.turnExhaustOn ();
		currentColour = Color.red;
		lockout = false;

		}

}
