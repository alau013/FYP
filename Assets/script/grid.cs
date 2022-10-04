using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{

    [SerializeField] GameObject gridPrefab;
    [SerializeField] int mode;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid(mode);
    }

    void GenerateGrid(int mode)
    {
        if (mode == 1)
        {
                // mode 1 = 2x2 grid
            Vector3 bar = transform.position;
            for (int i = 0; i < 25; i++)
            {
                for (int y = 0; y<2; y++)
                {
                    //float scale = 0.9f;
                    GameObject grid = Instantiate(gridPrefab,new Vector2(bar[0]+i*0.8f,bar[1]+y*0.8f),Quaternion.identity) as GameObject;
                }
            }
        }
        else if (mode == 2)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int y=0; y < 5; y++)
                {
                    GameObject grid = Instantiate(gridPrefab) as GameObject;
                    grid.transform.position = new Vector3(i,y,0f);
                }
            }
        }
    }
    
}
