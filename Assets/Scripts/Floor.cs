using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	private BoxCollider2D bc;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		//Create a new rigidbody component if it doesn't exist
		rb =gameObject.GetComponent<Rigidbody2D>();
		if(rb == null){
			rb = initRigidBody();			
		}

		bc = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
		if(bc == null){
			bc = initBoxCollider();
		}
		
	}
		private Rigidbody2D initRigidBody(){
		Rigidbody2D rb = gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;

		rb.bodyType = RigidbodyType2D.Static;

		return rb;
	}

	private BoxCollider2D initBoxCollider(){
		BoxCollider2D bc = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;

		return bc;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
