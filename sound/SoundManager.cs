using UnityEngine;
using System.Collections;

public class SoundManager :MonoBehaviour {

    static public AudioSet[] map = new AudioSet[3];
    static public AudioSet shot1, amulet, fall;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            map[i] = new AudioSet("map" + i.ToString(), gameObject);
        }

        shot1 = new AudioSet("shot1", gameObject);
        amulet = new AudioSet("amulet", gameObject);
        fall = new AudioSet("fall", gameObject);
    }

    public static void Play(AudioSet audio)
    {
        audio.Play();
    }
}

