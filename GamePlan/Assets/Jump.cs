using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 position;
	private Rigidbody rig;
	// Use this for initialization
	void Start () {
		rig = gameObject.GetComponent<Rigidbody> ();
	}
	

	void FixedUpdate () {
		
		if (Input.GetButtonDown ("Jump") ) {
			
		}
	}
}
