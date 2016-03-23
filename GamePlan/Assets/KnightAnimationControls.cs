using UnityEngine;
using System.Collections;

public class KnightAnimationControls : MonoBehaviour {

	private Animator ani;
	private float forwardInput;
	private float turnInput;
	private float strafeInput;
	private float jumpInput;
	private float distanceToGround = 0.5f;
	public LayerMask ground;

	private bool fireButtonPressed;
	private Rigidbody rbody;

	bool Grounded(){
		return Physics.Raycast (transform.position, Vector3.down, distanceToGround, ground);
	}
	// Use this for initialization
	void Start () {
		if (GetComponent<Animator> ()) {
			ani = gameObject.GetComponent<Animator> ();
		} else {
			Debug.LogError ("The character needs an Animator Component.");
		}

		if (GetComponent<Rigidbody> ()) {
			rbody = GetComponent<Rigidbody> ();
		} else {
			Debug.LogError ("The character needs a Rigidbody Component.");
		}
		forwardInput = 0.0f;
		turnInput = 0.0f;
		strafeInput = 0.0f;
		jumpInput = 0.0f;
	}

	void GetInput(){
		forwardInput = Input.GetAxisRaw ("Vertical");
		turnInput = Input.GetAxisRaw ("Horizontal");
		strafeInput = Input.GetAxisRaw ("Strafe");
		jumpInput = Input.GetAxisRaw ("Jump");
		fireButtonPressed = Input.GetButtonDown ("Fire1");
	}
	
	// Update is called once per frame
	void Update () {
		GetInput ();

		if (forwardInput != 0) {
			ani.SetFloat (Animator.StringToHash ("Vertical"), forwardInput);
			ani.SetBool (Animator.StringToHash ("Running"), true);
		} else {
			ani.SetFloat (Animator.StringToHash ("Vertical"), forwardInput);
			ani.SetBool(Animator.StringToHash("Running"), false);
		}

		if (jumpInput > 0 && !Grounded ()) {
			ani.SetFloat (Animator.StringToHash ("Jump"), jumpInput);
			ani.SetBool (Animator.StringToHash ("Grounded"), false);
		} else {
			ani.SetFloat (Animator.StringToHash ("Jump"), jumpInput);
			ani.SetBool (Animator.StringToHash ("Grounded"), true);
		}
		if (strafeInput != 0) {
			ani.SetFloat (Animator.StringToHash ("Strafe"), strafeInput);
			ani.SetBool (Animator.StringToHash ("Running"), true);
		} else {
			ani.SetFloat (Animator.StringToHash ("Strafe"), strafeInput);
			ani.SetBool(Animator.StringToHash("Running"), false);
		}

		if (fireButtonPressed) {
			ani.SetBool (Animator.StringToHash ("Attack"), true);
		} else {
			ani.SetBool (Animator.StringToHash ("Attack"), false);
		}
	}
}