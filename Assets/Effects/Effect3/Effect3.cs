using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using MidiJack;

public class Effect3 : MonoBehaviour
{
    int key;
    private AsyncOperationHandle<GameObject> handle;

    // Start is called before the first frame update
    async void Start()
    {
        key = GetComponentInParent<Key>().key;
        handle = Addressables.LoadAssetAsync<GameObject>("Effect3/Cube3.prefab");  // インスタンス化するプレハブ
        await handle.Task;

        // if(key == 50) {
        //     Vector3 spawnPoint = getSpawnPoint();
        //     GameObject instance = Instantiate(handle.Result, spawnPoint, Quaternion.identity);
        // }
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    Vector3 getSpawnPoint()
    {
        return new Vector3((key-64)*0.1f, -4, 0);
    }


    void OnEnable() {
        MidiMaster.noteOnDelegate += NoteOn;
        MidiMaster.noteOffDelegate += NoteOff;
    }

    void OnDisable() {
        MidiMaster.noteOnDelegate -= NoteOn;
        MidiMaster.noteOffDelegate -= NoteOff;
    }

    void NoteOn(MidiChannel channel, int note, float velocity) {
        if(note == key)
        {
            Vector3 spawnPoint = getSpawnPoint();
            GameObject instance = Instantiate(handle.Result, spawnPoint, Quaternion.identity);
        }
    }

    void NoteOff(MidiChannel channel, int note) {
        if(note == key)
        {

        }
    }
}
