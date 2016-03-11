using UnityEngine;

public class RotateCamera : MonoBehaviour {

	private Transform target;
	private bool axisInUse = false;
	public float dampTime = 0.15f;

	private void Start () {
		if(target == null) {
			target = GameObject.Find ("Player").transform;
		}
	}

	private void LateUpdate() {
		if(target == null) {
			target = GameObject.Find ("Player").transform;
		}
		if (axisInUse == false) {
			if (Input.GetAxisRaw ("RotateCamera") < 0) {
				RotateRelativeToCamera(new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")), Camera.main);
				//transform.RotateAround (target.position, Vector3.up, 90.0f);
				//SmoothLookAt ();
				axisInUse = true;

			} else if (Input.GetAxisRaw ("RotateCamera") > 0) {		
				//transform.RotateAround (target.position, Vector3.up, -90.0f);
				//SmoothLookAt ();
				axisInUse = true;
			}
		}
		if(Input.GetAxisRaw("RotateCamera") == 0 ) {
			axisInUse = false;
		}
	}
	private void RotateRelativeToCamera(Vector3 direction, Camera cam) {
		// rotate given direction by the camera's rotation
		Vector3 camDir = cam.transform.rotation * direction;

		// add result to object's location to get relative direction
		Vector3 objectDir = transform.position + camDir;

		// create quaternion facing direction
		Quaternion targetRotation = Quaternion.LookRotation(objectDir - transform.position);

		// constrain rotation to the Y axis
		Quaternion constrained = Quaternion.Euler(0.0f, targetRotation.eulerAngles.y, 0.0f);

		// slerp rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, constrained, Time.deltaTime * dampTime);
	}


	void SmoothLookAt(){
		Vector3 relTargetPosition = target.position - transform.position;
		Quaternion lookAtRotation = Quaternion.LookRotation (relTargetPosition, Vector3.up);
		transform.rotation = Quaternion.Slerp (transform.rotation, lookAtRotation, dampTime * Time.deltaTime);
	}
}