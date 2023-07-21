using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;

    private float _movementSpeed = 1;

    private bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;


    public static Action onPlayerHit;

    private void Awake()
    {
        var rnd = new System.Random();
        _movementSpeed = Mathf.Clamp((float)rnd.NextDouble() * 2, 0.5f, 1.5f);
    }

    private void Update()
    {
        if (IsPaused) return;

        transform.position = new Vector2(transform.position.x + _movementSpeed * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerBall>(out PlayerBall _))
        {
            if (_explosionEffect != null)
            {
                ParticleSystem explosion = Instantiate(_explosionEffect, transform.position, Quaternion.identity);
                explosion.gameObject.transform.SetParent(null);

            }
            onPlayerHit?.Invoke();
        }

        Destroy(gameObject);
    }
}
