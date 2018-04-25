using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
		if(canvas == null){
			canvas = InitCanvas();
		}
		canvas.enabled = false;

		//Init raycaster
		raycaster = gameObject.GetComponent<GraphicRaycaster>() as GraphicRaycaster;
		if( raycaster == null ){
			raycaster = InitRaycaster();
		}

		menuItems = gameObject.GetComponentsInChildren(typeof(MenuItem));

		foreach(MenuItem item in menuItems){
			AddMenuItem(item);
		}
	}

	private Canvas InitCanvas(){
		Canvas result = gameObject.AddComponent(typeof(Canvas)) as Canvas;

		result.renderMode = RenderMode.ScreenSpaceOverlay;

		return result;
	}

	private GraphicRaycaster InitRaycaster() {
		GraphicRaycaster result = gameObject.AddComponent(typeof(GraphicRaycaster)) as GraphicRaycaster;

		return result;
	}

	/**
	 * Create menu item from a GameObject with a MenuItem script attached
	 */
	private void AddMenuItem(MenuItem item){

		// Decorate the GameObject associated with the MenuItem script
		item.gameObject.AddComponent(typeof(CanvasRenderer));

		Image image = item.gameObject.AddComponent(typeof(Image)) as Image;
		image.type = Image.Type.Sliced;
		image.sprite = menuItemSprite;

		Button button = item.gameObject.AddComponent(typeof(Button)) as Button;

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
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if( !gameIsPaused )
			{
				Pause();
				canvas.enabled = true;
			}
			else{
				Resume();
				canvas.enabled = false;
			}
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
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	public void Pause(){
		Time.timeScale = 0f;
		gameIsPaused = true;
	}
		
	public void Quit(){
		Application.Quit ();
	}
}
