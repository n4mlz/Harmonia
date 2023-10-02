using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using MidiJack;

public class Key3 : MonoBehaviour
{
    public int key;
    private AsyncOperationHandle<GameObject> handle, cubeHandle;

    private GameObject particle = null;
    // Start is called before the first frame update
    async void Start()
    {
        transform.position = getSpawnPoint();
        // handle = Addressables.LoadAssetAsync<GameObject>("Effect3/Cube3.prefab");  // インスタンス化するプレハブ
        handle = Addressables.LoadAssetAsync<GameObject>("Effect3/BlueFire.prefab");  // インスタンス化するプレハブ
        cubeHandle = Addressables.LoadAssetAsync<GameObject>("Effect3/Cube3.prefab");  // インスタンス化するプレハブ
        await handle.Task;
        await cubeHandle.Task;

        particle = Instantiate(handle.Result, transform.position, Quaternion.identity);
        particle.transform.SetParent(transform);
        particle.GetComponent<Particle>().off();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 getSpawnPoint()
    {
        int sp_x;
        Dictionary<int, int> d = new Dictionary<int, int>()
            {{0, 0}, {1, 0}, {2, 1}, {3, 1}, {4, 2}, {5, 3}, {6, 3}, {7, 4}, {8, 4}, {9, 5}, {10, 5}, {11, 6}};
        List<int> black_keys = new List<int> {1, 3, 6, 8, 10};
        int q, r;
        q = Math.DivRem(key, 12, out r);
        if (black_keys.Contains(r)){
            sp_x = (q * 7 + d[r] - 37) * 2;
        } else
        {
            sp_x =  (q * 7 + d[r] - 37) * 2 - 1;
        }
        return new Vector3(sp_x*0.3f, -4, 0);
    }

    private GameObject instance = null;
    public void On(float velocity) {
        particle.GetComponent<Particle>().on();

        instance = Instantiate(cubeHandle.Result, transform.position, Quaternion.identity);
        instance.transform.SetParent(transform);
        instance.GetComponent<Cube3>().on();
    }

    public void Off() {
        // 処理を記述
        particle.GetComponent<Particle>().off();

        instance.GetComponent<Cube3>().off();
        instance = null;
    }
}
