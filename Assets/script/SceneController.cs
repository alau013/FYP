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
    public GameObject dummy2;
    public GameObject dummy3;
    public GameObject dummy4;
    public GameObject dummy5;

    void Start() 
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            dummy.GetComponent<Button>().interactable = false;
            dummy2.GetComponent<Button>().interactable = false;
            dummy3.GetComponent<Button>().interactable = false;
            dummy4.GetComponent<Button>().interactable = false;
            dummy5.GetComponent<Button>().interactable = false;
            
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

    public void creditSence()
    {
        SceneManager.LoadScene(2);
    }

}
