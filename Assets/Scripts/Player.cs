using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int jumpMultiplier = 1;

	private PlayerControl controls;

	private PlayerController controller;

	private CircleCollider2D cc;

	// Use this for initialization
	void Start ()
	{
		//Use controls if assigned in the editor, or create a new one if empty
		controls = gameObject.GetComponent<PlayerControl>();
		if(controls == null){
			controls = gameObject.AddComponent(typeof(PlayerControl)) as PlayerControl;
		}
		
		// set controls to active now that we know they definitively exist
		controls.active = true;

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

		cc = gameObject.GetComponent<CircleCollider2D>() as CircleCollider2D;
		if(cc == null){
			cc = initCircleCollider();
		}
	}

	private Rigidbody2D initRigidBody(){
		Rigidbody2D rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;

		rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		rb.freezeRotation = true;

		return rb;
	}

	private CircleCollider2D initCircleCollider(){
		CircleCollider2D cc = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;

		return cc;
	}

	/**
	 * Check for whether player is jumping, or has fallen 
	 */
	void Update () {
		if(controls.jump()){
			controller.jump();
		}

		if (controls.hasFallen()) {
			World.reloadScene();
		}
	}
}
