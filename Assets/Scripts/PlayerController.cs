using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb;

	public float jumpMultiplier = 100;

	private bool jumping = false;

	private Vector2 initPosition;
	
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();

		initPosition = gameObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rubberBand();
	}

	public void jump() {

		if(!jumping){
			rb.AddForce(new Vector2(.1f*jumpMultiplier,1*jumpMultiplier));
			jumping = true;
		}
	}

	// Gradually snap the player back to it's starting position if fallen behind
	public void rubberBand() {
		if(gameObject.transform.localPosition.x < initPosition.x){
			rb.AddForce(new Vector2(1.25f,0));
		}
	}

	//Can probably refactor this to use tags
	private void OnCollisionEnter2D(Collision2D collision){

		Floor floor = collision.gameObject.GetComponent<Floor>();

		if(floor != null){
			jumping = false;
		}

	}

	private void OnCollisionExit2D(Collision2D collision){

	}
}
