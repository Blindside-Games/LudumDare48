using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour, IAttackable
{
    public float maxHealth = 100f, currentHealth = 100f;

    [HideInInspector]
    public bool isDead = false;

    public void Attack(AttackInfo attackInfo)
    {
        currentHealth -= attackInfo.Damage;
        Debug.Log(currentHealth);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            foreach (var transforms in transform)
            {
                Destroy(transform.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
