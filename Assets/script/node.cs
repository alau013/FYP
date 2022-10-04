using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class node : MonoBehaviour
{

    public TextMeshPro _text;
    char[] alphabet = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
    int[] number ={0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25};
    // Start is called before the first frame update


    // Update is called once per frame
    public void updateChar(int inc, int levelPos)
    {
        if(levelPos == 0)
        {
            _text.GetComponent<TextMeshPro>().text = number[inc].ToString();
        }
        else if (levelPos == 1)
        {
            _text.GetComponent<TextMeshPro>().text = alphabet[inc].ToString();
        }
    }
}
