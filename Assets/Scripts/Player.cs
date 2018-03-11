﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public int jumpMultiplier = 1;

	private PlayerControl controls;

	private PlayerController controller;

	private BoxCollider2D bc;

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

		bc = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
		if(bc == null){
			bc = initBoxCollider();
		}
	}

	private Rigidbody2D initRigidBody(){
		Rigidbody2D rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;

		return rb;
	}

	private BoxCollider2D initBoxCollider(){
		BoxCollider2D bc = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;

		return bc;
	}

	/**
	 * Check for whether player is jumping, or has fallen 
	 */
	void Update () {
		if(controls.jump()){
			controller.jump();
		}

		if (controls.hasFallen() && !controls.hasRecordedFall()) {
			controls.recordFall();
			// reload scene
			StartCoroutine(ReloadSceneAsynchronously()); // asynchronous implementation
//			SceneManager.LoadScene(SceneManager.GetActiveScene().name); // synchronous implementation
		}
	}
	
	IEnumerator ReloadSceneAsynchronously()
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}
}
