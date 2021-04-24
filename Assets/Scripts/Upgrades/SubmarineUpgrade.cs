using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineUpgrade : MonoBehaviour
{
    public GameObject model;
    public SubmarineUpgradeData upgradeData;

    public UnityEvent<SubmarineUpgradeData> Collected;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.transform.name);

        if (collider.tag.Equals("Player"))
            Collected.Invoke(upgradeData);
    }

    void OnCollisionEnter(Collision collider)
    {
        Debug.Log(collider.transform.name);

        if (collider.transform.tag.Equals("Player"))
            Collected.Invoke(upgradeData);

        gameObject.SetActive(false);
    }
}
