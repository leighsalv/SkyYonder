using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float speed; //it's public so we can edit it in Inspector panel
	public float drag;
	private Rigidbody rb;

	public Text scoreText;
	private int score;

	void Start()
	{
		rb = GetComponent<Rigidbody> (); //necessary for the circle to move around
		score = 0;
		setScoreText (score);
	}

	//Physics related belongs to FixedUpdate()
	/*MOVE THE PLAYER*/
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		moveVertical = Mathf.Clamp01 (moveVertical); //prevents player to go backward

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); //y coordinate is 0 because circle isn't moving up

		rb.AddForce (movement*speed); //allows circle to move
		//drag = slow circle's movement
	}

	//Cube disappears when circle collides with it (as if we are "collecting" the cube)
	void OnTriggerEnter(Collider obj)
	{
		if(obj.gameObject.CompareTag("CollectCube"))
		{
			obj.gameObject.SetActive(false); // make cubes disappear
			score += 1;
			setScoreText (score);
		}
	}

	void setScoreText(int score)
	{
		scoreText.text = score.ToString ();
	}
}
