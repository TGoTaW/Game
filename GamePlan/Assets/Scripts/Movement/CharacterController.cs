using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	[System.Serializable]
	public class MoveSettings
	{
		public float forwardVelocity = 12.0f;
		public float rotateVelocity = 100.0f;
		public float strafeVelocity = 8.0f;
		public float jumpVelocity = 25;
		public float distanceToGround = 0.5f;
		public LayerMask ground;
	}

	[System.Serializable]
	public class PhysicsSettings{
		public float downwardAccel = 0.75f;
	}

	[System.Serializable]
	public class InputSettings{
		public float inputDelay = 0.1f;
		public string FORWARD_AXIS = "Vertical";
		public string TURN_AXIS = "Horizontal";
		public string JUMP_AXIS = "Jump";
		public string STRAFE_AXIS = "Strafe";
	}

	public MoveSettings moveSetting = new MoveSettings ();
	public PhysicsSettings physSettings = new PhysicsSettings();
	public InputSettings inputSettings = new InputSettings();



	public float forwardInput;
	public float turnInput;
	public float strafeInput;
	public float jumpInput;

	private Vector3 velocity = Vector3.zero;
	private Quaternion targetRotation;
	private Rigidbody rbody;

	public Quaternion TargetRotation{ get{ return targetRotation; } }

	bool Grounded(){
		return Physics.Raycast (transform.position, Vector3.down, moveSetting.distanceToGround, moveSetting.ground);
	}



	void Start(){
		targetRotation = transform.rotation;
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
		forwardInput = Input.GetAxisRaw (inputSettings.FORWARD_AXIS);
		turnInput = Input.GetAxisRaw (inputSettings.TURN_AXIS);
		jumpInput = Input.GetAxisRaw (inputSettings.JUMP_AXIS);
		strafeInput = Input.GetAxisRaw (inputSettings.STRAFE_AXIS);
	}

	void Update(){
		GetInput ();
		Turn ();
	}

	void FixedUpdate(){
		Run ();
		Jump ();

		rbody.velocity = transform.TransformDirection (velocity);
	}

	void Run(){
		if (Mathf.Abs(forwardInput) > inputSettings.inputDelay) {
			velocity.z = moveSetting.forwardVelocity * forwardInput;
		} else {
			velocity.z = 0;
		}
		if (Mathf.Abs(strafeInput) > inputSettings.inputDelay) {
			velocity.x = strafeInput * moveSetting.strafeVelocity;
		} else {
			velocity.x = 0;
		}

	}

	void Turn(){
		if (Mathf.Abs (turnInput) >inputSettings. inputDelay) {
			targetRotation *= Quaternion.AngleAxis (moveSetting.rotateVelocity * turnInput * Time.deltaTime, Vector3.up);
		}
		transform.rotation = targetRotation;
	}

	void Jump(){
		if (jumpInput > 0 && Grounded ()) {
			//jump
			velocity.y = moveSetting.jumpVelocity;
		} else if (jumpInput == 0 && Grounded ()) {
			//zero out velocity
			velocity.y = 0;
		} else {
			//decrease velocity.y
			velocity.y -= physSettings.downwardAccel;
		}
	}
}
