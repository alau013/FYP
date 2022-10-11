using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float duration =0.1f;
    public float elapsedTime = 0f;
    public Vector3 startPosition;
    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator Shaking()
    {
        startPosition = transform.position;
        elapsedTime = 0f;

        while (elapsedTime < duration){
            elapsedTime += Time.deltaTime;
          //  float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * 50;
            yield return null;
        }

        transform.position = startPosition;
    }
}
