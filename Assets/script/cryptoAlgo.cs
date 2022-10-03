using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;


/// ====== cryptographic algorithm =========
public class cryptoAlgo : MonoBehaviour
{

    // caesar cipher
    public string plainText;
    public GameObject inputField;
    public GameObject textDisplay;

    public void GetPlainText()
    {
        plainText = inputField.GetComponent<Text>().text;
        plainText = plainText.ToLower();
        textCleaner(plainText);

    }
    public void CaesarCipher(string plainText)
    {
        char[] tempChar = plainText.ToCharArray();
        for (int i = 0; i < tempChar.Length; i++)
        {
            char letter = tempChar[i];
            if (letter != ' ')
            {
                letter = (char)(letter + 1);
                if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
                else if (letter < 'a')
                {
                    letter = (char)(letter + 26);
                }
            }
            tempChar[i] = letter;
        }
        string encryptedText = new string(tempChar);
        textDisplay.GetComponent<Text>().text = "welcome " + encryptedText;
    }

    public void textCleaner(string str)
    {
        string regularEx = "^[ A-Za-z]+$";
        Match m = Regex.Match(str,regularEx);
        if (m.Success)
        {
            CaesarCipher(str);
        }
    }
}
