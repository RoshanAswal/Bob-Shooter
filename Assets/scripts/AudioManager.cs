using System;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {   if(instance==null)
            instance=this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        foreach(Sounds s in sounds){
            s.source=gameObject.AddComponent<AudioSource>();
            
            s.source.clip=s.clip;
            s.source.volume=s.volume;
            s.source.pitch=s.pitch;
            s.source.loop=s.loop;
        }
    }
 
    public void Play(string name)
    {
        Sounds s=Array.Find(sounds,sound=>sound.name==name);
        if(name==null){
            Debug.Log("song "+name+" Not found");
            return;
        }
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sounds s=Array.Find(sounds,sound=>sound.name==name);
        if(name==null){
            Debug.Log("song "+name+" Not found");
            return;
        }
        s.source.Stop();
    }
    

}
