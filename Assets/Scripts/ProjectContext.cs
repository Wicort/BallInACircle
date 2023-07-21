using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectContext : MonoBehaviour
{
    [SerializeField] private AudioSource _clipSource;
    [SerializeField] private AudioSource _musicSource;

    [SerializeField] private Button _btnMusicOff;
    [SerializeField] private Button _btnMusicOn;
    public static ProjectContext Instance { get; private set; }

    public PauseManager PauseManager { get; private set; }

    public Settings Settings { get; private set; }

    public SoundManager SoundManager { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            Initialize();
        } else
        {
            Destroy(gameObject);
        }
    }

    public void Initialize()
    {
        PauseManager = new PauseManager();
        SoundManager = new SoundManager(_musicSource, _clipSource);
        Settings = new Settings(_btnMusicOff, _btnMusicOn);
        
    }

}
