using UnityEngine;
using System.Collections;

public class SoundManager :MonoBehaviour {

    static public AudioSet[] map = new AudioSet[3];
    static public AudioSet shot1, amulet, fall, attackLight, attackHeavy, death,
        hitLight, hitHeavy, item, gameStart, cursor1, cursor2, charge, shot2;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            map[i] = new AudioSet("map" + i.ToString(), gameObject);
        }

        shot1 = new AudioSet("shot1", gameObject);
        amulet = new AudioSet("amulet", gameObject);
        fall = new AudioSet("fall", gameObject);
        attackLight = new AudioSet("attackLight", gameObject);
        attackHeavy = new AudioSet("attackHeavy", gameObject);
        death = new AudioSet("death", gameObject);
        hitLight = new AudioSet("hitLight", gameObject);
        hitHeavy = new AudioSet("hitHeavy", gameObject);
        item = new AudioSet("item", gameObject);
        gameStart = new AudioSet("gameStart", gameObject);
        cursor1 = new AudioSet("cursor1", gameObject);
        cursor2 = new AudioSet("cursor2", gameObject);
        charge = new AudioSet("charge", gameObject);
        shot2 = new AudioSet("shot2", gameObject);
    }

    public static void Play(AudioSet audio)
    {
        audio.Play();
    }
}

