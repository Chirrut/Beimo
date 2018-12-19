using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerScore : MonoBehaviour 
{

	//Gets and stores scores made and the calculated total score
	private int timeScore;
	private int healthScore;
	private int totalScore;

	//Gets the text that displays the scores
	public TextMeshProUGUI timeScoreText;
	public TextMeshProUGUI healthScoreText;
	public TextMeshProUGUI totalScoreText;

	//Stores the score elements within the score list
	private GameObject[] scoreItems;

	// Use this for initialization
	void Start () 
	{

		//Creates and stores the score display in array
		scoreItems = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) 
		{
			scoreItems [i] = transform.GetChild (i).gameObject;
			scoreItems [i].SetActive (false);
		}

	}

	/// <summary>
	/// Calculates the health score.
	/// </summary>
	/// <param name="winner">Winner.</param>
	public void CalcHealthScore(Fighter winner)
	{

		//Gets the remaining health of user as a score
		healthScore = Mathf.RoundToInt(winner.HealthPercent * 100);

		//Displays the health score on screen
		healthScoreText.text = healthScore.ToString ();
		scoreItems [1].SetActive (true);
	}

	/// <summary>
	/// Calculates the score based on remaining time
	/// </summary>
	/// <param name="timeRemain">Time remain.</param>
	public void CalcTimeScore(int timeRemain)
	{

		//Assigns the score based on remaining time
		if (timeRemain > 51) 
		{
			timeScore= 100;
		} 
		else if (timeRemain > 41) 
		{
			timeScore= 80;
		}
		else if (timeRemain > 31) 
		{
			timeScore= 60;
		}
		else if (timeRemain > 21) 
		{
			timeScore= 40;
		}
		else if (timeRemain > 11) 
		{
			timeScore= 20;
		}
		else if (timeRemain > 1) 
		{
			timeScore= 5;
		}

		//Displays the time score on screen
		timeScoreText.text = timeScore.ToString ();
		scoreItems [0].SetActive (true);
	}

	/// <summary>
	/// Calculates the total score.
	/// </summary>
	public void CalcTotalScore()
	{
		totalScore = healthScore + timeScore;
		PlayerPrefs.SetInt ("CurrentScore", totalScore);
		totalScoreText.text = totalScore.ToString ();
		scoreItems [2].SetActive (true);
	}
		
}
