using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : ISoundOnHandler
{
    
    private AudioSource _musicSource;
    private AudioSource _clipSource;

    public bool IsSoundOn;
    List<ISoundOnHandler> _handlers = new List<ISoundOnHandler>();

    public void Register(ISoundOnHandler handler)
    {
        _handlers.Add(handler);
    }
    public void UnRegister(ISoundOnHandler handler)
    {
        _handlers.Remove(handler);
    }

    public SoundManager(AudioSource musicSource, AudioSource clipSource)
    {
        _musicSource = musicSource;
        _clipSource = clipSource;
    }
    

    public void PlaySound(AudioClip _sound)
    {
        Debug.Log($"Play sound: {IsSoundOn}");
        if (!IsSoundOn) return;

        _clipSource.PlayOneShot(_sound);
    }


    public void setSoundOn(bool isSoundOn)
    {
        IsSoundOn = isSoundOn;
        Debug.Log($"set isSoundOn: {isSoundOn}");

        _clipSource.volume = IsSoundOn ? 0.2f : 0f;
        _musicSource.volume = IsSoundOn ? 0.2f : 0f;

        foreach (var handler in _handlers)
        {
            handler.setSoundOn(isSoundOn);
        }
    }
}
