using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Waveconfig> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;

     Waveconfig currentWave;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(SpawnEnemies());
    }

    public Waveconfig GetCurrentWave()
    {
        return currentWave;
    }
   IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (Waveconfig wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(0),
                                currentWave.GetStartingWaypoint().position,
                                Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(currentWave.GetRanDomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);

            }
        } while (isLooping);

    }
}
