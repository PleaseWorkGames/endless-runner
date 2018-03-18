using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour {

	public Cloud cloud;

	public TranslatableValue worldTranslatableValue;

	public float maxGapDistance = 1.5f;

	public float minGapDistance = 0.5f;

	private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () {
		boxCollider = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//TODO: Refactor to use tags
	void OnTriggerExit2D(Collider2D other){
		// create new floor as soon as previous floor instance leaves box collider generator
//		if (!other.gameObject.GetComponent<Floor>()) {
//			return;
//		}
//
//		float distance = Random.Range(minGapDistance, maxGapDistance);
//		
//		Floor newFloor = Instantiate(
//			floor,
//			new Vector2(0,0),
//			transform.rotation,
//			GetComponentInParent<Transform>()
//		);
//		//Need to calculate offset so the floor is generated directly after the previous
//		EdgeCollider2D ec = newFloor.GetComponent<EdgeCollider2D>() as EdgeCollider2D;
//		float offset = ec.bounds.extents.x - boxCollider.size.x/2 + distance;
//
//		newFloor.transform.position = new Vector2(
//			other.bounds.max.x + offset,
//			other.bounds.max.y
//		);
//
//
//		newFloor.translatableValue = worldTranslatableValue;
	}
}
