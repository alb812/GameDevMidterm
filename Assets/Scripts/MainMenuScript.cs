using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Intent: Activates buttons on ManiMenu Scene
//Usage: put on MainMenu gameObject
public class MainMenuScript : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    
    public void InfoScene()
    {
        SceneManager.LoadScene("AboutScene");
    }
    
    public void ReturnMenu()
    {
        SceneManager.LoadScene("StartGame");
    }
    
}

