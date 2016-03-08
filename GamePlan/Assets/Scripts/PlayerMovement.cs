using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.0f;
	private Vector3 moveDirection = Vector3.zero;
	Animator animator;

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

		moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= speed;
		transform.Translate (moveDirection);

		if (Input.GetKey (KeyCode.B)) {
			

		}
			




	}
}
