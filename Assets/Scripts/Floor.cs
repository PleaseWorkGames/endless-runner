using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

	private BoxCollider2D bc;

	private Rigidbody2D rb;

	private SpriteRenderer spriteRenderer;

	private Translatable translatable;

	public TranslatableValue translatableValue;

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

		spriteRenderer = gameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
		if(spriteRenderer == null){
			spriteRenderer = initSpriteRenderer();
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

		return rb;
	}

	private BoxCollider2D initBoxCollider(){
		BoxCollider2D bc = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;

		return bc;
	}

	private SpriteRenderer initSpriteRenderer(){
		SpriteRenderer spriteRenderer = gameObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;

		spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Floor");

		return spriteRenderer;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
