using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 10.0f;

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

		if (Input.GetAxisRaw("Horizontal") > 0 ) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		} else if (Input.GetAxisRaw("Horizontal") < 0 ) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}

		if (Input.GetAxisRaw("Vertical") > 0 ) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		} else if (Input.GetAxisRaw("Vertical") < 0 ) {
			transform.Translate (Vector3.back * speed * Time.deltaTime);
		}
	}
}
