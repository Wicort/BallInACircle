using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    [SerializeField] private AudioSource _musicSource;

    private AudioSource source;

    private void OnEnable()
    {
        Settings.onSettingsLoaded += setMusicActive;
        Game.onSettingMusicIsOnChanged += setMusicActive;
    }

    private void OnDisable()
    {
        Settings.onSettingsLoaded -= setMusicActive;
        Game.onSettingMusicIsOnChanged -= setMusicActive;
    }

    private void Awake()
    {
        
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        source = GetComponent<AudioSource>();

    }
    

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }

    public void setMusicActive()
    {
        source.volume = Settings.Instance.CurrentSettings.MusicIsOn ? 0.2f : 0f;
        _musicSource.volume = Settings.Instance.CurrentSettings.MusicIsOn ? 0.2f : 0f;
        Debug.Log(_musicSource.volume);
    }

}
