using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MovementController : MonoBehaviour
{
    Rigidbody rigidBody;
    public float speed = 5f;

    private float yAxis = 0;

    private GameObject propeller;

    public UnityEvent<int> LevelChanged;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        propeller = transform.RecursiveFind("Propeller");
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space");

            rigidBody.AddForce(new Vector3(0, speed / 8, 0), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), yAxis, Input.GetAxis("Vertical"));

        Vector3 direction = Vector3.zero;
        switch (Input.GetAxis("Horizontal"))
        {
            case 1:
                direction = transform.right;
                break;
            case -1:
                direction = -transform.right;
                break;

            default: break;
        }

        switch (Input.GetAxis("Vertical"))
        {
            case 1:
                direction = transform.forward;
                break;
            case -1:
                direction = -transform.forward;
                break;

            default: break;
        }

        if (direction.magnitude > 0)
        {
            // propeller.transform.RotateAround(propeller.transform.position, Vector3.forward, 90 * Time.deltaTime);
        }

        rigidBody.position += direction * Time.deltaTime * speed;
    }

    void OnTriggerEnter(Collider col)
    {
        LevelChanged.Invoke(Convert.ToInt32(col.name.Last().ToString()));
    }
}
