using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab, enemyPointToSpawn;

    public float timeBetweenWaves = 5f;
    public Text waveCountdownText;

    private float _countdown = 2f;
    private int _waveNumber = 0;

    private void Update()
    {
        if(_countdown <= 0f) 
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;

        _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", _countdown);
    }

    IEnumerator SpawnWave()
    {
        _waveNumber++;
        PlayersStats.Rounds++;

        for (int i = 0; i < _waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.4f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, enemyPointToSpawn.position, enemyPointToSpawn.rotation);
    }
}
