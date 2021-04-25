using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthMeasurement : MonoBehaviour
{
    public Text label;
    public GameObject player;

    float depth = 123f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var fromPosition = transform.position;
        var toPosition = player.transform.position;
        var direction = toPosition - fromPosition;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 4000, 1 << 8))
        {
            if (hit.collider != null && hit.collider.tag.Equals("Player"))
            {
                depth = hit.distance;
            }
        }

        label.text = $"Depth: {(1020f - depth).ToString("n2")}m";
    }
}
