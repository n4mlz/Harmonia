using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

public class Cube3 : MonoBehaviour
{
    private int shift = 0;
    public float speed = 0.15f;
    private AsyncOperationHandle<Material> handle;

    private float CurrentRotation = 0.0f;

    private byte color_g = 255;
    private int key_sub = 0;

    // Start is called before the first frame update
    async void Start()
    {
        Vector3 pos = gameObject.transform.position;
        pos.y += -0.3f;
        gameObject.transform.position = pos;

        handle = Addressables.LoadAssetAsync<Material>("Effect3/New Material 1.mat");  // インスタンス化するプレハブ
        await handle.Task;
// Effect3/NewMaterial.mat
        // var mat = Resources.Load<Material>("Assets/Effects/Effect3/NewMaterial.mat");
        // m_material = new Material(mat);
        gameObject.GetComponent<Renderer>().material = handle.Result;
        // Debug.Log(cllist[100]);

        // int[] cl = new int[4];
        // int[] cr = new int[4];
        int[] cl = {1, 0, 117, 1};
        int[] cr = {0, 255, 255, 1};
        byte[] ca = new byte[4];
        for(int i = 0; i < 4;i++) ca[i] = (byte)((cr[i] - cl[i]) * (key_sub - 21) / 88 + cl[i]);
        gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color32(ca[0], ca[1], ca[2], ca[3]));
        // gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color32(255, color_g, 0, 255));
    }

    // Update is called once per frame
    async void Update()
    {
        // Material sub = gameObject.GetComponent<Renderer>().material;
        // await sub.Task;
        // Debug.Log(gameObject.GetComponent<Renderer>().material.GetFloat("Custom1.w"));
        // gameObject.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(0.25f,0.25f));
        // CurrentRotation += 0.1f;
        // CurrentRotation %= 1.0f;

        Vector3 rot = gameObject.transform.localEulerAngles;
        rot.y += 10.0f;
        gameObject.transform.localEulerAngles = rot;
        // gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color32(0, (byte)(key_sub * 2), 255, 255));



        if(shift == 0) {
            Vector3 pos = gameObject.transform.position;
            pos.y += speed / 2;
            gameObject.transform.position = pos;
            Vector3 sz = gameObject.transform.localScale;
            sz.y += speed;
            gameObject.transform.localScale = sz;
            gameObject.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(0.25f, sz.y * 0.25f));
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

    public void init(int key) {
        // color_g = cllist[key];
        key_sub = key;
        // Debug.Log(cllist[key]);
    }

    public void on() {
        shift = 0;
    }
    
    public void off() {
        shift = 1;
    }
}
