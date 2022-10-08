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
    public GameObject btn;
    public GameObject UserAnswerObject;
    public questionGenerator questionGenerator;

    private bool _started = false;

   

    string plaintext;
    string key;
    string encryptedtext;
    string userAnswerText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(displayCoroutine());
        IEnumerator displayCoroutine()
      {
             yield return new WaitForSeconds(0.25f);
             showQuestionAndKey();
            _started = true;
      }
    }

    public void showQuestionAndKey()
    {
        if (_started == true){
          questionGenerator.getQuestion();
        }
        displayPlainText();
        displayKey();
        displayEncrypted();

        Debug.Log("Plaintext is : "+plaintext);
        Debug.Log("key is : "+key);
        Debug.Log("encrypted text is : "+encryptedtext);

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

    public string userAnswer()
    {
        return userAnswerText = UserAnswerObject.GetComponent<TMP_InputField>().text;
    }

}
