using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject BlueEnemy;
    public GameObject RedEnemy;

    private int _countEnemy;
    private float _spawnTime = 5f;
    private float _stopSpawn = 2f;
    private float _intervalDecrement = 0.5f;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            SpawnTimer();

            if (_spawnTime >= _stopSpawn)
            {
                _spawnTime -= _intervalDecrement;
            }

            yield return new WaitForSeconds(_spawnTime);
        }
    }

    void SpawnTimer()
    {
        if (_countEnemy == 4)
        {
            Instantiate(BlueEnemy, transform.position, Quaternion.identity);
            _countEnemy = 0;
        }
        else
        {
            Instantiate(RedEnemy, transform.position, Quaternion.identity);
            _countEnemy++;
        }
    }
}
