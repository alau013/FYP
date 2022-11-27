using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gridMaker : MonoBehaviour
{
   [SerializeField] GameObject gridPrefab;
   [SerializeField] float number;

   [SerializeField] questionGenerator questionGenerator;
   [SerializeField] gridConstraint gridConstraint;

   private GameObject _newGrid;

   List<GameObject> gridList = new List<GameObject>();
   int row,col;
   string sortedKey;

    void Start() 
    {

    }

    public void generateGrid()
    {

        string text ="";
        string key = questionGenerator.key();
        gridConstraint.gridLimit(key);

        if (TableView.gamelevelTable == 1)
        {
            text = questionGenerator.ptQuestion();
        }
        else if( TableView.gamelevelTable == 2)
        {
            text = questionGenerator.ptQuestion();
            sortedKey = cryptoAlgo.sortKey(key);
            
        }

        for (int i =0; i< key.Length; i++) // show key
        {
            Color keyColor = new Color(0.75f, 0.68f, 1.02f);
            _newGrid = Instantiate(gridPrefab, GameObject.FindGameObjectWithTag("canvas").transform);
            _newGrid.GetComponentInChildren<TextMeshProUGUI>().text = "<b>"+key[i].ToString()+"<b>";
            _newGrid.GetComponentInChildren<TextMeshProUGUI>().color = keyColor;
            gridList.Add(_newGrid);
        }
        
        for (int j =0; j< text.Length; j++) //show text
        {
            _newGrid = Instantiate(gridPrefab, GameObject.FindGameObjectWithTag("canvas").transform);
            _newGrid.GetComponentInChildren<TextMeshProUGUI>().text = text[j].ToString();
            gridList.Add(_newGrid);
        }
        
    }

    public void destoryGrid()
    {
         foreach (GameObject grid in gridList) 
         {
            Destroy(grid);
         }
         gridList.Clear();
    }

}
