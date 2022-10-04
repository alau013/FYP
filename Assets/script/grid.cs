using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class grid : MonoBehaviour
{
    [SerializeField] private int _width = 4;
    [SerializeField] private int _height = 4;
    [SerializeField] private float xScaler;
    [SerializeField] private float yScaler;
    [SerializeField] private float xshift;
    [SerializeField] private float yshift;
    [SerializeField] public node _nodePrefab;
    public int mode;
    //[SerializeField] private TextMeshPro _text;
    
    
    void Start() {
        {
            GenerateGrid(mode);
        }
    }

    void GenerateGrid(int mode)
    {
        if (mode ==1) // 2 by 2 grid for Vigenere cipher
        {
            int inc = 0;
            for (int y = 0; y <2; y++)
            {
                inc = 0;
                for (int x = 0; x <26; x++)
                {
                    var node = Instantiate(_nodePrefab, new Vector2((x*0.75f)-5,y*0.75f), Quaternion.identity);
                    node.updateChar(inc,y);
                    inc+=1;
                }
            
             }
        }
        else if (mode ==2) // 5 by 5 grid for playfair cipher
        {
            int inc = 0;
            for (int y = 0; y <5; y++)
            {
                inc = 0;
                for (int x = 0; x <5; x++)
                {
                    var node = Instantiate(_nodePrefab, new Vector2((x*0.75f),y*0.75f+-1), Quaternion.identity);
                   // node.updateChar(inc,y);
                   // inc+=1;
                }
            
             }
        }
        
    }
}



