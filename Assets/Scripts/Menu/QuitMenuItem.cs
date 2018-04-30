using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMenuItem : MenuItem {

	public override void ClickAction(){
		Debug.Log("Quitting application");
		Application.Quit();
	}

}
