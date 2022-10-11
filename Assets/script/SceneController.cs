using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SceneController : MonoBehaviour
{
    public GameObject startBtn;
    public GameObject dummy;

    void Start() 
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            dummy.GetComponent<Button>().interactable = false;
        }
    }

    // Start is called before the first frame update
    public void startGame()
    {  
       SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
       SceneManager.LoadScene(0); 
    }

}
