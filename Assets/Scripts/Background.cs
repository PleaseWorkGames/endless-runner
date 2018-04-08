using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public Sprite backgroundImage;

	public Sprite skyImage;

	public int layerOrder = 1;

	private LinkedList<GameObject> backgroundTiles;

	private GameObject sky;

	private	Vector2 leftBoundary;
	private Vector2 rightBoundary;


	// Use this for initialization
	void Start () {

		leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,.5f,Camera.main.nearClipPlane));
		rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,.5f,Camera.main.nearClipPlane));

		sky = createSky();
		sky.transform.parent = this.transform;

		backgroundTiles = new LinkedList<GameObject>();		

		//Aligns the first tile to the bottom of the screen. Make sure the image pivot point is at the bottom .
		GameObject bg = createTile("bg-tile1", Camera.main.ViewportToWorldPoint(new Vector3(0,0,Camera.main.nearClipPlane)));
		backgroundTiles.AddLast(bg);

		float tileWidth = backgroundImage.texture.width / backgroundImage.pixelsPerUnit;

		//Tile across the camera
		while(true) {

			GameObject previous = backgroundTiles.Last.Value;

			string name = "bg-tile"+(backgroundTiles.Count+1);

			Vector3 spawnPosition = new Vector3(
				previous.transform.position.x + tileWidth,
				previous.transform.position.y,
				previous.transform.position.z
			);

			GameObject current = createTile(name, spawnPosition);
			backgroundTiles.AddLast(current);

			//Stop generating once we are outside the camera view
			if( previous.transform.position.x + tileWidth > rightBoundary.x) {
				break;
			}

		}
	}

	private GameObject createSky(){
		GameObject bg = new GameObject();

		bg.name = "Sky";

		SpriteRenderer sprite = bg.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;

		sprite.sprite = skyImage;

		sprite.sortingOrder = 0;

		float viewPortHeight = Camera.main.orthographicSize * 2;
		float viewPortWidth = viewPortHeight * Screen.width / Screen.height;

		float imageWidth = skyImage.textureRect.width / skyImage.pixelsPerUnit;
		float imageHeight = skyImage.textureRect.height / skyImage.pixelsPerUnit;

		bg.transform.localScale = new Vector2(viewPortWidth / imageWidth, viewPortHeight / imageHeight );

		return bg;
	}

	private GameObject createTile(string name, Vector3 position){
		GameObject bg = new GameObject(name);
		
		BackgroundTile bgTile = bg.AddComponent(typeof(BackgroundTile)) as BackgroundTile;

		bgTile.image = backgroundImage;
		bgTile.transform.position = position;

		bg.transform.parent = this.transform;

		return bg;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float tileWidth = backgroundImage.texture.width / backgroundImage.pixelsPerUnit;

		GameObject first = backgroundTiles.First.Value;

		// If the first tile is out of camera range, move it so it goes afer the last tile
		if ( first.transform.position.x + tileWidth/2 < leftBoundary.x) {
			backgroundTiles.RemoveFirst();

			GameObject last = backgroundTiles.Last.Value;

			first.transform.position = new Vector3(
				last.transform.position.x + tileWidth,
				last.transform.position.y,
				last.transform.position.z
			);

			backgroundTiles.AddLast(first);
		}

		// Update each tile 
		foreach (GameObject bgTile in backgroundTiles) {

			Vector3 newPosition = new Vector3(
				bgTile.transform.position.x - .01f,
				bgTile.transform.position.y,
				bgTile.transform.position.z
			);			

			bgTile.transform.position =	newPosition;
		}	
	}
}
