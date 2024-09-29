using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    private List<Transform> _roadsInScene = new List<Transform>();
    [SerializeField] private List<GameObject> _roadPrefabs;

    [SerializeField] private int _roadCount;
    [SerializeField] private int _speed;
    [SerializeField] private float _deleteRoadOffsetZ;

    private Transform _deleteRoadPoint;
    private const string SPAWN_POINT_NAME = "SpawnPoint";

    private void Awake()
    {
        for (int i = 0; i < _roadCount; i++)
            SpawnNextPlatform();

        _deleteRoadPoint = GetSpawnPoint(_roadsInScene[0]);
    }

    private void Update()
        => StartMoving();

    private Transform GetSpawnPoint(Transform road)
        => road.Find(SPAWN_POINT_NAME);

    private void SpawnNextPlatform()
    {
        var spawnPos = _roadsInScene.Count > 0
            ? GetSpawnPoint(_roadsInScene[_roadsInScene.Count - 1]).position : transform.position;

        var newPlatform = SpawnRandomPlatform(spawnPos);

        _roadsInScene.Add(newPlatform);
        newPlatform.SetParent(transform);
    }

    private Transform SpawnRandomPlatform(Vector3 position) =>
        Instantiate(GetRandomRoad(), position, transform.rotation).transform;

    private GameObject GetRandomRoad() =>
        _roadPrefabs[Random.Range(0, _roadPrefabs.Count)];

    private void StartMoving()
    {
        MovePlatforms();
        DeletePlatforms();
    }

    private void MovePlatforms()
    {
        _roadsInScene.ForEach(p => p.transform.Translate(Vector3.forward * Time.deltaTime * -_speed));
    }

    private void DeletePlatforms()
    {
        if (_deleteRoadPoint.position.z + _deleteRoadOffsetZ <= transform.position.z)
        {
            Destroy(_roadsInScene[0].gameObject);
            _roadsInScene.RemoveAt(0);

            SpawnNextPlatform();
            _deleteRoadPoint = GetSpawnPoint(_roadsInScene[0]);
        }
    }
}