using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public float MovementSpeedFactor = 2.0f;
    internal Transform destination;

    public int FollowDistance;
    private Vector3 followDistance;

    private Vector3 direction;

    private int maxAmmo = 60, currentAmmo = 60;
    private float rateOfFire = 700f;
    private float interval, currentInterval = 0;
    private bool canFire = true;
    private float Spread = 0.5f;

    private AudioSource gunshot;


    // Start is called before the first frame update
    void Start()
    {
        destination = target.transform;
        followDistance = Vector3.one * FollowDistance;

        interval = 60 / rateOfFire * 1000;

        gunshot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (destination != null)
        {
            MoveToDestination();
        }

        if (target != null)
        {
            transform.LookAt(target.transform);

            if (direction.normalized.magnitude < 100)
            {
                FireAtTarget();
            }
        }
    }

    internal void MoveToDestination()
    {
        direction = (destination.position - followDistance) - transform.position;

        GetComponent<Rigidbody>().position += direction * Time.deltaTime / MovementSpeedFactor;
    }

    private void FireAtTarget()
    {
        currentInterval += Time.deltaTime * 1000;

        if (currentInterval >= interval)
        {
            if (canFire)
            {
                var randomX = Random.Range(-Spread, Spread);
                var randomY = Random.Range(-Spread, Spread);
                var randomZ = Random.Range(-Spread, Spread);

                var direction = (target.transform.position - transform.position).normalized + new Vector3(randomX, randomY, randomZ);

                Debug.DrawRay(transform.position, direction * 170, Color.red, 0.5f);

                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction, out hit, 170, 1 << 8))
                {
                    hit.transform.gameObject.GetComponent<IAttackable>().Attack(new AttackInfo
                    {
                        Damage = 5
                    });
                }

                if (gunshot != null)
                {
                    gunshot.Play();
                }

                currentInterval = 0;
                currentAmmo--;
            }

            if (currentAmmo == 0)
            {
                StartCoroutine(Reload());
            }
        }
    }

    private IEnumerator Reload()
    {
        canFire = false;

        yield return new WaitForSecondsRealtime(1.5f);

        currentAmmo = maxAmmo;
        canFire = true;
    }
}
