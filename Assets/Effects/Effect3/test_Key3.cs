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
    private AsyncOperationHandle<GameObject> handle;

    // Start is called before the first frame update
    async void Start()
    {
        transform.position = getSpawnPoint();
        handle = Addressables.LoadAssetAsync<GameObject>("Effect3/Cube3.prefab");  // インスタンス化するプレハブ
        await handle.Task;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 getSpawnPoint()
    {
        return new Vector3((key-64)*0.3f, 0, 0);
    }

    public void On(int note, float velocity) {
        GameObject instance = Instantiate(handle.Result, transform.position, Quaternion.identity);
        instance.transform.SetParent(transform);
    }

    public void Off(int note) {
        // 処理を記述
    }
}
