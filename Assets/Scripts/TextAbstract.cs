using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAbstract : MonoBehaviour {

	protected Text text;

	protected void Start() {
		text = gameObject.GetComponent<Text>() as Text;

		if ( text == null ) {
			text = initText();
		}
	}

	protected Text initText() {
		Text result = gameObject.AddComponent(typeof(Text)) as Text;

		result.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

		return result;
	}
}
