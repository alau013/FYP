using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleBar : MonoBehaviour
{
  public GameObject bar;
  public  AudioSource checkSound;
  public  AudioSource unCheckSound;
  private bool _bar;
  public static bool barReset = false;

   public void switchBar()
    {
    
         if(_bar == true)
         {
            bar.SetActive(false);
            unCheckSound.Play();
             _bar = false;
         }
         else{
             bar.SetActive(true);
             checkSound.Play();
         _bar = true;

         }

    }
}
