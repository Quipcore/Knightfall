using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!\t" + name);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,1) * Time.deltaTime);
    }
}
