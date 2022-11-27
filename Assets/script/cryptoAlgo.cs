using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System.Linq;


/// ====== cryptographic algorithm =========
public class cryptoAlgo : MonoBehaviour
{

    // caesar cipher
    public string plainText;
    public GameObject inputField;
    public GameObject textDisplay;

    public string alphabet = "abcdefghijklmnopqrstuvwxyz";
    public string key = "";
    int shiftvalue;

    public void GetPlainText()
    {
        plainText = inputField.GetComponent<Text>().text;
        plainText = plainText.ToLower();
       if(textCleaner(plainText))
       {
   
        VigenereCipher(plainText,key);
       }
       else{
  
       }


    }

    public string CaesarCipher(string plainText,string key)
    {
        // geting shift value of the letter
        for(int k = 0; k < alphabet.Length; k++)
        {
                if ( char.Parse(key) == alphabet[k])
                {
                    shiftvalue = alphabet.IndexOf(alphabet[k]);
                }
        }

        // shifting the letter
        char[] tempChar = plainText.ToCharArray();
        for (int i = 0; i < tempChar.Length; i++)
        {
            char letter = tempChar[i];
            if (letter != ' ')
            {
                letter = (char)(letter + shiftvalue);
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
        return encryptedText;
       
    }

    public string VigenereCipher (string plaintext, string key)
    {
        
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

    public static string TranspositionCipher(string plaintext, string key)
    {
        int row,col;
        string encryptedtext = "";
        string sortedKey ;
        char[] plaintextArray = plaintext.ToCharArray();
        char[] keyArray = key.ToCharArray();

      //   Debug.Log("Plaintext is : "+plaintext);
      //   Debug.Log("key is : "+key);

        // getting row and col
        row = key.Length;
        col = plaintext.Length/row;
        if (plaintext.Length % row != 0)
        {
            col+=1;
        }
        char[,] matrix = new char[col,row];

        // putting plain text into 2x2 matrix
        int c =0;
        for (int i= 0; i <col ;i++)
        {
            for (int j = 0; j<row; j++)
            {
                if( c > plaintext.Length-1){
                    matrix[i,j] =' ';
                }
                else{
                    matrix[i,j] = plaintextArray[c];
                }
                c++;
            }
        }
        sortedKey = sortKey(key);

        for (int i= 0; i <col ;i++)
        {
            for (int j = 0; j<row; j++)
            {
            //    Debug.Log("matrix ["+i+"]"+"["+j+"]" + " is " + matrix[i,j]);
            }
        }   
        
        // loop thru key to get the matrix text column by column
        int z =0;      
        Debug.Log("keylength is "+ sortedKey.Length);
        for(int n = 0;n < row;n++)
        {   
            if(z >= sortedKey.Length)
            {
             //   Debug.Log("breaking............");
                break;
            }
            if(sortedKey[z] == keyArray[n])
            {
            //    Debug.Log("Entering inner loop now");
            //    Debug.Log("z counter: "+z + " n counter: "+n);

                for(int o = 0; o<col; o++)
                {
                    Debug.Log("matrix is : "+matrix[o,n]);
                    encryptedtext+= matrix[o,n];
                }
                keyArray[n] ='-';
                z++;
                n =-1;
             //   Debug.Log("encryptedText: "+encryptedtext);
            }
        }
      //  Debug.Log(encryptedtext);
       // encryptedtext = encryptedtext.Replace(" ", "");
        return encryptedtext;

    }
    // sort key in alphbet order
    public static string sortKey (string key)
    {
        string sortedString ="";
        char[] sortedKey = key.ToCharArray();
        char temp = ' ';  
            for (int i = 0; i <= sortedKey.Length-1; i++)  
            {  
                for (int j = i+1; j < sortedKey.Length; j++)  
                {  
                    if (sortedKey[i] > sortedKey[j])  
                    {  
                    
                        temp = sortedKey[i];  
                        sortedKey[i] = sortedKey[j];  
                        sortedKey[j] = temp;

                    } 
                }  
            }

        for (int k=0; k <= sortedKey.Length-1; k++)
        {
            sortedString = sortedString + sortedKey[k];
        }      
        return sortedString;

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
