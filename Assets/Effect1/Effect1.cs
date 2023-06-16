using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Effect1 : MonoBehaviour
{
    int key;
    private AsyncOperationHandle<GameObject> handle;

    // Start is called before the first frame update
    void Start()
    {
        key = GetComponentInParent<Key>().key;
        handle = Addressables.LoadAssetAsync<GameObject>("Assets/Effect1/Cube.prefab");  // インスタンス化するプレハブ
    }

    // Update is called once per frame
    void Update()
    {
        
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
