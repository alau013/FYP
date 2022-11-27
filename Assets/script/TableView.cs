using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TableView : MonoBehaviour
{
    public GameObject tableViewObject;

    public GameObject hintBtn;
    public GameObject hintDummy;
    public GameObject SubmitBtn;
    public GameObject SubmitDummy;
    public GameObject PauseBtn;
    public GameObject PauseDummy;
    public GameObject VTable;
    public GameObject TCTable;

    public GameObject bar;
    public gridMaker gridMaker;
    private bool _bar = false;
    public static int tabletype; //1 = vigenere cipher table | 2 =  transposition ciphers table
    public static int gamelevelTable; // 1 = show encryptedtext hint | 2 = show plaintext hint

    // Start is called before the first frame update

    public void closeTableFunc()
    {
        tableViewObject.SetActive(false);
         if (tabletype == 1)
        {
            VTable.SetActive(value: false);
            
        }
        else if( tabletype == 2)
        {
            TCTable.SetActive(false);
        }
       
        PauseBtn.SetActive(true);
        PauseDummy.SetActive(true);
        hintBtn.SetActive(true);
        SubmitBtn.SetActive(true);
        hintDummy.SetActive(true);
        SubmitDummy.SetActive(true);

    

    }

    public void openTableFunc()
    {
        tableViewObject.SetActive(true);
        if (tabletype == 1)
        {
            VTable.SetActive(true);
        }
        else if( tabletype == 2)
        {
            TCTable.SetActive(true);
        }

        PauseBtn.SetActive(false);
        PauseDummy.SetActive(false);
        hintBtn.SetActive(false);
        SubmitBtn.SetActive(false);
        hintDummy.SetActive(false);
        SubmitDummy.SetActive(false);

        
    }

}
