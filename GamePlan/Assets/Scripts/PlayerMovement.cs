using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.0f;
	private Vector3 moveDirection = Vector3.zero;

	void Start(){

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
	}

	protected void Jump(){

	}
}
