using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    [SerializeField] Transform _centerPoint;
    [SerializeField] float _movingRadius;
    [SerializeField] float _movingSpeed;
    private int _direction = 1;

    private float anglePosition;

    private void OnEnable()
    {
        Point.onCollision += addMovingSpeed;
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
    }
}
