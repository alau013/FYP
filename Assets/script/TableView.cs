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

    public GameObject bar;
    private bool _bar = false;

    // Start is called before the first frame update
    void Start()
    {
      //  tableViewObject.SetActive(false);
    }

    public void closeTableFunc()
    {
        tableViewObject.SetActive(false);
       
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

        PauseBtn.SetActive(false);
        PauseDummy.SetActive(false);
        hintBtn.SetActive(false);
        SubmitBtn.SetActive(false);
        hintDummy.SetActive(false);
        SubmitDummy.SetActive(false);
        
    }

    public void activateBar()
    {
        bar = GameObject.FindGameObjectWithTag("D");
    
         if(_bar == true)
         {
            bar.SetActive(false);
             _bar = false;
         }
         else{
             bar.SetActive(true);
         _bar = true;

         }

    }

}
