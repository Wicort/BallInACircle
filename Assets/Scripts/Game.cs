using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject LooseMenu;
    [SerializeField] private GameObject InGameMenu;


    [SerializeField] private Button _musicOffBtn;
    [SerializeField] private Button _musicOnBtn;

    public static Action onStartGame;
    public static Action onSettingMusicIsOnChanged;

    private void OnEnable()
    {
        HealthBar.onPlayerKill += LooseGame;
        Settings.onSettingsLoaded += onSettingsLoaded;
    }
    private void OnDisable()
    {
        HealthBar.onPlayerKill -= LooseGame;
        Settings.onSettingsLoaded -= onSettingsLoaded;
    }

    private void Awake()
    {
        StartMenu.SetActive(true);
        LooseMenu.SetActive(false);
        InGameMenu.SetActive(false);
    }

    private void onSettingsLoaded()
    {
        setMusicIsOn(Settings.Instance.CurrentSettings.MusicIsOn);
    }

    public void onStartButtonClicked()
    {
        onStartGame?.Invoke();
        StartGame();
    }

    public void onRestartButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        StartMenu.SetActive(false);
        InGameMenu.SetActive(true);
    }

    private void LooseGame()
    {
        LooseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void setMusicIsOn(bool value)
    {
        Settings.Instance.CurrentSettings.MusicIsOn = value;
        Settings.Instance.Save();

        _musicOnBtn.gameObject.SetActive(value);
        _musicOffBtn.gameObject.SetActive(!value);

        onSettingMusicIsOnChanged?.Invoke(); 

    }
}
