using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutPanel3 : MonoBehaviour {

	private float time = 0.0f;
	private bool action = false;

	// Update is called once per frame
	void Update () {

		if (action == false)
		{
			transform.position += new Vector3 (0.0f, -0.05f, 0.0f);
		} else
		{

			time += Time.deltaTime;

			if (time > 3.0f)
			{
				action = false;
			}

		}
		
	}

	void OnTriggerEnter()
	{

		if (time < 1.0f)
		{
			action = true;
		}
	
	}

}
