using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody rigidBody;
    public float speed = 5f;

    private float yAxis = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
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
                Debug.Log("d");
                direction = transform.right;
                break;
            case -1:
                Debug.Log("a");
                direction = -transform.right;
                break;

            default: break;
        }

        switch (Input.GetAxis("Vertical"))
        {
            case 1:
                Debug.Log("w");
                direction = transform.up;
                break;
            case -1:
                Debug.Log("s");
                direction = -transform.up;
                break;

            default: break;
        }

        rigidBody.position += direction * Time.deltaTime * speed;
    }
}
