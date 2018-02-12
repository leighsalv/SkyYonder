using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	// Update is called once per frame
	void Update () 
	{
		Vector3 rotateCube = new Vector3 (15, 30, 45);
		transform.Rotate (rotateCube * Time.deltaTime, Space.World);
	}
}
