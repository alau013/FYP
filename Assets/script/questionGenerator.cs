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
    int maxQuestion = 0;
    int prevNo = -1;
    int randomchance;

    public void Start() {
      randomchance = 0;
      int TempLevel = PlayerPrefs.GetInt("gameLevel");
        if (TempLevel == 1)
        {
            maxQuestion = 5;
        }
        else if (TempLevel ==2)
        {
             maxQuestion = 5;
        }
        else if (TempLevel ==3)
        {
            maxQuestion = 10;
        }

        Debug.Log("Entering Level " + TempLevel);
        Debug.Log("Max question is :" + maxQuestion);
        getQuestion();
    }
    public void getQuestion()
    {
        randomchance = 0;
        questionCount++;

         if (Random.value < .5)
            {
                randomchance = 1;
            }
            else{
                randomchance = 2;
            }

        if(questionCount == maxQuestion+1)
        {
            displayScript.maxHit = true;
            return;
        }
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

        Debug.Log("counnt: "+questionCount);
        prevNo = randomQuestion;

        Debug.Log(plaintext);
        Debug.Log(encrypted());
    }

    public void getQuestionDev() ///// for presentation demo
    {
        string  key;
        string encryptedtext;
        randomchance = 0;
        questionCount++;

         if (Random.value < .5)
            {
                randomchance = 1;
            }
            else{
                randomchance = 2;
            }

        if(questionCount == maxQuestion+1)
        {
            displayScript.maxHit = true;
            return;
        }

        if (questionCount == 1)
        {
            plaintext = "apple";
            keyValue = "fyp";
            randomMode = 2;
            encryptedtext = encrypted();
        }
        else if (questionCount == 2)
        {
            plaintext = "carrot";
            keyValue = "e";
            randomMode = 1;
            encryptedtext = encrypted();
        }
         else if (questionCount == 3)
        {
            plaintext = "cabbage";
            keyValue = "algo";
            randomMode = 3;
            encryptedtext = encrypted();
        }
         else if (questionCount == 4)
        {
            plaintext = "norway";
            keyValue = "limit";
            randomMode = 3;
            encryptedtext = encrypted();
        }
         else if (questionCount == 5)
        {
            plaintext = "pear";
            keyValue = "cipher";
            randomMode = 2;
            encryptedtext = encrypted();
        }
         else if (questionCount == 6)
        {
            plaintext = "apple";
            keyValue = "math";
            randomMode = 1;
            encryptedtext = encrypted();
        }
    
    }


    public void updateQuestionCount()
    {
        questionCountObject.GetComponent<TextMeshProUGUI>().text = "Question " +questionCount + "/"+maxQuestion;
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
    public int RandomMode()
    {
      return randomchance;
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
        string text;
         text = cryptoAlgo.TranspositionCipher(plaintext,keyValue);
         text = text.Replace(" ", "");
         return text;
       }
       return "";
    }

}
