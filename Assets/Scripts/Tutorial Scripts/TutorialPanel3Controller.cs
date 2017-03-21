using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel3Controller : MonoBehaviour {

	// Controls which part of the animation the tutorial scene is on.
	private enum stage {ONE, TWO, THREE};
	stage state = stage.ONE;

	private float timer = 0.0f;
	public ParticleSystem thrusterTopRocket;

	// Update is called once per frame
	void Update () 
	{

		switch (state)
		{

		case stage.ONE: //Heading to the button

			transform.position += new Vector3 (0.0f, -0.05f, 0.0f);
			thrusterTopRocket.Play ();
			break;

		case stage.TWO: // After hitting the button - wait for the conduit to respond

			thrusterTopRocket.Stop();
			timer += Time.deltaTime;
			transform.position += new Vector3 (0.0f, -0.01f, 0.0f); // Keep moving slowly - it looks better

			if (timer > 4.0f)
			{
				state = stage.THREE;
			}

			break;

		case stage.THREE: // Once enough time has passed move through the doors.

			transform.position += new Vector3 (0.0f, -0.05f, 0.0f);
			thrusterTopRocket.Play ();
			break;

		}
			
	}

	void OnTriggerEnter()
	{
		
		state = stage.TWO;

	}

}
