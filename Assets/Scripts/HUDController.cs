using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDController : MonoBehaviour 
{

	//Stores the infor on both fighters
	public Fighter player1;
	public Fighter player2;

	//Stores the names of both Fighters
	public Text leftName;
	public Text rightName;

	//Stores the healthbar info on both fighters
	public Scrollbar leftBar;
	public Scrollbar rightBar;

	//Stores the round time and creates battle controller instance
	public Text roundTime;
	public BattleController battle;

	// Use this for initialization
	void Start () 
	{

		//Changes the value of text to show fighter's names
		leftName.text = player1.fighterName;
		rightName.text = player2.fighterName;

	}
	
	// Update is called once per frame
	void Update () 
	{

		//Updates the timer
		roundTime.text = battle.roundTime.ToString ();

		//Depletes health bar when health percent of fighters is less than the current health bar
		if (leftBar.size > player1.HealthPercent) 
		{
			leftBar.size -= 0.01f;
		}
		if (rightBar.size > player2.HealthPercent) 
		{
			rightBar.size -= 0.01f;
		}

	}
}
