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
    public GameObject UserAnswerObject;
    public GameObject imgCorrectObject;
    public GameObject imgWrongObject;
    public questionGenerator questionGenerator;

    private bool _started = false;

    private bool _hintOneActivated = false;
    private bool _hintTwoActivated = false;


   

    string plaintext;
    string key;
    string encryptedtext;
    string userAnswerText;
    string hintTypetext;
    string hintCiphertext;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(displayCoroutine());
       
       unlockHintBtn.GetComponent<Button>().interactable = false;
       HintBtn1.GetComponent<Button>().interactable = false;
       HintBtn2.GetComponent<Button>().interactable = false;
        IEnumerator displayCoroutine()
      {
             yield return new WaitForSeconds(0.25f);
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

    }

    public void showQuestionAndKey()
    {
        if (_started == true){
          questionGenerator.getQuestion();
          resetHintBtnFunc();
        }
        displayPlainText();
        displayKey();
        displayEncrypted();
        imgCorrectObject.GetComponent<Image>().enabled = false;
        imgWrongObject.GetComponent<Image>().enabled = false;
        Debug.Log("Plaintext is : "+plaintext);
        Debug.Log("key is : "+key);
        Debug.Log("encrypted text is : "+encryptedtext);

    }

    public void answerChecker()
    {
        
        if (userAnswer() == plaintext)
        {
            imgWrongObject.GetComponent<Image>().enabled = false;
            imgCorrectObject.GetComponent<Image>().enabled = true;
            StartCoroutine(delayCoroutine());

            IEnumerator delayCoroutine()
        {
                yield return new WaitForSeconds(1);
                showQuestionAndKey();
                 UserAnswerObject.GetComponent<TMP_InputField>().text = "";
        }

            
        }
        else{
            imgWrongObject.GetComponent<Image>().enabled = true;
            unlockHintBtn.GetComponent<Button>().interactable = true;
        }
    }
    public void resetHintBtnFunc()
    {
        unlockHintBtn.GetComponent<Button>().interactable = false;
        HintBtn1.GetComponent<Button>().interactable = false;
        HintBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "";
        _hintOneActivated = false;

        HintBtn2.GetComponent<Button>().interactable = false;
        HintBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "";
        _hintTwoActivated = false;
    }
    public void unlockHintFunc()
    {
        if( _hintOneActivated == false)
        {
            HintBtn1.GetComponent<Button>().interactable = true;
            HintBtn1.GetComponentInChildren<TextMeshProUGUI>().text = "Hint 1";
        }
        else if (_hintOneActivated == true && _hintTwoActivated == false)
        {
            HintBtn2.GetComponent<Button>().interactable = true;
            HintBtn2.GetComponentInChildren<TextMeshProUGUI>().text = "Hint 2";
        }
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
    }

    public void displayHint2()
    {
        hintCiphertext= questionGenerator.cipherType();
        HintBtn2.GetComponentInChildren<TextMeshProUGUI>().text = (hintCiphertext);
        HintBtn2.GetComponent<Button>().interactable = false;

        unlockHintBtn.GetComponent<Button>().interactable = false;  
        _hintTwoActivated = true;
    }

    public string userAnswer()
    {
        return userAnswerText = UserAnswerObject.GetComponent<TMP_InputField>().text;
    }

}
