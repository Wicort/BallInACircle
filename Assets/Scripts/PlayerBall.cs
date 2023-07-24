using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    [SerializeField] private Transform _centerPoint;
    [SerializeField] private float _movingRadius;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private Animator _animator;
    private int _direction = 1;

    private float anglePosition;

    private bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;

    private void OnEnable()
    {
        Point.onCollision += addMovingSpeed;
        Game.onStartGame += initialize;
    }

    private void OnDisable()
    {
        Point.onCollision -= addMovingSpeed;
        Game.onStartGame -= initialize;
    }

    private Vector2 CalcPosition()
    {
        var positionX = _centerPoint.position.x + _movingRadius * Mathf.Cos(anglePosition);
        var positionY = _centerPoint.position.y + _movingRadius * Mathf.Sin(anglePosition);

        anglePosition += _movingSpeed * _direction * Time.deltaTime;
        return new Vector2(positionX, positionY);
    }
    private void Update()
    {
        if (IsPaused) return;

        if (Input.GetMouseButtonDown(0))
        {
            _direction = -_direction;
        }

        transform.position = CalcPosition();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_centerPoint.position, _movingRadius);
    }

    private void addMovingSpeed()
    {
        _movingSpeed += 0.1f;
        _animator.SetTrigger("Catch");
    }

    private void initialize()
    {
        _movingSpeed = 1;
    }
}
