using UnityEngine;
using System.Collections;

public class Jumping : MonoBehaviour {

	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController cc;


	// Use this for initialization
	void Start () {
		if (cc == null) {
			cc = GetComponent<CharacterController> ();
		}
	}

	// Update is called once per frame
	void Update () {
		Debug.Log(cc.isGrounded ? "GROUNDED" : "NOT GROUNDED");

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
	protected void Jump(){
		moveDirection.y = jumpSpeed;
	}
}
