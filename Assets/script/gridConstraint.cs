using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gridConstraint : MonoBehaviour
{
    // Start is called before the first frame update
    GridLayoutGroup glg;

    public void  gridLimit(string key) {        
        glg = gameObject.GetComponent<GridLayoutGroup>();
        Debug.Log(glg);
        Debug.Log("key from table is : "+ key);
        Debug.Log("key length from table is : "+ key.Length);
        glg.constraint = GridLayoutGroup.Constraint.FixedColumnCount;  //**
        glg.constraintCount = key.Length;                                    //**
    }
}
