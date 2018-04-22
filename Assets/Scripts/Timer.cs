using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : TextAbstract {

	private float time = 0.0f;
	
	public int precision = 2;

	void FixedUpdate () {
		time += Time.deltaTime;

		float precisionModifier = Mathf.Pow(10, precision);
		
		text.text = "Time: " + Mathf.Round(time * precisionModifier) / precisionModifier;
	}
}
