using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    private int destPoint = 0;
    private Transform destination;

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

    }

    public void BeginPatrol(List<Transform> navPoints)
    {
        if (navPoints.Count == 0)
            return;

        destination = navPoints[0];


    }

    private void MoveToDestination()
    {
        var direction = destination.position - transform.position;

        transform.position += direction * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Navigation point"))
            Debug.Log("reached destination");
    }
}

