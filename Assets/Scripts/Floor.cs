using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	private Rigidbody2D rb;

	private Translatable translatable;

	public TranslatableValue translatableValue;

	// Use this for initialization
	void Start () {
		//Create a new rigidbody component if it doesn't exist
		rb = gameObject.GetComponent<Rigidbody2D>();
		if(rb == null){
			rb = initRigidBody();			
		}

		translatable = gameObject.GetComponent<Translatable>() as Translatable;
		if(translatable == null){
			translatable = gameObject.AddComponent(typeof(Translatable)) as Translatable;
			translatable.translateDistance = translatableValue;
		}
	}

	private Rigidbody2D initRigidBody(){
		Rigidbody2D rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;

		rb.bodyType = RigidbodyType2D.Kinematic;

		rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

		return rb;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
