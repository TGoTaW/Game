using UnityEngine;
using System.Collections;

public class CameraController_2 : MonoBehaviour {

	public float dampTime = 0.15f;
	private Transform target;

	private Vector3 relCameraPos;
	private float relCameraPosMag;
	private Vector3 newPos;

	void Awake(){
		if(target == null) {
			target = GameObject.Find ("Player").transform;
		}
		relCameraPos = transform.position - target.position;
		relCameraPosMag = relCameraPos.magnitude - 0.5f;
	}

	void FixedUpdate(){

		Vector3 standardPos = target.position + relCameraPos;
		Vector3 abovePos = target.position + Vector3.up * relCameraPosMag;
		Vector3[] checkpoints = new Vector3[5];
		checkpoints [0] = standardPos;
		checkpoints [1] = Vector3.Lerp (standardPos, abovePos, 0.25f);
		checkpoints [2] = Vector3.Lerp (standardPos, abovePos, 0.5f);
		checkpoints [3] = Vector3.Lerp (standardPos, abovePos, 0.75f);
		checkpoints [4] = abovePos;


		for (int i = 0; i < checkpoints.Length; i++) {
			if(ViewingPosCheck(checkpoints[i])){
				break;
			}
		}

		transform.position = Vector3.Lerp (transform.position, newPos, dampTime * Time.deltaTime);
		SmoothLookAt ();
	}


	bool ViewingPosCheck(Vector3 checkPos){
		RaycastHit hit;

		if (Physics.Raycast(checkPos, target.position - checkPos, out hit, relCameraPosMag)){
			if(hit.transform != target){
				return false;
			}
		}
		newPos = checkPos;
		return true;
	}

	void SmoothLookAt(){
		Vector3 relPlayerPosition = target.position - transform.position;
		Quaternion lookAtRotation = Quaternion.LookRotation (relPlayerPosition, Vector3.up);
		transform.rotation = Quaternion.Lerp (transform.rotation, lookAtRotation, dampTime * Time.deltaTime);
	}
}
