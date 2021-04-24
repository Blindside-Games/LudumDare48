using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour
{
    private BoxCollider territory;
    private const int maxEnemies = 20;
    private List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        territory = GetComponent<BoxCollider>();

        GetEnemiesInTerritory();
        StartPatrols();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.transform.name} enter");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.transform.name} exit");
    }

    private void GetEnemiesInTerritory()
    {
        enemies = FindObjectsOfType<Collider>()
        .Where(c => c.bounds.Intersects(territory.bounds) && c.tag.Equals("Enemy"))
        .Select(c => c.transform.parent.gameObject)
        .ToList();
    }

    private void StartPatrols()
    {
        foreach (var enemy in enemies)
        {
            var enemyBehaviour = enemy.GetComponent<BasicEnemy>();

            enemyBehaviour.BeginPatrol();
        }
    }
}