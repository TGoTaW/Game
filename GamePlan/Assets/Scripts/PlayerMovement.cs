using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.0f;
	private Vector3 moveDirection = Vector3.zero;

	void Start(){

	}

	// Update is called once per frame
	void Update () {
		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
		if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) {
			transform.rotation = Quaternion.LookRotation (moveDirection);
		}

		moveDirection *= speed * Time.deltaTime;
		transform.Translate (moveDirection, Space.World);

		if(Input.GetButtonDown("Jump")) {
			Jump();
		}
	}

	private void Jump(){

	}
}
