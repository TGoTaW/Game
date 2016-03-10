using UnityEngine;
using System.Collections;

public class Jumping : MonoBehaviour {

	private bool isGrounded;
	public float jumpHeight = 10.0f;
	float distanceToGround = 0;
	RaycastHit hit;
	private CharacterController cc;

	// Use this for initialization
	void Start () {
		if (cc == null) {
			cc = GetComponent<CharacterController> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Distance To Ground: " + distanceToGround);
		Debug.Log ("Is Grounded: " +  isGrounded);

		if (Physics.Raycast (transform.position, Vector3.down, out hit, 100.0F)) {
			distanceToGround = hit.distance;
		
			if (distanceToGround <= 2) {
				isGrounded = true;
			}
		}

		//coming soon (tm)
		if(Input.GetButtonDown("Jump") && isGrounded) {
			Jump();
		}
	}

	protected void Jump (){
		
		isGrounded = false;
	}
}
