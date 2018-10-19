using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	 public void ReturnMenu()
          {
            SceneManager.LoadScene("StartGame");
          }
}
