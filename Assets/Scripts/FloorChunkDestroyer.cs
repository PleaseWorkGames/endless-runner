using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChunkDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//TODO: Refactor to use tags
	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.GetComponent<Floor>() !=null){
			Destroy(other.gameObject); 
		}
	}
}
