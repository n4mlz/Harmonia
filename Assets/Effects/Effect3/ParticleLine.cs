using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using MidiJack;

public class ParticleLine : MonoBehaviour
{
    // Start is called before the first frame update

    private AsyncOperationHandle<GameObject> handle;

    async void Start()
    {
        handle = Addressables.LoadAssetAsync<GameObject>("Effect3/ParticleLine.prefab");  // インスタンス化するプレハブ
        await handle.Task;
        GameObject instance = Instantiate(handle.Result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void on() {

    }
}
