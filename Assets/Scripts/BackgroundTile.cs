using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour {

	public Sprite image;
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {

		spriteRenderer = gameObject.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;

		spriteRenderer.sprite = image;
	}

	public float getTileWidth() {
		return image.texture.width / image.pixelsPerUnit;
	}
}
