using UnityEngine;
using System.Collections;

public class KnightAnimationControls : MonoBehaviour {

	private Animator ani;
	// Use this for initialization
	void Start () {
		ani = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) {
			ani.SetBool (Animator.StringToHash ("Running"), true);

		} else {
			ani.SetBool (Animator.StringToHash ("Running"), false);
		}

		if (Input.GetButtonDown("Fire1")) {
			ani.SetBool (Animator.StringToHash ("Attack"), true);

		} else {
			ani.SetBool (Animator.StringToHash ("Attack"), false);
		}
	}
}
