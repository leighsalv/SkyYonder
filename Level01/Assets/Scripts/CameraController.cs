using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{

	public GameObject player;
	public GameObject orbLeft;
	public GameObject orbRight;

	private Vector3 offset;
	private Vector3 offsetLeftOrb;
	private Vector3 offsetRightOrb;

	// Use this for initialization
	void Start () 
	{
		//distance between player's & camera's positions
		offset = transform.position - player.transform.position;

		//distance between player's & orb particles' positions
		//orbs move along w/ player so we don't have to create a bunch of orb objects
		offsetLeftOrb = orbLeft.transform.position - player.transform.position;
		offsetRightOrb = orbRight.transform.position - player.transform.position;
	}

	//LateUpdate updates every frame after everything is done (i.e. player moved)
	void LateUpdate () 
	{
		transform.position = player.transform.position + offset; 
		orbLeft.transform.position = player.transform.position + offsetLeftOrb;
		orbRight.transform.position = player.transform.position + offsetRightOrb;
	}
}
