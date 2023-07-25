using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using MidiJack;

public class Key2 : MonoBehaviour
{
    public int key;
    public float speed;
    private AsyncOperationHandle<GameObject> handle;

    // Start is called before the first frame update
    async void Start()
    {
        transform.position = getSpawnPoint();
        speed = 5f;  // ここでスピードを変更
        handle = Addressables.LoadAssetAsync<GameObject>("Effect2/Cube2.prefab");  // インスタンス化するプレハブ
        await handle.Task;

        // ----- memo ----- //

        if (key==64) StartCoroutine(tmp());

        // ----- memo ----- //
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator tmp(){   // memo
        GameObject instance = Instantiate(handle.Result, transform.position, Quaternion.identity);
        instance.transform.SetParent(transform);
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < transform.childCount; i++)
        {
        GameObject Child = transform.GetChild(i).gameObject;
        Child.GetComponent<Cube2>().Off();
        }
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
        return new Vector3(sp_x*0.3f, 0, 0);
    }

    public void On(float velocity) {
        GameObject instance = Instantiate(handle.Result, transform.position, Quaternion.identity);
        instance.transform.SetParent(transform);
    }

    public void Off() {
        for (int i = 0; i < transform.childCount; i++)  // 一番最後のオブジェクトのみでよいが念のため
            {
                GameObject Child = transform.GetChild(i).gameObject;
                Child.GetComponent<Cube2>().Off();
            }
    }
}
