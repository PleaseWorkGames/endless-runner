﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChunkGenerator : MonoBehaviour {

	public Floor floor;

	public TranslatableValue worldTranslatableValue;

	public float maxDistance = 1.5f;

	private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () {
		boxCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//TODO: Refactor to use tags
	void OnTriggerExit2D(Collider2D other){
		// create new floor as soon as previous floor instance leaves box collider generator
		if (!other.gameObject.GetComponent<Floor>()) {
			return;
		}

		float distance = Random.value * maxDistance;
		
		//Need to calculate offset so the floor is generated directly after the previous
		EdgeCollider2D ec = floor.GetComponent<EdgeCollider2D>() as EdgeCollider2D;
		float offset = ec.bounds.extents.x - boxCollider.size.x/2 + distance;

		Floor newFloor = Instantiate(
			floor,
			new Vector2(
				other.bounds.max.x + offset,
				other.bounds.max.y
			),
			transform.rotation,
			GetComponentInParent<Transform>()
		);

		newFloor.translatableValue = worldTranslatableValue;
	}
}
