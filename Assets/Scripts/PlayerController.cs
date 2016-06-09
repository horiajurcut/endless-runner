using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float speedMultiplier;
	public float speedIncreaseMilestone;

	public float jumpForce;
	public float jumpTime;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	private Rigidbody2D myRigidbody;
//	private Collider2D myCollider;
	private Animator myAnimator;
	private float jumpTimeCounter;
	private float speedMilestoneCount;

	// Use this for initialization
	void Start ()
	{
		myRigidbody = GetComponent<Rigidbody2D> ();
//		myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();

		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;
	}
	
	// Update is called once per frame
	void Update ()
	{
//		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (transform.position.x > speedMilestoneCount) {
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone *= speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}

		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			if (grounded) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
			}
		}

		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) {
			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
			jumpTimeCounter = 0;
		}

		if (grounded) {
			jumpTimeCounter = jumpTime;
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	}
}
