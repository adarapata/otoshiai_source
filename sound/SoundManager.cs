using UnityEngine;
using System.Collections;

public class SoundManager :MonoBehaviour {

    static public AudioSet shot1, amulet;

    void Start()
    {
        shot1 = new AudioSet("shot1", gameObject);
        amulet = new AudioSet("amulet", gameObject);
    }

    public static void Play(AudioSet audio)
    {
        audio.Play();
    }
}

