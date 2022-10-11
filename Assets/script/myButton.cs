using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class myButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Btn;
    // Start is called before the first frame update
    public void OnPointerDown (PointerEventData eventData) 
	{
        if (Btn.GetComponent<Button>().interactable == true)
		{
            Vector3 pos = Btn.transform.position;
            pos.y -= 20f;
            Btn.transform.position = pos;
        }
	}
    public void OnPointerUp (PointerEventData eventData) 
	{
	   if (Btn.GetComponent<Button>().interactable == true)
       {
        Vector3 pos = Btn.transform.position;
        pos.y += 20f;
        Btn.transform.position = pos;
       }
	}



}
