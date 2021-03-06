using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel4Controller : MonoBehaviour {

	// Controls which part of the animation the tutorial scene is on.
	private enum stage {ONE, TWO, THREE};
	stage state = stage.ONE;

	public ParticleSystem thrusterTopRocket;
	public ParticleSystem thrusterRightRocket;
	public ParticleSystem thrusterBottomRocket;

	ExhaustButton Button;
	Rigidbody tutorialRB;

	void Start()
	{
		Button = FindObjectOfType<ExhaustButton> ();
		tutorialRB = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () 
	{

		switch (state)
		{

		case stage.ONE: // Heading to the flame.

			transform.position += new Vector3 (0.0f, -0.05f, 0.0f);
			thrusterTopRocket.Play ();
			break;

		case stage.TWO: // After hitting the flame.
			
			Vector3 target = Button.transform.position - transform.position;
			transform.position += new Vector3 (0.05f*target.normalized.x, 0.05f*target.normalized.y, 0.0f);
			thrusterTopRocket.Stop();
			thrusterBottomRocket.Play ();
			thrusterRightRocket.Play ();

			break;

		case stage.THREE: // After pressing the button.
			
			transform.position += new Vector3 (0.0f, -0.05f, 0.0f);
			thrusterTopRocket.Play();
			thrusterBottomRocket.Stop ();
			thrusterRightRocket.Stop ();

			break;

		}

	}

	void OnTriggerEnter( Collider other)
	{
		if (other.name == "Flame")
		{
			state = stage.TWO;
		}

		Debug.Log (other.name);

		if (other.name == "Tutorial Button")
		{
			state = stage.THREE;
		}

	}

}
