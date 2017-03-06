using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	public enum Type { ENTRANCETOP, ENTRANCEBOTTOM, EXITTOP, EXITBOTTOM };
	public Type doorType;
	private float mxMod;
	private float myMod;
	[HideInInspector]
	public bool ready = true;

	void Start()
	{
		switch (doorType) {
		case Type.ENTRANCETOP:
			mxMod = -1.0f;
			myMod = 1.0f;
			break;
		case Type.ENTRANCEBOTTOM:
			mxMod = -1.0f;
			myMod = -1.0f;
			break;
		case Type.EXITTOP:
			mxMod = 1.0f;
			myMod = 1.0f;
			break;
		case Type.EXITBOTTOM:
			mxMod = 1.0f;
			myMod = -1.0f;
			break;
		}
	}

	public void Open()
	{
		if (ready == true) {
			ready = false;
			StartCoroutine ("OpenDoorMovement");
		}
	}

	IEnumerator OpenDoorMovement ()
	{
		while (Mathf.Abs(transform.localPosition.y) < 1.7f) 
		{
			if (Mathf.Abs(transform.localPosition.x) < 2.6f) {
				transform.localPosition += new Vector3 (mxMod * 0.1f, 0.0f, 0.0f) * Time.deltaTime;
			} else {
				transform.localPosition += new Vector3 (0.0f, myMod * 0.3f, 0.0f) * Time.deltaTime;
			}
			yield return null;
		}

		ready = true;

	}

	public void Close()
	{
		if (ready == true) {
			ready = false;
			StartCoroutine ("CloseDoorMovement");
		}
	}

	IEnumerator CloseDoorMovement ()
	{
		while (Mathf.Abs(transform.localPosition.x) > 2.5f) 
		{
			if (Mathf.Abs(transform.localPosition.y) > 0.625f) {
				transform.localPosition += new Vector3 (0.0f, myMod * -0.3f, 0.0f) * Time.deltaTime;
			} else {
				transform.localPosition += new Vector3 (mxMod * -0.1f, 0.0f, 0.0f) * Time.deltaTime;
			}
			yield return null;
		}

		ready = true;

	}

}
