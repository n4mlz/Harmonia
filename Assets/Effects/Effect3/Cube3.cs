using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Cube3 : MonoBehaviour
{
    private int shift = 0;
    public float speed = 0.15f;

    private AsyncOperationHandle<Material> handle;

    private float CurrentRotation = 0.0f;

    // Start is called before the first frame update
    async void Start()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y += -0.3f;
        gameObject.transform.position = pos;

        handle = Addressables.LoadAssetAsync<Material>("Effect3/NewMaterial.mat");  // インスタンス化するプレハブ
        await handle.Task;
// Effect3/NewMaterial.mat
        // var mat = Resources.Load<Material>("Assets/Effects/Effect3/NewMaterial.mat");
        // m_material = new Material(mat);
        gameObject.GetComponent<Renderer>().material = handle.Result;
    }

    // Update is called once per frame
    async void Update()
    {
        // Material sub = gameObject.GetComponent<Renderer>().material;
        // await sub.Task;
        // Debug.Log(sub.GetFloat("_isRotation"));
        gameObject.GetComponent<Renderer>().material.SetFloat("_MainRotation", CurrentRotation);
        CurrentRotation += 0.01f;
        CurrentRotation %= 1.0f;


        if(shift == 0) {
            Vector3 pos = gameObject.transform.position;
            pos.y += speed / 2;
            gameObject.transform.position = pos;
            Vector3 sz = gameObject.transform.localScale;
            sz.y += speed;
            gameObject.transform.localScale = sz;
        }
        if(shift == 1) {
            Vector3 pos = gameObject.transform.position;
            pos.y += speed;
            gameObject.transform.position = pos;
            Vector3 sz = gameObject.transform.localScale;
            if(pos.y - sz.y / 2 >= 10.0f) {
                Destroy(gameObject);
            }
        }
    }

    public void on() {
        shift = 0;
    }
    
    public void off() {
        shift = 1;
    }
}
