﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Translatable : MonoBehaviour
{
	private Transform transform;
	
	public TranslatableValue translateDistance;
	
	public enum translatableType {Foreground, Background}
	
	// Use this for initialization
	void Start ()
	{
		transform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(Time.deltaTime * translateDistance.foregroundX, 0, 0);
	}
}
