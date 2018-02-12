using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{

	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		//distance between player's & camera's positions
		offset = transform.position - player.transform.position;
	}

	//LateUpdate updates every frame after everything is done (i.e. player moved)
	void LateUpdate () 
	{
		transform.position = player.transform.position + offset; 
	}
}
