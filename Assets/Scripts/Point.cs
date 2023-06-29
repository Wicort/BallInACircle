using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] float _movingSpeed;
    [SerializeField] Transform _ball;
    [SerializeField] AudioClip _catchSound;

    public static Action onCollision;
    public static Action onLeaveLevel;
    private void Update()
    {
        transform.position = new Vector2(transform.position.x + _movingSpeed * Time.deltaTime, transform.position.y);
        _ball.Rotate(new Vector3(0f, 0f, -1f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerBall>(out PlayerBall _))
        {
            _movingSpeed += 0.1f;
            SoundManager.instance.PlaySound(_catchSound);
            onCollision?.Invoke();
        } else if (collision.TryGetComponent<PointStopper>(out PointStopper _))
        {
            onLeaveLevel?.Invoke();
        }
    }
}
