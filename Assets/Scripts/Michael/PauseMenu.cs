﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject pauseButtonUI;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			pauseButton();
		}	
	}

	public void pauseButton(){
		if (gameIsPaused) {
			Resume();
		} else {
			Pause();
		}
	} 

	public void Resume(){
		pauseMenuUI.SetActive(false);
		pauseButtonUI.SetActive(true);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	public void Pause(){
		pauseMenuUI.SetActive(true);
		pauseButtonUI.SetActive(false);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}
		
	public void Quit(){
		Application.Quit ();
	}
}
