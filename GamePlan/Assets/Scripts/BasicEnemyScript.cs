using UnityEngine;
using System.Collections;

public class BasicEnemyScript : MonoBehaviour {
	private int health;
	private Renderer rend;
	private bool justCollided;
	private Transform playerTransform;
	private int speed = 5;
	private float chaseRange = 15;
	private float range;
	private float stopRange = 2.5f;

	// Use this for initialization
	void Start () {
		
		health = 200;
		rend = gameObject.GetComponent<Renderer> ();
		justCollided = false;
		playerTransform = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

		range = Vector3.Distance (transform.position, playerTransform.position);
		if (range <= stopRange) {
			//TODO
		}
		else if (range <= chaseRange) {
			transform.LookAt (playerTransform);
			transform.Translate (speed * Vector3.forward * Time.deltaTime);
		}

	}

	void OnCollisionEnter (Collision col){
		
		if (col.gameObject.tag == "Weapon" && justCollided == false) {
			health -= 40;
			justCollided = true;
			StartCoroutine (BlinkAnimation ());
			if (health <= 0) {

				Destroy (gameObject);
			}

		} else {
			justCollided = false;
		}


	}


	IEnumerator BlinkAnimation(){
		rend.material.color = Color.red;
		yield return new WaitForSeconds (.1f);
		rend.material.color = Color.green;
	}
	

}
