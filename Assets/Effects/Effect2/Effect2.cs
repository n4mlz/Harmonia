using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using MidiJack;

public class Effect2 : MonoBehaviour
{
    int key;
    private AsyncOperationHandle<GameObject> handle;

    // Start is called before the first frame update
    async void Start()
    {
        key = GetComponentInParent<Key>().key;
        handle = Addressables.LoadAssetAsync<GameObject>("Effect2/Cube2.prefab");  // インスタンス化するプレハブ
        await handle.Task;
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
        return return new Vector3(sp_x*0.3f, 0, 0);        
    }


    private void NoteOn(MidiChannel channel, int note, float velocity) {
        if (note == key){
            // 処理を記述
            Vector3 spawnPoint = getSpawnPoint();
            GameObject instance = Instantiate(handle.Result, spawnPoint, Quaternion.identity);
        }
    }

    private void NoteOff(MidiChannel channel, int note) {
        if (note == key){
            // 処理を記述
        }
    }
}
