using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private Transform _upPosition;
    [SerializeField] private Transform _downPosition;


    private void Awake()
    {
        _point.gameObject.SetActive(false);
    }

    private void StartSpawner()
    {
        _point.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        Point.onCollision += SpawnPoint;
        Point.onLeaveLevel += SpawnPoint;
        Game.onStartGame += StartSpawner;
    }

    private void OnDisable()
    {
        Point.onCollision -= SpawnPoint;
        Point.onLeaveLevel -= SpawnPoint;
        Game.onStartGame -= StartSpawner;
    }

    private void SpawnPoint()
    {
        float yPosition = Random.Range(_downPosition.position.y, _upPosition.position.y);
        _point.position = new Vector2(transform.position.x, yPosition);
    }
}
