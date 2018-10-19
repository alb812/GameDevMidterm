using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutScript : MonoBehaviour {

	// Use this for initialization
	
     public void ReturnMenu()
       {
	       SceneManager.LoadScene("StartGame");
       }

	void Update()
	{
			if (Application.loadedLevelName == "GameOver")
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		
		if (Application.loadedLevelName == "WinState1")
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
