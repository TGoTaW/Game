using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.position + new Vector3 (0.0f, 15.0f, 0.0f);
	}
}
