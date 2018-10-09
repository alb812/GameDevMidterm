using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Usage: 
//Intent: This script is a timer that leads to a GameOver when time runs out
public class TimerScript : MonoBehaviour
{
	//defining basic variables
	
	//defines timer UI
	public Text timerText;
	//defines how many seconds are there
	public int timeLeft = 120;

	// Use this for initialization
	void Start ()
	{
		//using a coroutine so the timer runs until completely up
		StartCoroutine("CountDown");
		
		//setting timer seconds
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//displaying the timer in the UI
		timerText.text = "Time Left = " + timeLeft;
		
		//If timer goes less than 0, stop timer and load game over scene
		if (timeLeft <= 0)
		{
			StopCoroutine("CountDown");
			SceneManager.LoadScene("GameOver");
		}
	}
	
	//Timer goes down each second
	IEnumerator CountDown()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}
}
