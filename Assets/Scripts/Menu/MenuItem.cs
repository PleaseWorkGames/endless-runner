using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * The base class for menu items
 */

[
	RequireComponent(typeof(CanvasRenderer)),
	RequireComponent(typeof(Button)),
	RequireComponent(typeof(Image))
]
public class MenuItem : MonoBehaviour {

	void Start() {
		initButton();
	}

	protected void initButton(){
		Button button = GetComponent<Button>() as Button;
		button.onClick.AddListener(ClickAction);
	}

	public virtual void ClickAction(){
		Debug.Log("Hello World!");
	}
}
