using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public class PlayerSettings
    {
        public bool MusicIsOn = true;
        public bool ADSisOn = true;
    }

    [SerializeField] private Button _musicOffBtn;
    [SerializeField] private Button _musicOnBtn;

    public PlayerSettings CurrentSettings;

    public static Settings Instance;

    public static Action onSettingsLoaded;

    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            transform.SetParent(null);
            Load();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(CurrentSettings);
        PlayerPrefs.SetString("PlayerSettings", jsonString);
    }

    public void Load()
    {
        string data = PlayerPrefs.GetString("PlayerSettings");
        CurrentSettings = JsonUtility.FromJson<PlayerSettings>(data);
        if (CurrentSettings == null) CurrentSettings = new PlayerSettings();

        onSettingsLoaded?.Invoke();
    }


}
