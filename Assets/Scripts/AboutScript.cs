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
}
