using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private bool isGrounded;
	public float speed = 1.0f;
	public float jumpForce = 10.0f;
	private Vector3 moveDirection = Vector3.zero;
	RaycastHit hit;
	float distanceToGround = 0;

	void Start(){
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0F)) {
			distanceToGround = hit.distance;
		}
	}

	// Update is called once per frame
	void Update () {
		//determine direction to move in
		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));

		//if input isnt 0, we have a direction, so face that direction
		if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) {
			transform.rotation = Quaternion.LookRotation (moveDirection);
		}

		//make it go faster
		moveDirection = moveDirection.normalized * speed * Time.deltaTime;

		//do the move
		transform.Translate (moveDirection, Space.World);

		//coming soon (tm)
		if(Input.GetButtonDown("Jump")) {
			Jump();
		}

		while (distanceToGround >= 1) {
			transform.Translate (new Vector3 (0, -1.0f, 0));
		}
	}

	protected void Jump(){
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0F)) {
			distanceToGround = hit.distance;
		}
		Debug.Log (distanceToGround);
		if (distanceToGround <= 1) {
			transform.Translate (new Vector3 (0, jumpForce, 0));
		}

	}
}
