using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuObject;
    public GameObject PauseBtn;
    public GameObject pauseDummy;
    public GameObject unPauseBtn;
    public GameObject scoreObject;
    
    public scoreScript scoreScript;
    void Start()
    {
        unPauseBtn.SetActive(false);
        PauseMenuObject.SetActive(false);
    }

    public void activatePauseMenu()
    {
        PauseMenuObject.SetActive(true);
        PauseBtn.SetActive(false);
        pauseDummy.SetActive(false);
        unPauseBtn.SetActive(true);

        int score = scoreScript.totalScore();
        scoreObject.GetComponent<TextMeshProUGUI>().text = "score: "+score.ToString();

    }

    public void DeactivatePauseMenu()
    {
        PauseMenuObject.SetActive(false);
         PauseBtn.SetActive(true);
        pauseDummy.SetActive(true);
        unPauseBtn.SetActive(false);
    }

    public void hidePauseMenuBtn()
    {
        PauseBtn.SetActive(false);
    }
}
