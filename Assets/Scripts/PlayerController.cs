using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb;

	public float jumpMultiplier = 100;

	private bool jumping = false;
	
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void jump() {

		if(!jumping){
			rb.AddForce(new Vector2(0,1*jumpMultiplier));
			jumping = true;
		}
	}

	//Can probably refactor this to use tags
	private void OnCollisionStay2D(Collision2D collision){

		Floor floor = collision.gameObject.GetComponent<Floor>();

		if(floor != null){
			jumping = false;
		}

	}
}
