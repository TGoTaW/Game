using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.0f;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 lookDirection = Vector3.zero;
	Animator animator;
	private int rotationSpeed = 2;

	void Start(){
		animator = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {


		/*if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * speed);
		}

		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * speed);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * speed);
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.back * speed);
		}*/

		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
		if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) {
			transform.rotation = Quaternion.LookRotation (moveDirection);
		}

		moveDirection *= speed * Time.deltaTime;
		transform.Translate (moveDirection, Space.World);


		


		if (Input.GetKey (KeyCode.B)) {
			

		}
			




	}
}
