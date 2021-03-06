using UnityEngine;
using System.Collections;

public class SkeletonEnemyScript : MonoBehaviour {
	private int health;
	private Renderer rend;
	private bool justCollided;
	private Transform playerTransform;
	private int speed = 5;
	private float chaseRange = 45f;
	private float range;
	private float stopRange = 5f;
	private float attackRange = 5f;
	private Animator ani;
	private bool attack;

	// Use this for initialization
	void Start () {
		
		health = 200;
		rend = gameObject.GetComponent<Renderer> ();
		justCollided = false;
		playerTransform = GameObject.Find ("Player").transform;
		ani = gameObject.GetComponent<Animator> () ;
		attack = false;

	}
	
	// Update is called once per frame
	void Update () {

		range = Vector3.Distance (transform.position, playerTransform.position);
		if (range <= attackRange && health > 0) {
			//TODO
			ani.SetBool (Animator.StringToHash ("attack"), true);

			attack = true;
		} else {
			ani.SetBool (Animator.StringToHash ("attack"), false);
			attack = false;
		}
		if (range <= chaseRange && range > stopRange && attack == false && health > 0) {
			
			ani.SetBool(Animator.StringToHash("runBool"), true);
			transform.LookAt (playerTransform);
			transform.Translate (speed * Vector3.forward * Time.deltaTime);
			transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		} else {
			ani.SetBool (Animator.StringToHash ("runBool"), false);
		}

	}

	void OnCollisionEnter (Collision col){
		ani.SetBool (Animator.StringToHash ("hit"), true);
		ani.SetBool (Animator.StringToHash ("runBool"), false);
		ani.SetBool (Animator.StringToHash ("attack"), false);

		if (col.gameObject.tag == "Weapon" && justCollided == false && health > 0) {
			health -= 40;
			justCollided = true;
			//

			if (health <= 0) {

				ani.SetBool (Animator.StringToHash ("dead"), true);
				ani.SetBool (Animator.StringToHash ("runBool"), false);
				ani.SetBool (Animator.StringToHash ("attack"), false);
				//StartCoroutine (DeathAnimation ());
				//Destroy (gameObject);
			}

		} else {
			justCollided = false;
		}


	}


	IEnumerator DeathAnimation(){
		
		yield return new WaitForSeconds (3f);
		Destroy (gameObject);
	}
	

}
