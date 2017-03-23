using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public string time;
	private Text[] texts;

	// Use this for initialization
	void Start () {

		time = "";

		DontDestroyOnLoad (this);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (time != "")
		{
			texts = FindObjectsOfType<Text> ();

			if (texts[0].text != null) {
				for (int i = 0; i < texts.Length; i++) {
					if (texts [i].name.ToString() == "TIME") {
						texts [i].text = time;
						time = "";
					}
				}
			}

		}
	}
}
