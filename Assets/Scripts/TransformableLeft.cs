using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformableLeft : MonoBehaviour
{
	private Transform transform;
	
	// Use this for initialization
	void Start ()
	{
		transform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 leftPositionDecrement = new Vector3(-1.0f, 0, 0);

		transform.position += leftPositionDecrement;
		
//		Debug.Log("The Transform position x is: " + transform.position.x);
	}
}
