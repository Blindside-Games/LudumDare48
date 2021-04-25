using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject player;

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
        var enemy = Instantiate(enemyPrefab, player.transform.position - new Vector3(100, 100, 100), Quaternion.identity) as GameObject;

        enemy.GetComponent<Enemy>().target = player;
    }
}
