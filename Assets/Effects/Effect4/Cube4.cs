using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube4 : MonoBehaviour
{
    float elapsedTime;
    float speed;
    bool on;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 localScale = transform.localScale;
        localScale.x = 0.5f;
        localScale.z = 0.5f;
        transform.localScale = localScale;
        speed = GetComponentInParent<Key4>().speed;
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
        if (transform.position.y - transform.localScale.y/2 > 15) Destroy(this.gameObject);
    }

    public void Off(){
        on = false;
    }
}
