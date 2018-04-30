using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[
	RequireComponent(typeof(Canvas)),
	RequireComponent(typeof(GraphicRaycaster))
]
public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject pauseButtonUI;

	public Sprite menuItemSprite;

	private Canvas canvas;

	private GraphicRaycaster raycaster;

	private Component[] menuItems;

	void Start(){
		//Init and disable the menu UI
		canvas = gameObject.GetComponent<Canvas>() as Canvas;
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		canvas.enabled = false;

		menuItems = gameObject.GetComponentsInChildren(typeof(MenuItem));

		foreach(MenuItem item in menuItems){
			AddMenuItem(item);
		}
	}

	/**
	 * Create menu item from a GameObject with a MenuItem script attached
	 */
	private void AddMenuItem(MenuItem item){
		//Set image
		Image image = item.GetComponent<Image>() as Image;
		image.sprite = menuItemSprite;

		Button button = item.GetComponent<Button>() as Button;
		// Create a child object for the text in the menu
		GameObject go = new GameObject("Text");
		go.transform.parent = item.transform;
		go.transform.position = button.transform.position;

		Text buttonText = go.AddComponent(typeof(Text)) as Text;

		go.GetComponent<RectTransform>().sizeDelta = item.GetComponent<RectTransform>().sizeDelta;

		buttonText.alignment = TextAnchor.MiddleCenter;
		buttonText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

		buttonText.text = item.name;
	}

	// Update is called once per frame
	void Update () {
		if ( Time.timeScale != 0 ) {
			canvas.enabled = false;
		}
		else {
			canvas.enabled = true;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if( Time.timeScale != 0 )
			{
				Pause();
			}
			else{
				Resume();
			}
		}	
	}

	public void pauseButton(){
		if ( Time.timeScale == 0 ) {
			Resume();
		} else {
			Pause();
		}
	} 

	public void Resume(){
		Time.timeScale = 1f;
	}

	public void Pause(){
		Time.timeScale = 0f;
	}
		
	public void Quit(){
		Application.Quit ();
	}
}
