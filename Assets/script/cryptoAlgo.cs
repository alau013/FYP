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

    public string alphabet = "abcdefghijklmnopqrstuvwxyz";
    public string key = "";

    public void GetPlainText()
    {
        plainText = inputField.GetComponent<Text>().text;
        plainText = plainText.ToLower();
       if(textCleaner(plainText))
       {
        Debug.Log("HI");
        VigenereCipher(plainText,key);
       }
       else{
        Debug.Log("BYE");
       }


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

    public string VigenereCipher (string plaintext, string key)
    {
        
      //  Debug.Log("Entering vigenere cipher");
      //  Debug.Log("plaintext: "+ plaintext);
      //  Debug.Log("key: "+ key);
        string encryptedtext ="";
        int counter =0;
        int ptLenght = plaintext.Length;

        for(int i = 0; i <ptLenght ;i++)
        {
         for( int j=0; j<key.Length; j++)
            {
                int lettershift;
                if (counter == plaintext.Length){
                    break;
                }
               if (plaintext[counter] == (char)32)
                {
                    encryptedtext += (char)32;
                    counter++;
                 }
                lettershift = ((int)key[j] - (int)alphabet[0]);
                lettershift = ((int)plaintext[counter]+ lettershift);
                if(lettershift > (int)'z')
                {
                    lettershift -= 26;
                }
                encryptedtext += (char)lettershift;
                counter++;  
             //   Debug.Log("encrypted text is: " + encryptedtext);
            }
            
        }
        return encryptedtext;
    }

    public bool textCleaner(string str)
    {
        string regularEx = "^[ A-Za-z]+$";
        Match m = Regex.Match(str,regularEx);
        if (m.Success)
        {
            return true;
        }
        return false;
    }
}
