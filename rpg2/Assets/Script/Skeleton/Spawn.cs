using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float enemyInterval = 4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn(enemyInterval, enemyPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawn(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-16, 6), Random.Range(-4, 0), 0), Quaternion.identity);
        StartCoroutine(EnemySpawn(interval, enemy));
    }
}
