using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public float MovementSpeedFactor = 2.0f;
    private Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        destination = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);

        if (destination != null)
        {
            MoveToDestination();
        }
    }

    private void MoveToDestination()
    {
        var direction = (destination.position - new Vector3(20, 20, 20)) - transform.position;

        GetComponent<Rigidbody>().position += direction * Time.deltaTime / MovementSpeedFactor;
    }
}
