using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    private Bgm bgm;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Play()
    {
        bgm.Play();
    }

    public void Stop()
    {
        bgm.Stop();
    }

    public bool SetBgm(TrackName name)
    {
        if (bgm == null || bgm.name != name) { bgm = new Bgm(name); bgm.Attach(gameObject); return true; }
        return false;
    }

    /// <summary>
    /// シーンのMusicManagerを返す
    /// </summary>
    /// <returns></returns>
    public static MusicManager GetInstance()
    {
       return FindObjectOfType(typeof(MusicManager)) as MusicManager;
    }

    /// <summary>
    /// シーン上にMusicManagerが存在しない場合のみ、生成する
    /// </summary>
    /// <returns></returns>
    public static bool CreateInstance()
    {
        if (FindObjectOfType(typeof(MusicManager)) == null)
        {
            var self = Resources.Load("Objects/music/MusicManager") as GameObject;
            Instantiate(self);
            return true;
        }
        return false;
    }

}

public enum TrackName
{
    otenba,
    select,
    pinko
}

public class Bgm
{
    public TrackName name;
    public AudioClip clip;
    public AudioSource source;
    public Bgm(TrackName track)
    {
        clip = Resources.Load("music/" + track.ToString()) as AudioClip;
        name = track;
    }
    public void Attach(GameObject attachObject)
    {
        source = attachObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.playOnAwake = false;
        source.loop = true;
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