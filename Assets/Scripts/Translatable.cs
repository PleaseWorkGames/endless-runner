using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translatable : MonoBehaviour
{
	private Transform transform;
	
	public enum TranslateType {Foreground = 0, Background = 1};
	
	public TranslatableValue translateDistance;
	
	public TranslateType translateType = TranslateType.Foreground;
	
	// Use this for initialization
	void Start ()
	{
		transform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// get translate distance based on the translate type (i.e. foreground, background) assigned to translatable
		float translateDistanceForThisType = translateType == TranslateType.Foreground 
			? translateDistance.foregroundX 
			: translateDistance.backgroundX;
		
		transform.Translate(Time.deltaTime * translateDistanceForThisType, 0, 0);
	}
}
