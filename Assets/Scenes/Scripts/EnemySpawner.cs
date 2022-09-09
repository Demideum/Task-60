using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private int _countEnemies;
    [SerializeField] private float _delaySpawnEnemies;

    private Transform[] _points;
    private int _currrentPoint;
    private int _currentCountEnemies;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitSeconds = new WaitForSeconds(_delaySpawnEnemies);

        while (_countEnemies > _currentCountEnemies)
        {
            Instantiate(_enemyPrefab, _points[_currrentPoint].position, Quaternion.identity);
            _currentCountEnemies++;
            _currrentPoint++;

            if (_currrentPoint >= _points.Length)
            {
                _currrentPoint = 0;
            }

            yield return waitSeconds;
        }
    }
}
