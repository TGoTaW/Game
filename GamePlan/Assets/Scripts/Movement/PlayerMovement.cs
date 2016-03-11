using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Vector3 moveDirection = Vector3.zero;
	public float speed = 1.0f;

	void Start(){
		
	}

	// Update is called once per frame
	void Update () {
		//determine direction to move in
		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
		//face it
		if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) {
			transform.rotation = Quaternion.LookRotation (moveDirection);
		}
		//move faster & evenly in all directions
		moveDirection = moveDirection.normalized * speed * Time.deltaTime;
		//do the move
		transform.Translate (moveDirection,  Space.World);
	}


}
