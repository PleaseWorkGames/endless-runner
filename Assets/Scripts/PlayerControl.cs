using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public bool active = false;

	// Returns true when the space is pressed
	public bool jump(){
		return active && Input.GetKeyDown(KeyCode.UpArrow);
	}

	/**
	 * Has the player fallen below the game's viewport?
	 */
	public bool hasFallen()
	{
		return active && gameObject.transform.position.y < -7;
	}
}
