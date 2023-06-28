using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private float _maxHealth = 3;
    [SerializeField] private float _currentHealth;

    public static Action onPlayerKill;

    private void OnEnable()
    {
        Enemy.onPlayerHit += getHit;
        //Point.onLeaveLevel += getHit;
    }

    private void OnDisable()
    {
        Enemy.onPlayerHit -= getHit;
        //Point.onLeaveLevel -= getHit;
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void getHit()
    {
        _currentHealth -= 1;
        _healthBar.fillAmount = _currentHealth / _maxHealth;

        if (_currentHealth == 0)
        {
            onPlayerKill?.Invoke();
        }
    }
}
