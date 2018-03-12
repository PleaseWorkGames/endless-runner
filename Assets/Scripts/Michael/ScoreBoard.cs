using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

	public Text scoreText;
	public Transform player;
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + (Mathf.RoundToInt(player.position.x) + 7).ToString("0");
	}
}
