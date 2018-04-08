using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float time = 0.0f;
	
	public int precision = 2;

	private Text text;

	void Start() {

		text = gameObject.GetComponent<Text>() as Text;

		if ( text == null ) {
			text = initText();
		}

	}

	private Text initText() {
		Text result = gameObject.AddComponent(typeof(Text)) as Text;

		result.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

		return result;
	}

	void Update () {
		time += Time.deltaTime;

		float precisionModifier = Mathf.Pow(10, precision);
		
		text.text = "Time: " + Mathf.Round(time * precisionModifier) / precisionModifier;
	}
}
