using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube2 : MonoBehaviour
{
    float elapsedTime;
    float speed;
    bool on;
    // Start is called before the first frame update
    void Start()
    {
        speed = GetComponentInParent<Key2>().speed;
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (on) {
            Vector3 localScale = transform.localScale;
            localScale.y = speed * elapsedTime;
            transform.localScale = localScale;
            transform.Translate(0f, speed * Time.deltaTime/2, 0f);
        } else {
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
    }

    public void Off(){
        on = false;
    }
}
