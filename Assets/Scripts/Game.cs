using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject LooseMenu;
    [SerializeField] private GameObject InGameMenu;

    public static Action onStartGame;
    public static Action onSettingMusicIsOnChanged;
    public static Action onLooseGame;
    private Settings Settings => ProjectContext.Instance.Settings;

    private void OnEnable()
    {
        HealthBar.onPlayerKill += LooseGame;
    }
    private void OnDisable()
    {
        HealthBar.onPlayerKill -= LooseGame;
    }

    private void Awake()
    {
        StartMenu.SetActive(true);
        LooseMenu.SetActive(false);
        InGameMenu.SetActive(false);
    }


    public void onStartButtonClicked()
    {
        onStartGame?.Invoke();
        StartGame();
    }

    public void onRestartButtonClicked()
    {
        StartGame();
        var enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (var enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }

        onStartGame?.Invoke();
    }

    private void StartGame()
    {
        ProjectContext.Instance.PauseManager.setPause(false);
        StartMenu.SetActive(false);
        LooseMenu.SetActive(false);
        InGameMenu.SetActive(true);
    }

    private void LooseGame()
    {
        ProjectContext.Instance.PauseManager.setPause(true);
        LooseMenu.SetActive(true);
        onLooseGame?.Invoke();

        StartCoroutine(ShowFullScreen());
    }

    public void setMusicIsOn(bool value)
    {
        Settings.SetMusicOn(value);
    }

    IEnumerator ShowFullScreen()
    {
        yield return new WaitForSeconds(1f);

        YandexGame.FullscreenShow();
    }
}
