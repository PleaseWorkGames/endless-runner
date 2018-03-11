using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	private bool _recordedFall = false;
	
	public bool active = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Returns true when the space is pressed
	public bool jump(){
		return active && Input.GetKeyDown(KeyCode.UpArrow);
	}

	public bool hasFallen()
	{
		return active && gameObject.transform.position.y < -7;
	}

	public void recordFall()
	{
		_recordedFall = true;
	}
	
	public bool hasRecordedFall()
	{
		return _recordedFall;
	}
}
