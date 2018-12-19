using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerController : MonoBehaviour 
{

	//Stores the banner animator and audio player
    private Animator animator;
	private AudioSource audioPlayer;

	//Stores whether banner is animating
	private bool isAnimating;

	// Use this for initialization
	void Awake () 
	{
        animator = GetComponent<Animator>();
		audioPlayer = GetComponent<AudioSource> ();
	}

	/// <summary>
	/// Shows the round one fight banner and audio
	/// </summary>
	public void ShowRoundOneFight()
	{
		isAnimating = true;
		animator.SetTrigger ("isShowRoundOneFight");
	}

	/// <summary>
	/// Shows the you win banner and audio
	/// </summary>
	public void ShowYouWinBanner()
	{
		isAnimating = true;
		animator.SetTrigger ("isWon");
	}

	/// <summary>
	/// Shows you lose banner.
	/// </summary>
	public void ShowYouLoseBanner()
	{
		isAnimating = true;
		animator.SetTrigger ("isLose");
	}

	/// <summary>
	/// Plaies the announcer voice clips
	/// </summary>
	/// <param name="voice">Voice.</param>
	public void PlayVoice(AudioClip voice)
	{
		GameUtils.PlaySound (audioPlayer, voice);
	}

	/// <summary>
	/// Ends the animation.
	/// </summary>
	public void EndAnimation()
	{
		isAnimating = false;
	}
		
	/// <summary>
	/// Gets a value indicating whether this <see cref="BannerController"/> is animating.
	/// </summary>
	/// <value><c>true</c> if animation state; otherwise, <c>false</c>.</value>
	public bool AnimationState
	{
		get 
		{
			return isAnimating;
		}
	}
}
