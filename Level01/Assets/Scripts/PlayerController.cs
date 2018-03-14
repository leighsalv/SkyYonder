using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour 
{
	public float speed; //it's public so we can edit it in Inspector panel
	public float drag; //slows down player movement

	public Vector3 jump;
	public float jumpForce = 2.0f;
	public bool isGrounded;
	private Rigidbody rb;

	public GameObject orbLeft;
	public GameObject orbRight;

	private Vector3 offsetLeftOrb;
	private Vector3 offsetRightOrb;

	public TextMeshProUGUI scoreText;
	private int score;

	void Start()
	{
		//scoreText = GetComponent<TextMeshPro> ();
		rb = GetComponent<Rigidbody> (); //necessary for the circle to move around
		jump = new Vector3(0.0f, 2.0f, 0.0f);

		score = 0;
		setScoreText (score);

		//distance between player's & orb particles' positions
		//orbs move along w/ player so we don't have to create a bunch of orb objects
		offsetLeftOrb = orbLeft.transform.position - transform.position;
		offsetRightOrb = orbRight.transform.position - transform.position;
	}

	void OnCollisionStay()
	{
		isGrounded = true;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			rb.AddForce(jump * jumpForce, ForceMode.Impulse);
			isGrounded = false;
		}
	}

	void LateUpdate()
	{
		orbLeft.transform.position = transform.position + offsetLeftOrb;
		orbRight.transform.position = transform.position + offsetRightOrb;
	}

	//Physics related belongs to FixedUpdate()
	/*MOVE THE PLAYER*/
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		moveVertical = Mathf.Clamp01 (moveVertical); //prevents player to go backward

		//moveVertical * 6 bc we want left/right mvmnt to move slower than forward mvmnt
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, (moveVertical*6)); //y coordinate is 0 because circle isn't moving up

		rb.AddForce (movement*speed); //allows circle to move
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





/* public Vector3 jump;
         public float jumpForce = 2.0f;
     
         public bool isGrounded;
         Rigidbody rb;
         void Start(){
             rb = GetComponent<Rigidbody>();
             jump = new Vector3(0.0f, 2.0f, 0.0f);
         }
     
         void OnCollisionStay()
         {
             isGrounded = true;
         }
     
         void Update(){
             if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
     
                 rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                 isGrounded = false;
             }
         }
     }*/