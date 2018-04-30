using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeMenuItem : MenuItem {

	public override void ClickAction(){
		Debug.Log("Resuming game");
		Time.timeScale = 1f;
	}	
}
