using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject LooseMenu;

    public static Action onStartGame;

    private void Awake()
    {
        StartMenu.SetActive(true);
        LooseMenu.SetActive(true);
    }

    public void onStartButtonClicked()
    {
        onStartGame?.Invoke();
        StartGame();
    }

    private void StartGame()
    {
        StartMenu.SetActive(false);
    }
}
