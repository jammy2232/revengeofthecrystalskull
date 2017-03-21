using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	private AudioSource mAudioPlayer;
	public AudioClip[] song;
	private int mIndex;

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad (this);

		if (FindObjectsOfType<MusicManager> ().Length > 1)
		{
			Destroy (gameObject);
		}
			
		// Get the audio player reference
		mAudioPlayer = gameObject.GetComponent<AudioSource> ();
		mIndex = 0;

		// if there is a valid song start that song
		if (song [mIndex] != null)
		{
			mAudioPlayer.PlayOneShot (song [mIndex]);
		}

	}

	void Update () {

		// If valid songs exist and the player has stopped
		if (mAudioPlayer.isPlaying == false && mIndex != null)
		{

			// Change the track
			if (mIndex < song.Length)
			{
				mIndex++;
			} 
			else
			{
				mIndex = 0;
			}

			// Start playing the next track
			if(song[mIndex] != null)
			{
				mAudioPlayer.PlayOneShot(song[mIndex]);
			}

		}
	
	}

}



