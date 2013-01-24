using UnityEngine;
using System.Collections;

public class AudioSet
{
    public AudioClip clip;
    public AudioSource source;
    public AudioSet(string name, GameObject attachObject)
    {
        clip = Resources.Load("Sound/" + name) as AudioClip;
        source = attachObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.playOnAwake = false;
    }

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void Pause()
    {
        source.Pause();
    }
}