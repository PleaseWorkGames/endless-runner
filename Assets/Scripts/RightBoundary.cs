using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBoundary : MonoBehaviour {

	public Camera camera;
	private EdgeCollider2D edgeCollider2D;
	// Use this for initialization
	void Start () {
		edgeCollider2D = this.GetComponent<EdgeCollider2D>() as EdgeCollider2D;

		if(edgeCollider2D == null) {
			edgeCollider2D = initEdgeCollider();
		}
	}

	private EdgeCollider2D initEdgeCollider() {
		EdgeCollider2D result = gameObject.AddComponent(typeof(EdgeCollider2D)) as EdgeCollider2D;

		List<Vector2> points = new List<Vector2>();

		//Align the collider with the right camera border
		Vector2 topRight = camera.ViewportToWorldPoint(new Vector3(1,1,camera.nearClipPlane));
		Vector2 bottomRight = camera.ViewportToWorldPoint(new Vector3(1,-1,camera.nearClipPlane));

		points.Add(topRight);
		points.Add(bottomRight);

		result.points = points.ToArray();


		return result;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
