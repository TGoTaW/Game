using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {

	void Update(){
		if (Input.GetKey (KeyCode.B)) {
			GetComponent<Animator> ().SetTrigger ("Button Press");
		}
		
	}

}
