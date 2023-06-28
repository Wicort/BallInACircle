using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1;

    public static Action onPlayerHit;

    private void Update()
    {
        transform.position = new Vector2(transform.position.x + _movementSpeed * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerBall>(out PlayerBall _))
        {
            onPlayerHit?.Invoke();
        }

        Destroy(gameObject);
    }
}
