using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject LooseMenu;

    public static Action onStartGame;

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
    }

    private void LooseGame()
    {
        LooseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
