using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _spawnPoints;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];
        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }
        StartCoroutine(SpawnUnits());
    }

    private IEnumerator SpawnUnits()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            Instantiate(_template, _points[i].position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}
