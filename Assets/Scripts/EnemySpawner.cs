using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Object settings")]
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _spawnTime = 3;

    [Header("Height diapason")]
    [SerializeField] private Transform _upPoint;
    [SerializeField] private Transform _downPoint;

    private float _timeToSpawn = 0;
    private bool _isSpawnerRunned = false;

    private PauseManager PauseManager => ProjectContext.Instance.PauseManager;

    private void OnEnable()
    {
        Game.onStartGame += RunSpawner;
    }

    private void OnDisable()
    {
        Game.onStartGame -= RunSpawner;
    }

    private void Awake()
    {
        _timeToSpawn = _spawnTime;
    }

    private void Update()
    {
        if (PauseManager.IsPaused) return;

        if (!_isSpawnerRunned) return;

        _timeToSpawn -= 0.01f;

        if (_timeToSpawn <= 0)
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            var yPosition = Random.Range(_downPoint.position.y, _upPoint.position.y);
            enemy.transform.position = new Vector2(transform.position.x, yPosition);

            _timeToSpawn = _spawnTime;
        }        
    }

    private void RunSpawner()
    {
        _isSpawnerRunned = true;
    }

    private void StopSpawner()
    {
        _isSpawnerRunned = false;
    }
}
