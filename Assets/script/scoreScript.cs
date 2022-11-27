using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class scoreScript : MonoBehaviour
{
    public GameObject scoreObject;
    public GameObject scoreIncreaseAnimation;

    public displayScript displayScript;
    public static int score ;
    public static int pointgain = 100;

    public static int pointScored; // 1 - no hint used || 2 - 1 hint used || 3 - 2 hint used ||
    public void updateScore()
    {
        
        // if (displayScript.hint1Status() == true && displayScript.hint2Status() == false && displayScript.skipStatus() == false)
        // {
        //     pointgain = 75;
        // }
        // else if(displayScript.hint1Status() == true && displayScript.hint2Status() == true && displayScript.skipStatus() == false)
        // {
        //     pointgain = 50;
        // }
        // else if (displayScript.hint1Status() == true && displayScript.hint2Status() == true && displayScript.skipStatus() == true )
        // {
        //     pointgain = 0;
        // }
        if (pointScored == 1)
        {
            pointgain = 100;
        }
        else if(pointScored == 2)
        {
            pointgain = 75;
        }
        else if(pointScored == 3)
        {
            pointgain = 50;
        }
        else if(pointScored == 4)
        {
            pointgain = 0;
        }
        score += pointgain;

        scoreIncreaseAnimation.GetComponent<TextMeshProUGUI>().text = "+"+pointgain;
        scoreIncreaseAnimation.GetComponent<Animation>().Play("scoreAddAnimation");
        scoreObject.GetComponent<TextMeshProUGUI>().text = "Score: "+ score;
        pointgain = 100;
    }
    // Update is called once per frame
    public int totalScore()
    {
        return score;
    }

    public void resetScore()
    {
        score = 0;
    }

}
