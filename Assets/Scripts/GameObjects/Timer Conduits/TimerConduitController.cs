using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerConduitController : MonoBehaviour {

	DoorController[] doors;
	DoorController entTop;
	DoorController entBot;
	DoorController extTop;
	DoorController extBot;

	// Use this for initialization
	void Start () {

		doors = GetComponentsInChildren<DoorController> ();

		for (int i = 0; i < doors.Length; i++) 
		{
			switch(doors [i].doorType) 
			{
			case DoorController.Type.ENTRANCETOP: 
				entTop = doors [i];
				break;
			case DoorController.Type.ENTRANCEBOTTOM: 
				entBot = doors [i];
				break;
			case DoorController.Type.EXITTOP: 
				extTop = doors [i];
				break;
			case DoorController.Type.EXITBOTTOM: 
				extBot = doors [i];
				break;
			default:
				Debug.Log ("Error");
				break;
			}
		}
	}

	public void OpenAll()
	{
			entTop.Open ();
			entBot.Open ();
			extBot.Open ();
			extTop.Open ();
	}
		
	public void CloseAll()
	{
			entTop.Close ();
			entBot.Close ();
			extBot.Close ();
			extTop.Close ();
	}

	public void OpenEnt()
	{
		entTop.Open ();
		entBot.Open ();
	}

	public void OpenExt()
	{
		extBot.Open ();
		extTop.Open ();
	}

	public void CloseEnt()
	{
		entTop.Close ();
		entBot.Close ();
	}

	public void CloseExt()
	{
		extBot.Close ();
		extTop.Close ();
	}

	public bool EntAvailable()
	{
		// false if the entrance is moving 
		return entBot.ready;
	}

	public bool ExtAvailable()
	{
		// true if the entrance is moving 
		return extBot.ready;
	}
		
}
