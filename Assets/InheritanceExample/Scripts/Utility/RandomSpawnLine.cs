using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnLine : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Transform _minSpawnLoc;
    [SerializeField] private Transform _maxSpawnLoc;

    [Header("General")]
    public float SpawnCooldown = 2;

    [SerializeField] List<GameObject> _spawnList = new List<GameObject>();

    private float _elapsedCooldown = 0;

    private void Update()
    {
        _elapsedCooldown += Time.deltaTime;
        if (_elapsedCooldown >= SpawnCooldown)
        {
            Spawn();
            _elapsedCooldown = 0;
        }
    }

    public static Vector3 GetRandomSpawnPositionFromLine
        (Transform startLoc, Transform endLoc)
    {
        float randomXPos = UnityEngine.Random.Range
            (startLoc.position.x, endLoc.position.x);
        float randomYPos = UnityEngine.Random.Range
            (startLoc.position.y, endLoc.position.y);
        float randomZPos = UnityEngine.Random.Range
            (startLoc.position.z, endLoc.position.z);

        return new Vector3(randomXPos, randomYPos, randomZPos);
    }

    public static GameObject GetRandomSpawn(List<GameObject> spawnList)
    {
        int randomIndex = UnityEngine.Random.Range(0, spawnList.Count);
        return spawnList[randomIndex];
    }

    public void Spawn()
    {
        if (_minSpawnLoc == null || _maxSpawnLoc == null) { return; }
        if (_spawnList.Count == 0 || _spawnList == null) { return; }

        Vector3 randomSpawnPoint =
            GetRandomSpawnPositionFromLine
            (_minSpawnLoc, _maxSpawnLoc);
        GameObject randomSpawnObject = GetRandomSpawn(_spawnList);
        Instantiate(randomSpawnObject, randomSpawnPoint, transform.rotation);

        // make it harder, but not below a certain amount
        if(SpawnCooldown > .1f)
        {
            SpawnCooldown -= .02f;
        }
        else
        {
            SpawnCooldown = .1f;
        }
    }

    private void OnDrawGizmos()
    {
        if(_minSpawnLoc != null || _maxSpawnLoc != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_minSpawnLoc.position, _maxSpawnLoc.position);
        }
    }
}
