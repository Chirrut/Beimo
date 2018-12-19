using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour {

	//Stores the roundtime and time since last frame
	public int roundTime = 60;
	private float lastTimeUpdate;

	//Stores the two fighters on stage
	public Fighter player1;
	public Fighter player2;

	//Stores the information on banner
	public BannerController banner;
	public ButtonController button;

	//Stores the background music and music player
	public AudioSource musicPlayer;
	public AudioClip bgMusic;

	//Stores whether fight has started
	private bool isBattleStart;
	private bool isBattleOver;

	//Gets the information regarding scoring
	public PlayerScore winnerScore;

	//Stores whether user has won or loss
	private bool userWin;
	private bool userLose;

	// Use this for initialization
	void Start () 
	{
		//Starts banner declaring the first round
		banner.ShowRoundOneFight ();

	}
	
	// Update is called once per frame
	void Update () 
	{

		//Checks to see if banner is done playing and if battle hasn't started
		if (!isBattleStart && !banner.AnimationState && !isBattleOver) 
		{
			//Enables the battle and the players to move
			isBattleStart = true;
			player1.enable = true;
			player2.enable = true;

			//Plays the background music when game starts
			GameUtils.PlaySound (musicPlayer, bgMusic);
		}
			
		//Checks if user has won and banner ended
		if (userWin && !banner.AnimationState) 
		{
			//Gets the score of the player
			winnerScore.CalcHealthScore (player1);
			winnerScore.CalcTimeScore (roundTime);
			winnerScore.CalcTotalScore ();

			//Enables user ability to return to menu
			button.EnableMainMenuBtn ();
		} 
			
		//Checks if user has loss and banner has ended
		if (userLose && !banner.AnimationState) 
		{
			//Returns game to menu
			SceneManager.LoadScene ("MainMenu");
		}

		//Checks if battle has started
		if (isBattleStart && !isBattleOver) 
		{

			//Checks if round time should be ticking
			if (roundTime > 0 && (Time.time - lastTimeUpdate) > 1) 
			{
				//Decreases the round time
				roundTime--;
				lastTimeUpdate = Time.time;
			} 
			else if(roundTime==0)
			{

				//Checks who has more health than the other
				if (player1.HealthPercent > player2.HealthPercent) 
				{
					//Display and store that user won
					userWin = true;
					banner.ShowYouWinBanner ();
				} 
				else 
				{
					//Display and store that user loss
					userLose = true;
					banner.ShowYouLoseBanner ();
				}

				//Disables both players from moving and ends battle
				player1.enable = false;
				player2.enable = false;
				isBattleOver = true;
				isBattleStart = false;
			}
				
			//Checks to see whether a player has zero health
			if (player1.HealthPercent <= 0) 
			{
				//Displays and stores that user loss
				userLose = true;
				banner.ShowYouLoseBanner ();

				//Disables player 2 movements and ends battle
				player2.enable = false;
				isBattleStart = false;
				isBattleOver = true;
			} 
			else if (player2.HealthPercent <= 0) 
			{
				//Displays and stores that user won
				userWin = true;
				banner.ShowYouWinBanner ();

				//Disables user movements and ends battle
				player1.enable = false;
				isBattleStart = false;
				isBattleOver = true;
			}
	
		}			
	}
}
