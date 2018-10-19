using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstPersonScript : MonoBehaviour
{

    //for better mouse look
	private float verticalLook;
	public float lookSpeed = 100f;

	public float moveSpeed = 0.5f;

	//for text UI
	public Text countText;
	private int count;

	//this variable will remember input and pass it to physics
	Vector3 inputVector;
	
	//Audio
	AudioSource PickUpSfx;

	void Start()
	{
		count = 0;
		SetCountText();
		
		//audio
		PickUpSfx = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		//MOUSE LOOK
		//getting mouse input
		//these are mouse "deltas" ... delta = difference
		//these will be 0 what nothing is moving, this isn't mouse position
		//it is how fast you are moving your mouse
		float mouseX = Input.GetAxis("Mouse X"); //horizontal mouse movement
		float mouseY = Input.GetAxis("Mouse Y");

		//rotations: Pitch Yaw Roll
		//Pitch = up/down rotation, x-axis
		//Yaw = left/right rotation, y-axis
		//Roll = rolling motion, z-axis

		//rotate the camera based on mouse input 
		//first rotate the body based on horizontal mouse movement
		transform.Rotate(0f, mouseX, 0f); //Yaw
		//Camera.main.transform.Rotate(-mouseY, 0f, 0f); //add negative to fix inverse

		//WASD Movement
		//GetAxis usually returns a float between -1f and 1f
		//when you're not pressing anything, it returns ~0f
		float horizontal = Input.GetAxis("Horizontal"); //A/D Movement
		float vertical = Input.GetAxis("Vertical"); //W/S Movement

		//better mouse look
		verticalLook += -mouseY;
		verticalLook = Mathf.Clamp(verticalLook, -80f, 80f);
		
		Camera.main.transform.transform.localEulerAngles = new Vector3(verticalLook, 0f, 0f);
		
		//the BETTER way...
		inputVector = transform.forward * vertical;
		inputVector += transform.right * horizontal; //this line is += so it doesnt override the one before it
		
		//hide mouse cursor
		/*if (Input.GetMouseButtonDown(0))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}*/
		
	}

	//it runs every physic frame (a different framerate than input or rendering)
	void FixedUpdate()
	{
		//override object's velocity with desired inputVector direction
		GetComponent<Rigidbody>().velocity = inputVector * moveSpeed; // + Physics.gravity * 0.5f;
		//bringing back gravity, not the best way but its good enough for now
	}

	void OnTriggerEnter(Collider other)
	{
		//Player collects objects when colliding with them 
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
			PickUpSfx.Play();
			Debug.Log("Object is picked up");
		}

		if (other.gameObject.name == "Mom" && count == 4)
		{
			SceneManager.LoadScene("WinState2");
			Debug.Log("You found Mom and Got all your Stuff!");
		}
		else if (other.gameObject.name == "Mom" && count < 4)
		{
			SceneManager.LoadScene("WinState1");
			Debug.Log("You found mom but missed stuff.");
		}
	}

	void SetCountText()
	{
		countText.text = "Items Collected: " + count.ToString() + " of 4";
	}
}
