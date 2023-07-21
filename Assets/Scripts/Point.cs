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

    private bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;

    private void OnEnable()
    {
        Game.onStartGame += initialize;
    }

    private void OnDisable()
    {
        Game.onStartGame -= initialize;
    }

    private void Update()
    {
        if (IsPaused) return;

        transform.position = new Vector2(transform.position.x + _movingSpeed * Time.deltaTime, transform.position.y);
        _ball.Rotate(new Vector3(0f, 0f, -1f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerBall>(out PlayerBall _))
        {
            _movingSpeed += 0.1f;
            ProjectContext.Instance.SoundManager.PlaySound(_catchSound);
            onCollision?.Invoke();
        } else if (collision.TryGetComponent<PointStopper>(out PointStopper _))
        {
            onLeaveLevel?.Invoke();
        }
    }

    private void initialize()
    {
        _movingSpeed = 1;
    }
}
