using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualObjectiveCamera : MonoBehaviour 
{
	//Stores the transform data of a game object
	public Transform leftTarget;
	public Transform rightTarget;

	//Stores the minimum distance between camera and stage
	public float minDistance;

	// Update is called once per frame
	void Update () 
	{
		//Calculates the distance and centre between two game objects
		float distanceBetweenTargets =Mathf.Abs(leftTarget.position.x - rightTarget.position.x);
		float centrePos = (leftTarget.position.x + rightTarget.position.x) / 2;

		//Adjusts the camera's position based on the distance and centre between two game objects
		transform.position = new Vector3 (centrePos, transform.position.y,Mathf.Min(-distanceBetweenTargets,-minDistance));
	}
		
}
