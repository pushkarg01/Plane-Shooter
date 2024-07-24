using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float spawnTime = 6f;
    [SerializeField] private int enemySpawnCount = 10;

    public GameController gameController;

    private bool lastEnemy=false;

    void Start()
    {
        StartCoroutine(EnemySpawnner());

    }


    void Update()
    {
        if (lastEnemy && FindAnyObjectByType<Enemy>() == null)
        {
            StartCoroutine( gameController.LevelComplete());
        }
    }

    IEnumerator EnemySpawnner()
    {
        for (int i = 0; i < enemySpawnCount; i++)
        {
            {
                yield return new WaitForSeconds(spawnTime);
                SpawnEnemy();
            }
        }
        lastEnemy = true;
       
    }

        void SpawnEnemy()
        {
            int randomVal = Random.Range(0, enemyPrefabs.Length);
            float randomPos = Random.Range(-2.5f, 2.5f);
            Instantiate(enemyPrefabs[randomVal], new Vector2(randomPos, transform.position.y), Quaternion.identity);

        }
    
}
