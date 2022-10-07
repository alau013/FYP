using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class questionGenerator : MonoBehaviour
{
    public GameObject displayText;
    public GameObject displayKey;
    public GameObject displaydEncrypted;
    public GameObject btn;
    public jsonReader json;
    public cryptoAlgo algo;

    public void getQuestion()
    {
        Debug.Log ("hi");
        int randomQuestion = Random.Range(0,json.questionLength());  
        displayText.GetComponent<TextMeshProUGUI>().text = (json.getName(randomQuestion));

        int randomKey = Random.Range(0,json.keyLength());  
        displayKey.GetComponent<TextMeshProUGUI>().text = (json.getKey(randomKey));

       // displaydEncrypted.GetComponent<TextMeshProUGUI>().text = algo.VigenereCipher(json.getName(randomQuestion),json.getKey(randomKey));
      // Debug.Log(algo.VigenereCipher(json.getName(randomQuestion),json.getKey(randomKey)));
    }

}
