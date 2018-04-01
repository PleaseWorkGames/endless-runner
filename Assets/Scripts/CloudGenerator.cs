﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudGenerator : MonoBehaviour {
	
	private const int BLAZE_IT = 420;
	
	/**
	 * Instance of Cloud from which to reproduce/instantiate dynamically at runtime
	 */
	public Cloud cloud;

	public TranslatableValue worldTranslatableValue;

	public float maxGapDistance = 1.5f;

	public float minGapDistance = 0.5f;

	private float cloudYPosition;
	
	void Start ()
	{
		cloudYPosition = cloud.transform.position.y;

		moveInitialCloudOffCamera();
		
		int numberOfCloudsToGenerate = Mathf.RoundToInt(Random.value * 5);

		for (var i = 0; i < numberOfCloudsToGenerate; i += 1) {
			generateAndPlaceCloudInstance();
		}
	}
	
	void Update ()
	{
		bool shouldGenerateNewCloudInstance = Random.Range(0, 1000) == BLAZE_IT;

		if (!shouldGenerateNewCloudInstance) {
			return;
		}
		
		generateAndPlaceCloudInstance(1.1f);
	}

	private void generateAndPlaceCloudInstance(float xPosition = 0.0f)
	{
		bool shouldRandomlyGenerateXPosition = Mathf.Approximately(xPosition, 0.0f);

		if (shouldRandomlyGenerateXPosition) {
			Debug.Log("Randomly generating xPosition");
			xPosition = Random.Range(0f, 1.0f);
		}
		
		Vector3 point = Camera.main.ViewportToWorldPoint(
			new Vector3(xPosition, 0, Camera.main.nearClipPlane)
		);
		
		Cloud newCloud = Instantiate(
			cloud,
			new Vector2(point.x, cloudYPosition),
			transform.rotation,
			GetComponentInParent<Transform>()
		);
	}

	/**
	 * Hide initial cloud from which all instances are generated.  This is to ensure it never gets destroyed during play as it's the master copy
	 */
	private void moveInitialCloudOffCamera()
	{
		cloud.transform.position = new Vector2(0, -100.0f);
	}
}
