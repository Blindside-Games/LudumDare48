using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChest : MonoBehaviour
{
    public GameObject chestPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var xZ = Random.Range(0f, 900f);

        var chest = Instantiate(chestPrefab, new Vector3(xZ, 230, xZ), Quaternion.identity);
        chest.transform.rotation = chestPrefab.transform.rotation;

        RaycastHit hit;

        if (Physics.Raycast(chest.transform.position, -chest.transform.up, out hit, 300, 1 << 7))
        {
            chest.transform.position = new Vector3(chest.transform.position.x, hit.point.y + 2, chest.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
