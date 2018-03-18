using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	 * Destroy anything that touches this box collider
	 */
	void OnTriggerExit2D(Collider2D other) {
		Destroy(other.gameObject);
	}
}
