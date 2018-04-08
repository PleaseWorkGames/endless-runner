using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChunkGenerator : MonoBehaviour {

	public Floor[] floors;

	public TranslatableValue worldTranslatableValue;

	public float maxGapDistance = 1.5f;

	public float minGapDistance = 0.5f;

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

		float distance = Random.Range(minGapDistance, maxGapDistance);

		int randomIndex = Mathf.RoundToInt(Random.value*(floors.Length-1));

		Floor floor = floors[randomIndex];
		
		Floor newFloor = Instantiate(
			floor,
			new Vector2(0,0),
			transform.rotation,
			GetComponentInParent<Transform>()
		);
		//Need to calculate offset so the floor is generated directly after the previous
		Collider2D ec = newFloor.GetComponent<Collider2D>() as Collider2D;

		float offset = ec.bounds.extents.x - boxCollider.size.x/2*0 + distance;

		newFloor.transform.position = new Vector2(
				other.bounds.max.x + offset,
				this.transform.position.y
		);


		newFloor.translatableValue = worldTranslatableValue;
	}
}
