using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : Enemy
{
    private int destPoint = 0;

    private List<Transform> navigationPoints;

    private EnemyState state;

    public void SetPursueTarget(GameObject target)
    {
        destination = target.transform;
    }

    public void BeginPatrol(List<Transform> navPoints)
    {
        navigationPoints = navPoints;

        if (navigationPoints.Count == 0)
            return;

        destination = navigationPoints[destPoint];

        state = EnemyState.Patrolling;
    }

    public void BeginPatrol()
    {
        if (navigationPoints.Count == 0)
            return;

        destination = navigationPoints[destPoint];

        state = EnemyState.Patrolling;
    }

    private void SelectDestination()
    {
        if (state == EnemyState.Patrolling)
        {
            destPoint = Random.Range(0, navigationPoints.Count - 1);

            if (navigationPoints.IndexOf(destination) == destPoint)
                destPoint = (destPoint + 1) % navigationPoints.Count;

            destination = navigationPoints[destPoint];
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("NavigationPoint"))
            Debug.Log("reached destination");

        SelectDestination();
    }
}

