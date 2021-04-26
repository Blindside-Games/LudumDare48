using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatsController : MonoBehaviour, IAttackable
{
    public float maxHealth = 100f, currentHealth = 100f;

    [HideInInspector]
    public bool isDead = false;

    public UnityEvent GameOver;

    public AudioSource impact;

    public bool Invincible;

    public float MaxHullDepth = 200f;

    public void Attack(AttackInfo attackInfo)
    {
        if (Invincible)
            return;

        currentHealth -= attackInfo.Damage;

        impact.Play();

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
            if (gameObject.CompareTag("Player"))
            {
                GameOver.Invoke();
            }
            else
            {
                foreach (var transforms in transform)
                {
                    Destroy(transform.gameObject);
                }

                Destroy(gameObject);
            }
        }
    }

    public void ApplyHullUpgrade()
    {
        var upgrade = GetComponent<SubmarineUpgradeManager>().CurrentUpgrade;

        if (upgrade.Type != UpgradeType.Hull)
            return;

        MaxHullDepth = upgrade.HullMaxDepth;
    }
}
