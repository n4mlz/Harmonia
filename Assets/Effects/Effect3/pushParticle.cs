using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushParticle : MonoBehaviour
{
    // Start is called before the first frame update
    public float delta = 0;
    public float curve_speed = 15.0f;
    void Start()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y += -0.3f;
        gameObject.transform.position = pos;    
    }

    // Update is called once per frame
    void Update()
    {
        var pos_config = gameObject.GetComponent<ParticleSystem>().shape;
        Vector3 nextPosition = new Vector3(Mathf.Sin(Time.time * curve_speed + delta) / 7.0f,
         pos_config.position.y, Mathf.Cos(Time.time * curve_speed + delta) / 7.0f);
        pos_config.position = nextPosition;
    }

    public void on() {
        // gameObject.SetActive(true);
        var emisson_config = gameObject.GetComponent<ParticleSystem>().emission;
        emisson_config.enabled = true;
    }
    
    public void off() {
        var emisson_config = gameObject.GetComponent<ParticleSystem>().emission;
        emisson_config.enabled = false;
    }
}
