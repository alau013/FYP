using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class displayScript : MonoBehaviour
{

    public GameObject ptObject;
    public GameObject keyObject;
    public GameObject EncryptedTextObject;
    public GameObject checkBtn;
    public GameObject unlockHintBtn;
    public GameObject HintBtn1;
    public GameObject HintBtn2;
    public GameObject TableHintBtn;
    public GameObject TableHintBtnDummy;
    public GameObject skipAnswerObject;
    public GameObject UserAnswerObject;
    public GameObject imgCorrectObject;
    public GameObject imgWrongObject;
    public GameObject StageText;
    //public GameObject ScoreIncreaseAnimationObj;
    public Image skipPanel;
    public questionGenerator questionGenerator;
    public shake shake;
    public scoreScript scoreScript;
    public resultScript resultScript;

    public gridMaker gridMaker;
    public resetBar resetBar;



    //public GameObject unPauseBtn;

    private bool _started = false;

    private bool _hintOneActivated = false;
    private bool _hintOneHalfActive = false;
    private bool _hintTwoActivated = false;
    private bool _hintTwoHalfActive = false;
    private bool _skipActivated = false;
    public static bool maxHit = false;
    private bool _disableKey = false;

    private int _gameLevel;

    public  AudioSource correctSound;
    public  AudioSource wrongSound;

   

    string plaintext;
    string key;
    string Questiontext;
    string userAnswerText;
    string hintTypetext;
    string hintCiphertext;
    // Start is called before the first frame update
    void Start()
    {
        scoreScript.resetScore();
        StartCoroutine(displayCoroutine());
        _gameLevel = PlayerPrefs.GetInt("gameLevel");
       maxHit = false;
       unlockHintBtn.GetComponent<Button>().interactable = false;
       HintBtn1.GetComponent<Button>().interactable = false;
       TableHintBtn.GetComponent<Button>().interactable = false;
       TableHintBtnDummy.GetComponent<Button>().interactable = false;
        TableHintBtn.SetActive(false);
        TableHintBtnDummy.SetActive(false);
       HintBtn2.GetComponent<Button>().interactable = false;
       imgCorrectObject.GetComponent<Image>().enabled = false;
        imgWrongObject.GetComponent<Image>().enabled = false;
        IEnumerator displayCoroutine()
      {
             yield return new WaitForSeconds(0.15f);
             showQuestionAndKey();
            _started = true;
   

      }
    }

    void Update() {
        if (userAnswer() == "" || _disableKey == true)
        {
             checkBtn.GetComponent<Button>().interactable = false;
        }
        else{
             checkBtn.GetComponent<Button>().interactable = true;
        }

        if (maxHit == true)
        {
            resultScript.activateResult();
        }

    }

    public void showQuestionAndKey()
    {
        if (_started == true){
           
            questionGenerator.getQuestion();
            resetHintBtnFunc();
            UserAnswerObject.GetComponent<TMP_InputField>().interactable = true;
            checkBtn.GetComponentInChildren<TextMeshProUGUI>().text = "check";
            _skipActivated = false;
            skipAnswerObject.GetComponent<TextMeshProUGUI>().text = "";
            unlockHintBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Unlock Hint";
            StageText.SetActive(true);
            resetBar.resetBarfunc();
            if (_gameLevel == 3)
            TableHintBtn.SetActive(value: false);
            TableHintBtnDummy.SetActive(false);

            scoreScript.pointScored = 1;
        }
        skipPanel.GetComponent<Image>().enabled = false;
        questionGenerator.updateQuestionCount();
       // displayPlainText();
        displayKey();
        displayQuestion();
        imgCorrectObject.GetComponent<Image>().enabled = false;
        imgWrongObject.GetComponent<Image>().enabled = false;


        

      //  Debug.Log("Plaintext is : "+plaintext);
      //  Debug.Log("key is : "+key);
      //  Debug.Log("encrypted text is : "+encryptedtext);
    
    }

    public void answerChecker()
    {
        Debug.Log("plaintext is : "+ questionGenerator.ptQuestion());
        Debug.Log("encrypted text is: "+ questionGenerator.encrypted());
        Debug.Log("userAnswer is : "+ userAnswer());
        Debug.Log("gameLevel is: "+ _gameLevel );
        
        if ((_gameLevel ==1 && userAnswer() == questionGenerator.encrypted()) || _skipActivated == true )
        {
            userCorrect();
        }
        else if((_gameLevel ==2 && userAnswer() == questionGenerator.ptQuestion()) || _skipActivated == true)
        {
            userCorrect();
        }
        else if((_gameLevel == 3 && questionGenerator.RandomMode() == 1 && userAnswer() == questionGenerator.encrypted()) ||  _skipActivated == true)
        {
            userCorrect();
        }
        else if((_gameLevel == 3 && questionGenerator.RandomMode() == 2 && userAnswer() == questionGenerator.ptQuestion()) ||  _skipActivated == true)
        {
            userCorrect();
        }
        else
        {
            StartCoroutine(shake.Shaking());
            StageText.SetActive(false);
            imgWrongObject.GetComponent<Image>().enabled = true;        
            wrongSound.Play();
            if (_hintOneHalfActive == false &&  _hintTwoHalfActive == false)
            {
                unlockHintBtn.GetComponent<Button>().interactable = true;
            }

            StartCoroutine(delayFadeOut());
            IEnumerator delayFadeOut()
            {
                yield return new WaitForSeconds(0.5f);
                 imgWrongObject.GetComponent<Image>().enabled = false;
                 StageText.SetActive(value: true);
            }
        }
        Debug.Log("answer checker after hint1Status: "+hint1Status() + " hint2status: "+hint2Status()+ " skipstatus: "+skipStatus());
    }
    public void resetHintBtnFunc()
    {
        unlockHintBtn.GetComponent<Button>().interactable = false;
        HintBtn1.SetActive(true);
        HintBtn1.GetComponent<Button>().interactable = false;
        TableHintBtn.GetComponent<Button>().interactable = false;
        TableHintBtnDummy.GetComponent<Button>().interactable = false;
        HintBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "";
        _hintOneActivated = false;
        _hintOneHalfActive = false;

        HintBtn2.GetComponent<Button>().interactable = false;
        HintBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "";
        _hintTwoActivated = false;
        _hintTwoHalfActive = false;
    }
    public void unlockHintFunc()
    {
        if( _hintOneActivated == false) // show hint 1 btn
        {
            HintBtn1.GetComponent<Button>().interactable = true;
            HintBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Hint 1";
            TableHintBtn.GetComponent<Button>().interactable = true;
            TableHintBtnDummy.GetComponent<Button>().interactable = true;
            _hintOneHalfActive = true;

            scoreScript.pointScored = 2;

        }
        else if (_hintOneActivated == true && _hintTwoActivated == false) // show hint 2 btn
        {
            Debug.Log("hi");
            HintBtn2.GetComponent<Button>().interactable = true;
            HintBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "Hint 2";
            _hintTwoHalfActive = true;

            scoreScript.pointScored = 3;
        }
        else if (_hintOneActivated == true && _hintTwoActivated == true) //show answer
        {
            UserAnswerObject.GetComponent<TMP_InputField>().interactable = false;
            checkBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Next";
            StageText.SetActive(false);
            TableHintBtn.GetComponent<Button>().interactable = false;
            TableHintBtnDummy.GetComponent<Button>().interactable = false;
            _skipActivated = true;
            skipPanel.GetComponent<Image>().enabled = true;
            scoreScript.pointScored = 4;
           
           if (_gameLevel ==1)
           {
                skipAnswerObject.GetComponent<TextMeshProUGUI>().text = (questionGenerator.encrypted());
           }
           else if (_gameLevel == 2)
           {
                skipAnswerObject.GetComponent<TextMeshProUGUI>().text = (questionGenerator.ptQuestion());
           }
           else if (_gameLevel == 3)
           {
                if (questionGenerator.RandomMode() == 1)
                {
                    skipAnswerObject.GetComponent<TextMeshProUGUI>().text = (questionGenerator.encrypted());
                }
                else if (questionGenerator.RandomMode() == 2)
                {
                     skipAnswerObject.GetComponent<TextMeshProUGUI>().text = (questionGenerator.ptQuestion());
                }
           }
        }

        unlockHintBtn.GetComponent<Button>().interactable = false;
    }
    public void displayPlainText()
    {
        if (_gameLevel == 1)
        {
            plaintext = questionGenerator.encrypted();
        }
        else if (_gameLevel == 2)
        {
            plaintext = questionGenerator.ptQuestion();
        }
        else if (_gameLevel == 3)
        {
            if (questionGenerator.RandomMode() == 1)
            {
                plaintext = questionGenerator.encrypted();
            }
            else{
                 plaintext = questionGenerator.ptQuestion();
            }
        }
        ptObject.GetComponent<TextMeshProUGUI>().text = (plaintext);
    }
     public void unDisplayPlainText()
    {
        ptObject.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void displayKey()
    {
        key = questionGenerator.key();
        keyObject.GetComponent<TextMeshProUGUI>().text = (key);
    }
    public void displayQuestion()
    {
        if (_gameLevel == 1) // show plaintext, find encrypted
        {
            Questiontext = questionGenerator.ptQuestion();
            StageText.GetComponent<TextMeshProUGUI>().text = "Find the encrypted text"; 
            TableView.gamelevelTable = 1;
        }
        else if(_gameLevel == 2) // show encrypted, find plaintext
        {
            Questiontext = questionGenerator.encrypted();
            StageText.GetComponent<TextMeshProUGUI>().text = "Find the plain text";
            TableView.gamelevelTable = 2;
        }
        else if(_gameLevel == 3) // random
        {
             if (questionGenerator.RandomMode() == 1)
             {
                Questiontext = questionGenerator.ptQuestion();
                StageText.GetComponent<TextMeshProUGUI>().text = "Find the encrypted text";
                TableView.gamelevelTable = 1;
             }
             else if (questionGenerator.RandomMode() == 2){
                Questiontext = questionGenerator.encrypted();
                StageText.GetComponent<TextMeshProUGUI>().text = "Find the plain text";
                TableView.gamelevelTable = 2;
             }
        }
        EncryptedTextObject.GetComponent<TextMeshProUGUI>().text = (Questiontext);
    }

    public void userCorrect()
    {
        _disableKey = true;
        if (_skipActivated == false)
        {
            imgWrongObject.GetComponent<Image>().enabled = false;
            imgCorrectObject.GetComponent<Image>().enabled = true;
            correctSound.Play();
        }
        StageText.SetActive(false);
        displayHint();
        displayHint2();
        unlockHintBtn.GetComponentInChildren<TextMeshProUGUI>().text = "unlock hint";

        StartCoroutine(delayCoroutine());

            IEnumerator delayCoroutine()
            {
                scoreScript.updateScore();
                yield return new WaitForSeconds(1.5f);
                showQuestionAndKey();
                 UserAnswerObject.GetComponent<TMP_InputField>().text = "";
                 _disableKey = false;
            }     
}
    
    public void displayHint()
    {
        hintTypetext= questionGenerator.cipherType();
        if (hintTypetext == "Columnar Transposition")
        {
            TableView.tabletype = 2;
        }
        else{
            TableView.tabletype = 1;
        }
        HintBtn1.GetComponentInChildren<TextMeshProUGUI>().text = (hintTypetext);
        HintBtn1.GetComponent<Button>().interactable = false;
        HintBtn1.SetActive(false);
        TableHintBtn.SetActive(true);
        TableHintBtnDummy.SetActive(true);
        TableHintBtn.GetComponentInChildren<TextMeshProUGUI>().text = (hintTypetext);

        unlockHintBtn.GetComponent<Button>().interactable = false;  
        _hintOneActivated = true;
        _hintOneHalfActive = false;

          if (_gameLevel == 1 || (_gameLevel == 3 && questionGenerator.RandomMode() == 1)) // skip next hint if game level is 1
            {
                 _hintTwoActivated = true;
                 _hintTwoHalfActive = false;
                 unlockHintBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Show Answer";
            }
    }

    public void displayHint2()
    {
        if (_gameLevel == 1 || (_gameLevel == 3 && questionGenerator.RandomMode() == 1)) //  skip display of hint 2 only if is game level 1 and game level 3, random mode = 1
        {
            return;
        }
        hintCiphertext= questionGenerator.ptType();
        HintBtn2.GetComponentInChildren<TextMeshProUGUI>().text = (hintCiphertext);
        HintBtn2.GetComponent<Button>().interactable = false;

        unlockHintBtn.GetComponent<Button>().interactable = false;
        unlockHintBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Show Answer";
        _hintTwoActivated = true;
        _hintTwoHalfActive = false;
    }

    public string userAnswer()
    {
        return userAnswerText = UserAnswerObject.GetComponent<TMP_InputField>().text;
    }

    public bool hint1Status()
    {
        return _hintOneActivated;
    }
    public bool hint2Status()
    {
        return _hintTwoActivated;
    }
    public bool skipStatus()
    {
        return _skipActivated;
    }

}
