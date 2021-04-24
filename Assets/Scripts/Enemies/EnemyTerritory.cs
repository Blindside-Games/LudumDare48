using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour
{
    private BoxCollider territory;
    private const int maxEnemies = 20;
    private List<GameObject> enemies;
    private List<Transform> navPoints;

    // Start is called before the first frame update
    void Start()
    {
        territory = GetComponent<BoxCollider>();

        GetEnemiesInTerritory();
        GetNavigationPoints();

        StartPatrols();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log($"player entered");

            enemies.ForEach((e) =>
            {
                e.GetComponent<BasicEnemy>().SetPursueTarget(other.gameObject);
            });
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log($"{other.transform.name} exit");
            enemies.ForEach((e) =>
            {
                e.GetComponent<BasicEnemy>().BeginPatrol();
            });
        }
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

            enemyBehaviour.BeginPatrol(navPoints);
        }
    }

    private void GetNavigationPoints()
    {
        navPoints = FindObjectsOfType<Collider>()
        .Where(c => c.bounds.Intersects(territory.bounds) && c.tag.Equals("NavigationPoint"))
        .Select(c => c.transform)
        .ToList();
    }

}
