using UnityEngine;
using System.Collections;

public class KnightController : MonoBehaviour {

	public Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;


	// Use this for initialization
	void Start () {
		controller = gameObject.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (controller.isGrounded) {
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			}
		if (moveDirection.y > -500) {
			moveDirection.y -= gravity * Time.deltaTime;
		}
		if(moveDirection.y > -100)
			controller.Move(moveDirection * Time.deltaTime);
	
	}
}
