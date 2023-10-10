using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2key3 : MonoBehaviour
{
    List<GameObject> keys = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        List<int> num_list = new List<int>(){0, 2, 4, 5, 7, 9, 11, 12};
        for (int i = 0; i < 8; i++)
        {
            GameObject k = GameObject.Find($"Key{60+num_list[i]}");
            keys.Add(k);
        }
    }

    // Update is called once per frame
    void Update()
    {
        List<string> s = new List<string>(){"s", "d", "f", "g", "h", "j", "k", "l"};
        for (int i = 0; i < 8; i++)
        {
            if (Input.GetKeyDown(s[i])) {
                keys[i].GetComponent<Key3>().On(0.5f);
            }
            if (Input.GetKeyUp(s[i])) {  
                keys[i].GetComponent<Key3>().Off();
            }            
        }
    }
}
