using UnityEngine;
using System.Collections;

public class BasicEnemyScript : MonoBehaviour {
	private int health;
	private Renderer rend;
	// Use this for initialization
	void Start () {
		
		health = 200;
		rend = gameObject.GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col){
		
		if (col.gameObject.tag == "Weapon") {
			health -= 40;
			StartCoroutine (BlinkAnimation());
			if (health <= 0) {

				Destroy (gameObject);
			}
		}

	}

	IEnumerator BlinkAnimation(){
		rend.material.color = Color.red;
		yield return new WaitForSeconds (.1f);
		rend.material.color = Color.green;
	}
	

}
