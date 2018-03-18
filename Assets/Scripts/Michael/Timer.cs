using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private static float time = 0.0f;
	
	public Text timeText;

	public int precision = 2;

	void Update () {
		time += Time.deltaTime;

		float precisionModifier = Mathf.Pow(10, precision);
		
		timeText.text = "Time: " + Mathf.Round(time * precisionModifier) / precisionModifier;
	}
}
