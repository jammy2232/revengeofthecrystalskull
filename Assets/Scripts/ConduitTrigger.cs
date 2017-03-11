using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConduitTrigger : MonoBehaviour {

	public ConduitController conduitToBeControlled;
	private int timeReq = 0;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			DoorsOnTime (10);
		}
	}

	public void DoorsOnTime(int timeRequired)
	{
		timeReq = timeRequired;
		StartCoroutine ("DoorTimer");
	}

	IEnumerator DoorTimer() // example trigger 
	{
		conduitToBeControlled.OpenEnt ();

		yield return new WaitForSeconds (timeReq);

		conduitToBeControlled.CloseEnt ();
		conduitToBeControlled.OpenExt ();

		yield return new WaitForSeconds (timeReq);

		conduitToBeControlled.CloseExt ();

	}

}
