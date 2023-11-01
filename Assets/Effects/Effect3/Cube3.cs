using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube3 : MonoBehaviour
{
    private int shift = 0;
    public float speed = 0.15f;
    private Material m_material;

    void OnDestroy()
    {
        GameObject.Destroy(m_material);
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y += -0.3f;
        gameObject.transform.position = pos;

        var mat = Resources.Load<Material>("Assets/Effects/Effect3/NewMaterial.mat");
        m_material = new Material(mat);
        gameObject.GetComponent<Renderer>().material = m_material;
    }

    // Update is called once per frame
    void Update()
    {
        if(shift == 0) {
            Vector3 pos = gameObject.transform.position;
            pos.y += speed / 2;
            gameObject.transform.position = pos;
            Vector3 sz = gameObject.transform.localScale;
            sz.y += speed;
            gameObject.transform.localScale = sz;
        }
        if(shift == 1) {
            Vector3 pos = gameObject.transform.position;
            pos.y += speed;
            gameObject.transform.position = pos;
            Vector3 sz = gameObject.transform.localScale;
            if(pos.y - sz.y / 2 >= 10.0f) {
                Destroy(gameObject);
            }
        
        Debug.Log(gameObject.GetComponent<Renderer>().material.shader);
        }
    }

    public void on() {
        shift = 0;
    }
    
    public void off() {
        shift = 1;
    }
}
