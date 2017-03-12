using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutPanel4 : MonoBehaviour {

	private float timer = 0.0f;
	private bool action = false;
	private bool buttonAction = false;

	ExhaustDeactivate test;

	void Start()
	{
		test = FindObjectOfType<ExhaustDeactivate> ();
		GetComponent<Rigidbody>().velocity= new Vector3 (0.0f, -10.0f, 0.0f);
	}

	// Update is called once per frame
	void Update () 
	{

		if (action == true && buttonAction == false)
		{

			Vector3 target = test.transform.position - transform.position;
			Vector3 position = new Vector3 (target.normalized.x, target.normalized.y, 0.0f) * Time.deltaTime;
			transform.position += 1.5f *position ;

		}

		if (action == true && buttonAction == true)
		{
			
			transform.position += new Vector3 (0.0f, -0.05f, 0.0f);

		}

	}

	void OnTriggerEnter( Collider other)
	{

		Debug.Log ("ouch");
		if (other.name == "Flame")
		{
			action = true;
		}

		if (other.tag == "Button")
		{
			buttonAction = true;
			Debug.Log ("Exhaust Button");
		}

	}

}
