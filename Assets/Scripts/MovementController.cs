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

    public GameObject propeller;

    public UnityEvent<int> LevelChanged;

    public UnityEvent<int, Transform> SpawnUpgrades;

    public UnityEvent Win;

    Vector3 direction = Vector3.zero;

    private AudioSource movementSound;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        movementSound = GetComponents<AudioSource>().FirstOrDefault(a => a.clip.name.Equals("driving-sound"));

        SpawnUpgrades.Invoke(1, transform);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space");

            rigidBody.AddForce(new Vector3(0, speed / 8, 0), ForceMode.Impulse);
        }

        if (direction.magnitude > 0)
        {
            if (!movementSound.isPlaying)
            {
                movementSound.Play();
            }

            propeller.transform.Rotate(Vector3.forward, 500f * Time.deltaTime);
        }

        rigidBody.velocity += direction * Time.deltaTime * speed;
    }

    void Update()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), yAxis, Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            direction = Vector3.zero;
        }

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
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("LevelTransition"))
        {
            Vector3 toTarget = (col.gameObject.transform.position - transform.position).normalized;

            var level = Convert.ToInt32(col.name.Last().ToString());

            LevelChanged.Invoke(level);

            var nextTrigger = GameObject.Find($"Level{level + 1}");

            Debug.Log($"Spawning upgrades for level {level}");

            SpawnUpgrades.Invoke(level, nextTrigger?.transform ?? null);

            col.gameObject.SetActive(false);
        }

        if (col.CompareTag("Chest"))
        {
            if (col is SphereCollider)
            {
                Debug.Log("spawn final boss");

                var bossSpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawnManager>();

                bossSpawner.SpawnBoss(4);

                col.gameObject.GetComponent<SphereCollider>().enabled = false;
            }

            if (col is BoxCollider)
            {
                Debug.Log("you win");
                Win.Invoke();
            }
        }
    }
}
