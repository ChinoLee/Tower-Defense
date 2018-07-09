using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public static int CountEnemyAlive = 0;
    public Wave[] waves;
    public Transform START;
    public float waveRate = 0.2f;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemy());
	}
	IEnumerator SpawnEnemy ()
    {
        foreach(Wave wave in waves)
        {
            for (int i = 0; i < wave.count; i++)
            {
                CountEnemyAlive++;
                GameObject.Instantiate(wave.enemyPrefab, START.position, Quaternion.identity);
                if (i != wave.count -1)
                yield return new WaitForSeconds(wave.rate);
            }
            while (CountEnemyAlive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);
        }
    }
}
