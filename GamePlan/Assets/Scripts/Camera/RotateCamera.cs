using UnityEngine;

public class RotateCamera : MonoBehaviour {

	private Transform target;
	private bool axisInUse = false;

	private void Start () {
		if(target == null) {
			target = GameObject.Find ("Player").transform;
		}
	}

	private void LateUpdate() {		
		if (axisInUse == false) {
			if (Input.GetAxisRaw ("RotateCamera") < 0) {			
				transform.RotateAround (target.position, Vector3.up, 90.0f);
				axisInUse = true;

			} else if (Input.GetAxisRaw ("RotateCamera") > 0) {			
				transform.RotateAround (target.position, Vector3.up, -90.0f);
				axisInUse = true;
			}
		}
		if(Input.GetAxisRaw("RotateCamera") == 0 ) {
			axisInUse = false;
		}
	}
}
