using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class questionGenerator : MonoBehaviour
{
    
    public jsonReader json;
    public cryptoAlgo algo;
    public GameObject questionCountObject;
    public string alphabet = "abcdefghijklmnopqrstuvwxyz";
    string plaintext;
    string keyValue;
    string playerAns;

    string ptTypeStr;
    string ciphertypeText;
    int randomMode;
    int questionCount = 0;
    int maxQuestion = 10;
    int prevNo = -1;

    public void Start() {
        getQuestion();
    }
    public void getQuestion()
    {
        questionCount++;
        // getting plaintext + type from jsondata
        int randomQuestion = Random.Range(0,json.questionLength()); 
        while (prevNo == randomQuestion)
        {
            randomQuestion = Random.Range(0,json.questionLength());
        }
        plaintext = json.getName(randomQuestion);
        ptTypeStr = json.getType(randomQuestion);

        // randomize the mode
        randomMode = Random.Range(1,4);
        Debug.Log("mode is :" + randomMode);
        if (randomMode == 1)  // Caesar key
        {
            Debug.Log("enter caesar key");
            int randomAlphabet = Random.Range(0,26);
            keyValue = alphabet[randomAlphabet].ToString();
        }
        else // Vigenere and transpostion key
        {
            Debug.Log(message: "enter vigenere key");
            int randomKey = Random.Range(0,json.keyLength()); 
             keyValue =  json.getKey(randomKey);
        }

        if(questionCount == maxQuestion)
        {
            displayScript.maxHit = true;
        }
        Debug.Log("counnt: "+questionCount);
        prevNo = randomQuestion;
    }

    public void updateQuestionCount()
    {
        questionCountObject.GetComponent<TextMeshProUGUI>().text = "Question " +questionCount + "/10";
    }

    public string ptQuestion() 
    {
        return plaintext;
    }

    public string key()
    {
        return keyValue;
    }
    public string ptType()
    {
        return ptTypeStr;
    }


    public string cipherType()
    {
        if (randomMode == 1)
        {
             ciphertypeText= "Caesar Cipher";
        }
        else if(randomMode == 2)
        {
            ciphertypeText = "Vigenere Cipher";
        }
        else if(randomMode == 3)
        {
             ciphertypeText = "Columnar Transposition";
        }
        return ciphertypeText;
    }


    public string encrypted()
    {
       // return algo.VigenereCipher(plaintext,"A");
       if(randomMode == 1)
       {
        return algo.CaesarCipher(plaintext,keyValue); 
       }
       else if(randomMode == 2)
       {
       return algo.VigenereCipher(plaintext,keyValue);
       }
       else if(randomMode == 3)
       {
        return algo.TranspositionCipher(plaintext,keyValue);
       }
       return "";
    }

}
