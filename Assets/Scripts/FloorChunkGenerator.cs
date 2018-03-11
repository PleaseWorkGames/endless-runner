using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChunkGenerator : MonoBehaviour {

	public Floor floor;

	public TranslatableValue translatableValue;

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
		if(other.gameObject.GetComponent<Floor>() != null){
			Floor newFloor = Instantiate(
				floor,
				new Vector2(0,0),
				transform.rotation, 
				GetComponentInParent<Transform>()
			);

			float distance = Random.value * maxDistance;

			//Need to create an offset since it's created in the middle of the parent object
			EdgeCollider2D ec = newFloor.GetComponent<EdgeCollider2D>() as EdgeCollider2D;
			float offset = Vector2.Distance(ec.points[0], ec.points[ec.points.Length -1]) /2;

			newFloor.transform.localPosition = new Vector2(
				offset - boxCollider.size.x + distance, 
				floor.transform.localPosition.y
			);

			newFloor.translatableValue = translatableValue;
		}
	}
}
