using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y += -0.3f;
        pos.z += -0.3f;
        gameObject.transform.position = pos;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void log() {
        // Debug.Log("!" + gameObject.name);
    }
    
    public void on() {
        // gameObject.SetActive(true);
        var emisson_config = gameObject.GetComponent<ParticleSystem>().emission;
        emisson_config.enabled = true;
        for(int i = 0; i < 3; i++) {
            emisson_config = transform.GetChild(i).gameObject.GetComponent<ParticleSystem>().emission;
            emisson_config.enabled = true;
        }
    }
    
    public void off() {
        var emisson_config = gameObject.GetComponent<ParticleSystem>().emission;
        emisson_config.enabled = false;
        for(int i = 0; i < 3; i++) {
            emisson_config = transform.GetChild(i).gameObject.GetComponent<ParticleSystem>().emission;
            emisson_config.enabled = false;
        }
    }
}
