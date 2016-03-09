﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float dampTime = 0.15f;
	private Transform target;

	private Vector3 velocity = Vector3.zero;
	private Vector3 offset;
	private Camera c;

	// Use this for initialization
	void Start () {
		if(target == null) {
			target = GameObject.Find ("Player").transform;
		}
		if (c == null) {
			c = GetComponent<Camera> ();
		}
		offset = new Vector3 (0.0f, 120.0f, -120.0f);
	}

	// Update is called once per frame
	void Update () {
		if (target) {
			Vector3 point = c.WorldToViewportPoint (target.position);
			Vector3 delta = target.position - c.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime); 
		}
	}
}
