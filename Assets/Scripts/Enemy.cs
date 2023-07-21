using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1;
    [SerializeField] private ParticleSystem _explosionEffect;

    private PauseManager PauseManager => ProjectContext.Instance.PauseManager;
    

    public static Action onPlayerHit;

    private void Update()
    {
        if (PauseManager.IsPaused) return;

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
