using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using MidiJack;

public class test_Key3 : MonoBehaviour
{
    public int key;
    private AsyncOperationHandle<GameObject> handle, cubeHandle;

    private GameObject[] particles = new GameObject[150];
    
    // Start is called before the first frame update
    async void Start()
    {
        transform.position = getSpawnPoint();
        // handle = Addressables.LoadAssetAsync<GameObject>("Effect3/Cube3.prefab");  // インスタンス化するプレハブ
        handle = Addressables.LoadAssetAsync<GameObject>("Effect3/BlueFire.prefab");  // インスタンス化するプレハブ
        cubeHandle = Addressables.LoadAssetAsync<GameObject>("Effect3/Cube3.prefab");  // インスタンス化するプレハブ
        await handle.Task;
        await cubeHandle.Task;

        particles[key] = Instantiate(handle.Result, transform.position, Quaternion.identity);
        particles[key].transform.SetParent(transform);
        particles[key].GetComponent<Particle>().off();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 getSpawnPoint()
    {
        return new Vector3((key-64)*0.3f, -4, 0);
    }

    public void On(int note, float velocity) {
        // if(particles[note] != null) {
        //     Debug.Log($"key {note} is not null");
        // }
        // GameObject instance = Instantiate(handle.Result, transform.position, Quaternion.identity);
        // instance.transform.SetParent(transform);
        // particles[note] = instance;
        particles[note].GetComponent<Particle>().on();
    }

    public void Off(int note) {
        // if(particles[note] == null) {
        //     Debug.Log($"key {note} is null");
        // }
        particles[note].GetComponent<Particle>().off();
    }
}
