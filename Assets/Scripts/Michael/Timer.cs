using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timeText;
	public static float time = 0.0f;

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		timeText.text = "Time: " + (Mathf.RoundToInt(time)).ToString("0");
	}
}
