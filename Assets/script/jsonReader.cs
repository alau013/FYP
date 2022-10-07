using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jsonReader : MonoBehaviour
{
    public TextAsset textJSON;
    [System.Serializable]

    // question from json data
    public class Question
    {
        public string name;
        public string type;    
    }

    [System.Serializable]
        public class QuestionList
    {
        public Question[] question; 
    }

    private QuestionList myQuestionList = new QuestionList();

    // key from json data
    [System.Serializable]
    public class Key
    {
        public string key;
    }

    [System.Serializable]
    public class KeyList
    {
        public Key[] key; 
    }

    private KeyList myKeyList = new KeyList();

    // Start is called before the first frame update
    void Start()
    {
        myQuestionList = JsonUtility.FromJson<QuestionList>(textJSON.text);
        myKeyList = JsonUtility.FromJson<KeyList>(textJSON.text);


      // for (int i = 0; i<myKeyList.key.Length; i++)
      //  {
      //    Debug.Log(myKeyList.key[i].key);
      // }
    }
    public int questionLength() 
    {
        int length = myQuestionList.question.Length;
        return length;
    }
    
    public int keyLength()
    {
        int length = myKeyList.key.Length;
        return length;
    }

    public string getName(int i)
    {
        return myQuestionList.question[i].name;
    }
    public string getType(int i)
    {
        return myQuestionList.question[i].type;
    }
    public string getKey(int i)
    {
        return myKeyList.key[i].key;
    }
}
