using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour
{
	private static World instance;
	
	private static bool isInProcessOfReloadingAlready;

	public void Start()
	{
		instance = this;
		isInProcessOfReloadingAlready = false;
	}

	public static void reloadScene()
	{
		if (isInProcessOfReloadingAlready) {
			return;
		}
		
		isInProcessOfReloadingAlready = true;
		
		instance.StartCoroutine("ReloadSceneAsynchronously");
	}
	
	IEnumerator ReloadSceneAsynchronously()
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}
}
