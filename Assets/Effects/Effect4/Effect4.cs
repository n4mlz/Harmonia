using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class Effect4 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        for (int i=21; i<109; i++)  // note 21 ~ 108
        {
            GameObject keyObject = new GameObject($"Key{i}");
            keyObject.transform.SetParent(transform);
            keyObject.AddComponent<Key4>();
            keyObject.GetComponent<Key4>().key = i;
        }
        GameObject key2keyObject = new GameObject($"Key2key4");
        key2keyObject.transform.SetParent(transform);
        key2keyObject.AddComponent<Key2key4>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        GameObject child = transform.Find($"Key{note}").gameObject;
        child.GetComponent<Key4>().On(velocity);
    }

    void NoteOff(MidiChannel channel, int note) {
        GameObject child = transform.Find($"Key{note}").gameObject;
        child.GetComponent<Key4>().Off();
    }
}
