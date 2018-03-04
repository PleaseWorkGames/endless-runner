using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public bool active = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Returns true when the space is pressed
	public bool jump(){
		return active && Input.GetKeyDown(KeyCode.UpArrow);
	}
}
