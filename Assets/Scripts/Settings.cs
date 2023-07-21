using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings
{
    public class PlayerSettings
    {
        public bool MusicIsOn = true;
        public bool ADSisOn = true;
    }

    private Button _musicOffBtn;
    private Button _musicOnBtn;

    public PlayerSettings CurrentSettings;

    public Settings(Button musicOffBtn, Button musicOnBtn)
    {
        _musicOffBtn = musicOffBtn;
        _musicOnBtn = musicOnBtn;

        Load();

        ProjectContext.Instance.SoundManager.setSoundOn(CurrentSettings.MusicIsOn);
        Debug.Log($"Load isSoundOn: {ProjectContext.Instance.SoundManager.IsSoundOn}");


        _musicOnBtn.gameObject.SetActive(CurrentSettings.MusicIsOn);
        _musicOffBtn.gameObject.SetActive(!CurrentSettings.MusicIsOn);
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
    }

    public void SetMusicOn(bool value)
    {
        CurrentSettings.MusicIsOn = value;
        Save();
        ProjectContext.Instance.SoundManager.setSoundOn(value);
        _musicOnBtn.gameObject.SetActive(CurrentSettings.MusicIsOn);
        _musicOffBtn.gameObject.SetActive(!CurrentSettings.MusicIsOn);
    }


}
