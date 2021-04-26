using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineUpgrade : MonoBehaviour
{
    public GameObject modelPrefab;
    public SubmarineUpgradeData upgradeData;

    public UnityEvent<SubmarineUpgradeData> Collected;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Upgrade spawned with model {modelPrefab}");

        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.Log("Player not found");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag.Equals("Player"))
            Collected.Invoke(upgradeData);
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.transform.tag.Equals("Player"))
        {
            //Collected.Invoke(upgradeData);

            player.GetComponent<SubmarineUpgradeManager>().Collect(upgradeData);

            gameObject.SetActive(false);
        }
    }
}
