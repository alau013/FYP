using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class resultScript : MonoBehaviour
{
    public GameObject masterObj;
    public GameObject scoreObj;
    public scoreScript scoreScript;
    public PauseMenu pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        masterObj.SetActive(false);
    }

    public void activateResult()
    {
        masterObj.SetActive(true);
        pauseMenu.hidePauseMenuBtn();
        int score = scoreScript.totalScore();
        scoreObj.GetComponent<TextMeshProUGUI>().text = "score: "+score.ToString();
    }
    
}
