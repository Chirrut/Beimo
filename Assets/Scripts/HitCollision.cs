using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollision : MonoBehaviour 
{

	//Stores how much damage was done based on type of hit
	public float damage;
	public string hitName;

	//Stores who was the owner of the hit
	public Fighter owner;

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter(Collider other)
	{

		//Gets the fighter script on the object the fighter hit
		Fighter someone = other.gameObject.GetComponent<Fighter> ();

		//Checks to see if the hitter was actually attacking
		if (owner.IsAttacking) 
		{
			//Checks to see if fighter script isn't null and that it isn't itself
			if (someone != null && someone != owner) 
			{
				//Depletes the health of the hurt 
				someone.Hurt(damage);
			}
		}

	}

}
