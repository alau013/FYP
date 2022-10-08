using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class questionGenerator : MonoBehaviour
{
    
    public jsonReader json;
    public cryptoAlgo algo;

    string plaintext;
    string keyValue;
    string playerAns;

    public void Start() {
        getQuestion();
    }
    public void getQuestion()
    {
        
        int randomQuestion = Random.Range(0,json.questionLength());  
        plaintext = json.getName(randomQuestion);

        int randomKey = Random.Range(0,json.keyLength()); 
        keyValue =  json.getKey(randomKey);
    }

    public string ptQuestion() 
    {
        return plaintext;
    }

    public string key()
    {
        return keyValue;
    }

    public string encrypted()
    {
        return algo.VigenereCipher(plaintext,keyValue);
    }

}
