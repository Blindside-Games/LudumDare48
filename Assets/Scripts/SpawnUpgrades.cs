using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUpgrades : MonoBehaviour
{
    public GameObject[] firstUpgrades, secondUpgrades, thirdUpgrades, fourthUpgrades;

    private List<GameObject[]> upgrades;

    // Start is called before the first frame update
    void Start()
    {
        upgrades = new List<GameObject[]>(new[] { firstUpgrades, secondUpgrades, thirdUpgrades, fourthUpgrades });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnPickups(int level, Transform colliderTransform)
    {
        var currentUpgrades = upgrades[level - 1];

        var position = colliderTransform?.position ?? new Vector3(100, 100, 100);

        foreach (var upgrade in currentUpgrades)
        {
            var xZ = Random.Range(0, 900f);

            var up = Instantiate(upgrade, new Vector3(xZ, position.y, xZ), Quaternion.identity);
            up.transform.rotation = up.transform.rotation;
        }
    }
}
