using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] Gradient _backgroundGradient;
    [SerializeField] Gradient _circleGradient;

    [Header("Objects to Colorize")]
    [SerializeField] Camera _camera;
    [SerializeField] SpriteRenderer _outerCircle;
    [SerializeField] SpriteRenderer _innerCircle;


    private float _currentPosition = 0;
    private float _direction = 0.0001f;


    private void Update()
    {
        _currentPosition = Mathf.Clamp(_currentPosition + _direction, 0, 1);

        if (_currentPosition == 0 || _currentPosition == 1) _direction *= -1;

        _camera.backgroundColor = _backgroundGradient.Evaluate(_currentPosition);
        _innerCircle.color = _backgroundGradient.Evaluate(_currentPosition);
        _outerCircle.color = _circleGradient.Evaluate(_currentPosition);

    }
}
