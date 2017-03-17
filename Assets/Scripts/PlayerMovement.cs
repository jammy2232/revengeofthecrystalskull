using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody playerShip;
	public float thrusterDefaultForce;

	public ParticleSystem thruster1Rocket;
	public ParticleSystem thruster2Rocket;
	public ParticleSystem thruster3Rocket;
	public ParticleSystem thruster4Rocket;

	private Vector3 thruster1Dir;
	private Vector3 thruster2Dir;
	private Vector3 thruster3Dir;
	private Vector3 thruster4Dir;

	private float thruster1Force;
	private float thruster2Force;
	private float thruster3Force;
	private float thruster4Force;

	AirConsoleLogic airConsoleReference;
	private bool[] userControls;


	// Use this for initialization
	void Start () {

		thruster1Dir = new Vector3(1,0,0);
		thruster2Dir = new Vector3(0,0,1);
		thruster3Dir = new Vector3(-1,0,0);
		thruster4Dir = new Vector3(0,0,-1);

		thruster1Force = 0.0f;
		thruster2Force = 0.0f;
		thruster3Force = 0.0f;
		thruster4Force = 0.0f;

		thruster1Rocket.Stop();
		thruster2Rocket.Stop();
		thruster3Rocket.Stop();
		thruster4Rocket.Stop();

		airConsoleReference = FindObjectOfType<GameManager> ().GetComponent<AirConsoleLogic> ();

		if (airConsoleReference != null)
		{
			userControls = airConsoleReference.GetThrusters ();
		}
	
	}

	// Update is called once per frame
	void Update () {

		// Getting the thruster details again - I don't know why we have to do this. If I don't reference to userControls[1] doesn't work - This is a strange bug perhaps. 
		userControls = airConsoleReference.GetThrusters ();

		if (airConsoleReference == null) // check if the airconsole is
		{
			airConsoleReference = FindObjectOfType<GameManager> ().GetComponent<AirConsoleLogic> ();
		}
			
		// Thrusters Controls
		if (Input.GetKey(KeyCode.D) || userControls [3]) { // Player Four
			playerShip.AddRelativeForce (thruster1Dir * thrusterDefaultForce);
			thruster1Rocket.Play ();
		} 
		else 
		{
			thruster1Rocket.Stop();
		}

		if (Input.GetKey (KeyCode.W) || userControls [2]) { // Player Three
			playerShip.AddRelativeForce (thruster2Dir * thrusterDefaultForce);
			thruster2Rocket.Play();
		} 
		else 
		{
			thruster2Rocket.Stop();
		}

		if (Input.GetKey(KeyCode.A) || userControls [1]) { // Player Two
			playerShip.AddRelativeForce (thruster3Dir * thrusterDefaultForce);
			thruster3Rocket.Play();
		} 
		else 
		{
			thruster3Rocket.Stop();
		}

		if (Input.GetKey (KeyCode.S) || userControls [0]) { // Player One
			playerShip.AddRelativeForce (thruster4Dir * thrusterDefaultForce);
			thruster4Rocket.Play();
		} 
		else 
		{
			thruster4Rocket.Stop();
		}

	}

}
