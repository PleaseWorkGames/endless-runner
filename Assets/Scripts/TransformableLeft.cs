using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TransformableLeft : MonoBehaviour
{
	private Transform transform;
	
	public float transformXDistance = -1.0f;
	
	// Use this for initialization
	void Start ()
	{
		transform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(Time.deltaTime * transformXDistance, 0, 0);
	}
}
