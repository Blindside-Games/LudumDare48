using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    private int destPoint = 0;
    private Transform destination;
    private List<Transform> navigationPoints;

    public float MovementSpeedFactor = 2f;

    private EnemyState state;

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        if (destination != null)
        {
            MoveToDestination();
        }

        if (state == EnemyState.Pursuing)
        {

        }

    }

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

    private void MoveToDestination()
    {
        var direction = destination.position - transform.position;

        GetComponent<Rigidbody>().position += direction * Time.deltaTime / MovementSpeedFactor;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("NavigationPoint"))
            Debug.Log("reached destination");

        SelectDestination();
    }
}

