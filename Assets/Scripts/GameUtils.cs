using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtils 
{
	
	/// <summary>
	/// Plays a sound clip
	/// </summary>
	/// <param name="audioPlayer">Audio player.</param>
	/// <param name="clip">Clip.</param>
	public static void PlaySound(AudioSource audioPlayer, AudioClip clip)
	{
		audioPlayer.Stop ();
		audioPlayer.clip = clip;
		audioPlayer.loop = false;
		audioPlayer.time = 0;
		audioPlayer.Play ();
	}

}
