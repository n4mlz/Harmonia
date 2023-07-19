using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;

public class Master : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i=21; i<109; i++)  // note 21 ~ 108
        {
            GameObject keyObject = new GameObject($"Key{i}");
            keyObject.transform.SetParent(transform);
            keyObject.AddComponent<Key>();
            keyObject.GetComponent<Key>().key = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
