using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject smallEnemyPrefab;
    public GameObject[] bossPrefabs;
    public GameObject player;

    private int maxNumberHenchmen = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelChanged(int level)
    {
        var henchmen = Random.Range(1, maxNumberHenchmen - 1);

        for (int i = 0; i <= henchmen; i++)
        {
            var enemy = Instantiate(smallEnemyPrefab, player.transform.position - new Vector3(100 + 50 * i, 100, 100), Quaternion.identity) as GameObject;

            enemy.GetComponent<Enemy>().target = player;
        }

        SpawnBoss(level - 1);
    }

    public void SpawnBoss(int bossNumber)
    {
        var boss = Instantiate(bossPrefabs[bossNumber], player.transform.position - new Vector3(100, 100, 100), Quaternion.identity) as GameObject;
        boss.GetComponent<Enemy>().target = player;
    }
}
