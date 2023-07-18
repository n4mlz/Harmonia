using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
// using System.Threading.Tasks;

public class Effect1 : MonoBehaviour
{
    int key;
    private AsyncOperationHandle<GameObject> handle;

    // Start is called before the first frame update
    async void Start()
    {
        key = GetComponentInParent<Key>().key;
        handle = Addressables.LoadAssetAsync<GameObject>("Assets/Effect1/Cube.prefab");  // インスタンス化するプレハブ
        await handle.Task;
        Vector3 spawnPoint = getSpawnPoint();
        Instantiate(handle.Result, spawnPoint, Quaternion.identity);
        Addressables.Release(handle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 getSpawnPoint()
    {
        return new Vector3((key-64)*0.3f, 0, 0);
    }

//     private void NoteOn(MidiChannel channel, int note, float velocity) {
//         if (note == key){
//             // 処理を記述
//             GameObject instance = Instantiate(handle.Result, new Vector3(0, 0, 0), Quaternion.identity);
//         }
//    }

//    private void NoteOff(MidiChannel channel, int note) {
//         if (note == key){
//             // 処理を記述
//         }
//    }
}
