using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChunkGenerator : MonoBehaviour {

	public Floor floor;

	public TranslatableValue translatableValue;

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
		if(other.gameObject.GetComponent<Floor>() !=null){
			Floor newFloor = Instantiate(floor, new Vector2(0,0), transform.rotation,  GetComponentInParent<Transform>());

			//I have no idea how I came up with this formula other than trial and error
			newFloor.transform.localPosition = new Vector2(floor.transform.localScale.x/2 - boxCollider.size.x/2,floor.transform.localPosition.y);

			newFloor.translatableValue = translatableValue;
		} 
	}
}
