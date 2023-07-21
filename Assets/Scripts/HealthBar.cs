using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private AudioClip _hitSound;
    private float _maxHealth = 3;
    private float _currentHealth;
    

    public static Action onPlayerKill;

    private void OnEnable()
    {
        Enemy.onPlayerHit += getHit;
        Game.onStartGame += Initialize;
        //Point.onLeaveLevel += getHit;
    }

    private void OnDisable()
    {
        Enemy.onPlayerHit -= getHit;
        Game.onStartGame -= Initialize;
        //Point.onLeaveLevel -= getHit;
    }

    private void Awake()
    {
        Initialize();
    }

    private void getHit()
    {
        ProjectContext.Instance.SoundManager.PlaySound(_hitSound);
        _currentHealth -= 1;
        _healthBar.fillAmount = _currentHealth / _maxHealth;

        if (_currentHealth == 0)
        {
            onPlayerKill?.Invoke();
        }
    }

    public void Initialize()
    {
        Debug.Log("Initialize health");
        _currentHealth = _maxHealth;
        _healthBar.fillAmount = _currentHealth / _maxHealth;
    }
}
