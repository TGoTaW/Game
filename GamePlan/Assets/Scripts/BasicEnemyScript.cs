using UnityEngine;
using System.Collections;

public class BasicEnemyScript : MonoBehaviour {
	private float health;
	// Use this for initialization
	void Start () {
		
		health = 120;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col){
		
		if (col.gameObject.tag == "Weapon") {
			Destroy (gameObject);
		}

	}

}
