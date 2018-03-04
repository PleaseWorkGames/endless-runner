using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int jumpMultiplier = 1;

	private PlayerControl controls;

	private PlayerController controller;

	private BoxCollider2D collider;

	// Use this for initialization
	void Start () {

		//Use controls if assigned in the editor, or create a new one if empty
		controls = gameObject.GetComponent<PlayerControl>();
		if(controls == null){
			controls = gameObject.AddComponent(typeof(PlayerControl)) as PlayerControl;
			controls.active = true;
		}

		//Use controller if assigned in the editor, or create a new one if empty
		controller = gameObject.GetComponent<PlayerController>();
		if(controller == null){
			controller = gameObject.AddComponent(typeof(PlayerController)) as PlayerController;
			controller.jumpMultiplier = jumpMultiplier;
		}

		//Create a new rigidbody component if it doesn't exist
		if(gameObject.GetComponent<Rigidbody2D>() == null){
			initRigidBody();			
		}

		collider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
	}

	Rigidbody2D initRigidBody(){
		Rigidbody2D rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;

		return rb;
	}
	
	// Update is called once per frame
	void Update () {

		if(controls.jump()){
			Debug.Log("Jump Button Pressed!");
			controller.jump();
		}
		
	}

	
}
