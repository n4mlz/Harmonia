using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    
    public void off() {
        var emisson_config = gameObject.GetComponent<ParticleSystem>().emission;
        emisson_config.enabled = false;
    }
}
