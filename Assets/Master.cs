using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i=21; i<109; i++)  // note 21 ~ 108
        {
            GameObject emptyObject = new GameObject($"Key{i}");
            emptyObject.AddComponent<Key>();
            emptyObject.GetComponent<Key>().v = -3.5f + i;
            emptyObject.GetComponent<Key>().key = keyList[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
