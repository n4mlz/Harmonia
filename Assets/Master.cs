using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;

public class Master : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30; // FPS固定
        GameObject effectObject = new GameObject($"effect");
        effectObject.transform.SetParent(transform);
        effectObject.AddComponent<Effect3>();  // ここでエフェクトを指定
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
