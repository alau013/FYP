using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class copyPaste : MonoBehaviour
{
    public displayScript displayScript;

    // Start is called before the first frame update
    bool waitTime = false;
    public void cheatsheet()
    {
        waitTime =true;
        StartCoroutine(delayCoroutine());
        IEnumerator delayCoroutine()
        {
            yield return new WaitForSeconds(2);

            if(waitTime == true)
            {
                displayScript.displayPlainText();
            }
        }  

    }

    public void decheatsheet()
    {
        waitTime = false;
        displayScript.unDisplayPlainText();
    }
}
