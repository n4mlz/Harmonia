using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int key;

    // Start is called before the first frame update
    void Start()
    {
        GameObject effectObject = new GameObject($"effect{key}");
        effectObject.transform.SetParent(transform);

        effectObject.AddComponent<Effect1>();  // ここでエフェクトを指定
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
