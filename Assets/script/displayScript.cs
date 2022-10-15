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
    public GameObject skipAnswerObject;
    public GameObject UserAnswerObject;
    public GameObject imgCorrectObject;
    public GameObject imgWrongObject;
    //public GameObject ScoreIncreaseAnimationObj;
    public Image skipPanel;
    public questionGenerator questionGenerator;
    public shake shake;
    public scoreScript scoreScript;
    public resultScript resultScript;

    //public GameObject unPauseBtn;

    private bool _started = false;

    private bool _hintOneActivated = false;
    private bool _hintOneHalfActive = false;
    private bool _hintTwoActivated = false;
    private bool _hintTwoHalfActive = false;
    private bool _skipActivated = false;
    public static bool maxHit = false;

    public  AudioSource correctSound;
    public  AudioSource wrongSound;

   

    string plaintext;
    string key;
    string encryptedtext;
    string userAnswerText;
    string hintTypetext;
    string hintCiphertext;
    // Start is called before the first frame update
    void Start()
    {
        
        scoreScript.resetScore();
        StartCoroutine(displayCoroutine());
       maxHit = false;
       unlockHintBtn.GetComponent<Button>().interactable = false;
       HintBtn1.GetComponent<Button>().interactable = false;
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
        if (userAnswer() == "")
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
            questionGenerator.updateQuestionCount();
            resetHintBtnFunc();
            UserAnswerObject.GetComponent<TMP_InputField>().interactable = true;
            checkBtn.GetComponentInChildren<TextMeshProUGUI>().text = "check";
            _skipActivated = false;
            skipAnswerObject.GetComponent<TextMeshProUGUI>().text = "";
            unlockHintBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Unlock Hint";
        }
        skipPanel.GetComponent<Image>().enabled = false;
        displayPlainText();
        displayKey();
        displayEncrypted();
        imgCorrectObject.GetComponent<Image>().enabled = false;
        imgWrongObject.GetComponent<Image>().enabled = false;
      //  Debug.Log("Plaintext is : "+plaintext);
      //  Debug.Log("key is : "+key);
      //  Debug.Log("encrypted text is : "+encryptedtext);

    }

    public void answerChecker()
    {
        
        if (userAnswer() == plaintext || _skipActivated == true)
        {
            if (userAnswer() == plaintext)
            {
                imgWrongObject.GetComponent<Image>().enabled = false;
                imgCorrectObject.GetComponent<Image>().enabled = true;
                correctSound.Play();
                displayHint();
                displayHint2();
                unlockHintBtn.GetComponentInChildren<TextMeshProUGUI>().text = "unlock hint";
            }
            StartCoroutine(delayCoroutine());

            IEnumerator delayCoroutine()
            {
                scoreScript.updateScore();
                yield return new WaitForSeconds(1.5f);
                showQuestionAndKey();
                 UserAnswerObject.GetComponent<TMP_InputField>().text = "";
            }

            
        }
        else
        {
            StartCoroutine(shake.Shaking());
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
            }
        }
    }
    public void resetHintBtnFunc()
    {
        unlockHintBtn.GetComponent<Button>().interactable = false;
        HintBtn1.GetComponent<Button>().interactable = false;
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
            _hintOneHalfActive = true;
        }
        else if (_hintOneActivated == true && _hintTwoActivated == false) // show hint 2 btn
        {
            Debug.Log("hi");
            HintBtn2.GetComponent<Button>().interactable = true;
            HintBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "Hint 2";
            _hintTwoHalfActive = true;
        }
        else if (_hintOneActivated == true && _hintTwoActivated == true) //show answer
        {
            UserAnswerObject.GetComponent<TMP_InputField>().interactable = false;
            checkBtn.GetComponentInChildren<TextMeshProUGUI>().text = "Next";
            _skipActivated = true;
            skipPanel.GetComponent<Image>().enabled = true;
            skipAnswerObject.GetComponent<TextMeshProUGUI>().text = (questionGenerator.ptQuestion());
        }

        unlockHintBtn.GetComponent<Button>().interactable = false;
    }
    public void displayPlainText()
    {
        plaintext = questionGenerator.ptQuestion();
        ptObject.GetComponent<TextMeshProUGUI>().text = (plaintext);
    }

    public void displayKey()
    {
        key = questionGenerator.key();
        keyObject.GetComponent<TextMeshProUGUI>().text = (key);
    }

    public void displayEncrypted()
    {
        encryptedtext = questionGenerator.encrypted();
        EncryptedTextObject.GetComponent<TextMeshProUGUI>().text = (encryptedtext);
    }
    
    public void displayHint()
    {
        hintTypetext= questionGenerator.ptType();
        HintBtn1.GetComponentInChildren<TextMeshProUGUI>().text = (hintTypetext);
        HintBtn1.GetComponent<Button>().interactable = false;

        unlockHintBtn.GetComponent<Button>().interactable = false;  
        _hintOneActivated = true;
         _hintOneHalfActive = false;
    }

    public void displayHint2()
    {
        hintCiphertext= questionGenerator.cipherType();
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
