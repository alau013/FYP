using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject levelOneBtn;
   public GameObject levelTwoBtn;
   public GameObject levelThreeBtn;
   public GameObject levelOneDummy;
   public GameObject levelTwoDummy;
   public GameObject levelThreeDummy;
   public GameObject PlayBtn;
   public GameObject creditBtn;
   public GameObject PlayBtnDummy;
   public GameObject creditBtnDummy;
   public SceneController SceneController;

   private void Start() 
   {
        levelOneBtn.SetActive(false);
        levelTwoBtn.SetActive(false);
        levelThreeBtn.SetActive(false);

        levelOneDummy.SetActive(false);
        levelTwoDummy.SetActive(false);
        levelThreeDummy.SetActive(false);
   }
   public void selectStgFunction()
   {
        PlayBtn.SetActive(false);
        creditBtn.SetActive(false);

        PlayBtnDummy.SetActive(false);
        creditBtnDummy.SetActive(false);

        levelOneBtn.SetActive(value: true);
        levelTwoBtn.SetActive(true);
        levelThreeBtn.SetActive(true);

        levelOneDummy.SetActive(true);
        levelTwoDummy.SetActive(true);
        levelThreeDummy.SetActive(true);
   }
   public void StartLevelOne()
   {
        PlayerPrefs.SetInt("gameLevel", 1);
        SceneController.startGame();
   }

    public void StartLevelTwo()
   {
        PlayerPrefs.SetInt("gameLevel", 2);
        SceneController.startGame();
   }

    public void StartLevelThree()
   {
        PlayerPrefs.SetInt("gameLevel", 3);
        SceneController.startGame();
   }
}
